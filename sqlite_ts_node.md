# SQLite + TypeScript + Node.js – tutorial krok po kroku

Aplikacja konsolowa łącząca się z bazą SQLite, tworząca tabelę `courses(id, title, price, date)`, wstawiająca 5 wstępnych rekordów oraz pobierająca i zapisująca dane. Używamy biblioteki **better-sqlite3** (prosta, synchroniczna).

## Wymagania

- Node.js 18+ (`node -v`)
- npm

## Krok 1. Utworzenie projektu

```bash
mkdir courses-app
cd courses-app
npm init -y
```

## Krok 2. Instalacja zależności

```bash
npm install better-sqlite3
npm install -D typescript tsx @types/node @types/better-sqlite3
```

- `better-sqlite3` – sterownik SQLite
- `typescript` – kompilator
- `tsx` – uruchamianie plików `.ts` bez osobnej kompilacji
- `@types/*` – typy

## Krok 3. Konfiguracja TypeScript

```bash
npx tsc --init
```

Zastąp zawartość `tsconfig.json`:

```json
{
  "compilerOptions": {
    "target": "ES2022",
    "module": "CommonJS",
    "outDir": "dist",
    "rootDir": "src",
    "strict": true,
    "esModuleInterop": true,
    "skipLibCheck": true
  },
  "include": ["src"]
}
```

## Krok 4. Skrypty w `package.json`

W sekcji `"scripts"`:

```json
"scripts": {
  "dev": "tsx src/index.ts",
  "build": "tsc",
  "start": "node dist/index.js"
}
```

## Krok 5. Struktura plików

```
courses-app/
├── src/
│   ├── db.ts          # połączenie, tworzenie tabeli, dane startowe
│   ├── courses.ts     # operacje na danych (pobieranie, zapis)
│   └── index.ts       # punkt wejścia
├── package.json
└── tsconfig.json
```

```bash
mkdir src
```

## Krok 6. Połączenie z bazą i dane początkowe – `src/db.ts`

```ts
import Database from "better-sqlite3";

export interface Course {
  id: number;
  title: string;
  price: number;
  date: string; // format ISO: YYYY-MM-DD
}

export type NewCourse = Omit<Course, "id">;

const seedData: NewCourse[] = [
  { title: "TypeScript od podstaw", price: 199.99, date: "2026-01-15" },
  { title: "Node.js w praktyce", price: 249.0, date: "2026-02-10" },
  { title: "SQL dla początkujących", price: 149.5, date: "2026-03-05" },
  { title: "React i Hooki", price: 299.0, date: "2026-04-20" },
  { title: "Git i GitHub", price: 99.0, date: "2026-05-12" },
];

export function openDb(file = "courses.db"): Database.Database {
  const db = new Database(file); // plik zostanie utworzony, jeśli nie istnieje

  db.exec(`
    CREATE TABLE IF NOT EXISTS courses (
      id    INTEGER PRIMARY KEY AUTOINCREMENT,
      title TEXT    NOT NULL,
      price REAL    NOT NULL,
      date  TEXT    NOT NULL
    )
  `);

  seed(db);
  return db;
}

function seed(db: Database.Database): void {
  const { count } = db
    .prepare("SELECT COUNT(*) AS count FROM courses")
    .get() as { count: number };

  if (count > 0) return; // dane startowe tylko raz

  const insert = db.prepare(
    "INSERT INTO courses (title, price, date) VALUES (@title, @price, @date)"
  );
  const insertMany = db.transaction((rows: NewCourse[]) => {
    for (const row of rows) insert.run(row);
  });
  insertMany(seedData);
}
```

Uwagi:
- SQLite nie ma osobnego typu daty – przechowujemy ją jako tekst ISO (`YYYY-MM-DD`), który poprawnie się sortuje.
- Transakcja zapewnia, że wszystkie 5 rekordów zostanie dodanych albo żaden.

## Krok 7. Operacje na danych – `src/courses.ts`

```ts
import type Database from "better-sqlite3";
import type { Course, NewCourse } from "./db";

export function getAll(db: Database.Database): Course[] {
  return db
    .prepare("SELECT id, title, price, date FROM courses ORDER BY id")
    .all() as Course[];
}

export function getById(db: Database.Database, id: number): Course | undefined {
  return db
    .prepare("SELECT id, title, price, date FROM courses WHERE id = ?")
    .get(id) as Course | undefined;
}

export function add(db: Database.Database, course: NewCourse): Course {
  const info = db
    .prepare("INSERT INTO courses (title, price, date) VALUES (@title, @price, @date)")
    .run(course);
  return { id: Number(info.lastInsertRowid), ...course };
}

export function update(db: Database.Database, course: Course): boolean {
  const info = db
    .prepare("UPDATE courses SET title = @title, price = @price, date = @date WHERE id = @id")
    .run(course);
  return info.changes > 0;
}

export function remove(db: Database.Database, id: number): boolean {
  return db.prepare("DELETE FROM courses WHERE id = ?").run(id).changes > 0;
}
```

Zawsze używamy **parametrów** (`?`, `@nazwa`) zamiast sklejania tekstu SQL – chroni to przed SQL injection.

## Krok 8. Punkt wejścia – `src/index.ts`

```ts
import { openDb } from "./db";
import { add, getAll, getById, remove, update } from "./courses";

const db = openDb();

console.log("== Wszystkie kursy (dane startowe) ==");
console.table(getAll(db));

console.log("== Dodanie kursu ==");
const created = add(db, { title: "Docker dla programistów", price: 179, date: "2026-06-01" });
console.log("Dodano:", created);

console.log("== Pobranie po id ==");
console.log(getById(db, created.id));

console.log("== Aktualizacja ceny ==");
update(db, { ...created, price: 159 });
console.log(getById(db, created.id));

console.log("== Usunięcie ==");
console.log("Usunięto:", remove(db, created.id));

console.log("== Stan końcowy ==");
console.table(getAll(db));

db.close();
```

## Krok 9. Uruchomienie

Tryb developerski:

```bash
npm run dev
```

Lub budowanie i start:

```bash
npm run build
npm start
```

Przy pierwszym uruchomieniu powstanie plik `courses.db` z 5 kursami. Kolejne uruchomienia nie dublują danych startowych.

## Krok 10. Podgląd bazy (opcjonalnie)

```bash
sqlite3 courses.db "SELECT * FROM courses;"
```

Albo użyj rozszerzenia VS Code „SQLite Viewer".

## Krok 11. `.gitignore`

```
node_modules
dist
*.db
```

## Najczęstsze problemy

| Problem | Rozwiązanie |
|---|---|
| Błąd budowania `better-sqlite3` | Zainstaluj narzędzia budowania (Linux: `build-essential python3`) lub użyj nowszej wersji Node z gotowymi binariami |
| `Cannot find module 'better-sqlite3'` | Uruchom `npm install` w katalogu projektu |
| Dane się dublują | Seed wykonuje się tylko gdy tabela jest pusta – sprawdź, czy nie używasz różnych plików `.db` |

## Alternatywa

Node.js 22+ ma wbudowany moduł `node:sqlite` (eksperymentalny), który nie wymaga zewnętrznej biblioteki. `better-sqlite3` jest jednak stabilniejszy i szerzej stosowany.
