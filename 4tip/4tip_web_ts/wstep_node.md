# Wstęp do Node.js i TypeScript

Poniższy przykład tworzy projekt npm, instaluje TypeScript lokalnie i pokazuje, jak skompilować oraz uruchomić program.

## 1. Inicjalizacja npm

W terminalu przejdź do katalogu, w którym chcesz utworzyć projekt, i wykonaj:

```bash
mkdir pierwszy-projekt-ts
cd pierwszy-projekt-ts
npm init -y
```

Polecenie `npm init -y` utworzy plik `package.json` z domyślnymi ustawieniami projektu.

## 2. Lokalna instalacja TypeScript

Zainstaluj TypeScript jako zależność deweloperską projektu:

```bash
npm install --save-dev typescript
```

Kompilator będzie dostępny lokalnie przez `npx tsc`. Nie trzeba instalować go globalnie.

## 3. Przygotowanie przykładu

Utwórz katalog `src`, a w nim plik `index.ts`:

```typescript
const imie: string = "Ala";
const wiek: number = 17;

console.log(`Cześć, ${imie}!`);
console.log(`Za rok będziesz mieć ${wiek + 1} lat.`);
```

W katalogu głównym projektu utwórz plik `tsconfig.json`:

```json
{
  "compilerOptions": {
    "target": "ES2020",
    "module": "CommonJS",
    "rootDir": "./src",
    "outDir": "./dist",
    "strict": true,
    "esModuleInterop": true,
    "skipLibCheck": true
  },
  "include": ["src/**/*.ts"]
}
```

Konfiguracja określa, że pliki TypeScript znajdują się w `src`, a wynik kompilacji ma trafić do `dist`.

## 4. Kompilacja i uruchomienie

W katalogu projektu skompiluj pliki:

```bash
npx tsc
```

Kompilator utworzy `dist/index.js`. Uruchom go w Node.js:

```bash
node dist/index.js
```

Oczekiwany wynik:

```text
Cześć, Ala!
Za rok będziesz mieć 18 lat.
```

TypeScript jest kompilowany do JavaScriptu — Node.js uruchamia wygenerowany plik `.js`, a nie plik `.ts`.
