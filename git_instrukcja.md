# Instrukcja Git - Krok po kroku

## 1. Inicjowanie repozytorium Git

### Nowe repozytorium

Aby rozpocząć pracę z Git w istniejącym folderze projektu:

```bash
# Przejdź do folderu projektu
cd ścieżka/do/projektu

# Zainicjuj repozytorium Git
git init
```

Po wykonaniu `git init` w folderze zostanie utworzony ukryty katalog `.git`, który zawiera wszystkie informacje o repozytorium.

### Klonowanie istniejącego repozytorium

Jeśli chcesz sklonować istniejące repozytorium z GitHub:

```bash
git clone https://github.com/tiszczesz/niepo_2025_26.git
```

## 2. Ustawienie użytkownika i email

### Konfiguracja globalna (dla wszystkich repozytoriów)

```bash
# Ustaw swoją nazwę użytkownika
git config --global user.name "Twoje Imię i Nazwisko"

# Ustaw swój adres email
git config --global user.email "twoj.email@example.com"
```

### Konfiguracja lokalna (tylko dla bieżącego repozytorium)

```bash
# Ustaw nazwę użytkownika tylko dla tego projektu
git config user.name "Twoje Imię i Nazwisko"

# Ustaw email tylko dla tego projektu
git config user.email "twoj.email@example.com"
```

### Sprawdzenie konfiguracji

```bash
# Zobacz wszystkie ustawienia
git config --list

# Zobacz konkretne ustawienie
git config user.name
git config user.email
```

## 3. Dodawanie plików

### Dodawanie pojedynczych plików

```bash
# Dodaj konkretny plik do staging area
git add nazwa_pliku.txt

# Dodaj plik z konkretnej ścieżki
git add folder/plik.js
```

### Dodawanie wielu plików

```bash
# Dodaj wszystkie pliki z bieżącego katalogu
git add .

# Dodaj wszystkie pliki konkretnego typu
git add *.js

# Dodaj wszystkie pliki z konkretnego folderu
git add folder/

# Dodaj wszystkie zmodyfikowane pliki
git add -A
```

### Sprawdzanie statusu

```bash
# Zobacz status repozytorium
git status

# Skrócona wersja statusu
git status -s
```

### Commitowanie zmian

```bash
# Zapisz zmiany z komunikatem
git commit -m "Opis wprowadzonych zmian"

# Dodaj wszystkie zmodyfikowane pliki i commituj
git commit -am "Opis zmian"
```

## 4. Dodatkowe przydatne komendy

### Wyświetlanie historii

```bash
# Pokaż historię commitów
git log

# Skrócona historia
git log --oneline

# Historia z grafiką
git log --oneline --graph --all
```

### Usuwanie plików ze staging area

```bash
# Usuń plik ze staging area (plik pozostaje w folderze)
git reset nazwa_pliku.txt

# Usuń wszystkie pliki ze staging area
git reset
```

### Plik .gitignore

Utwórz plik `.gitignore` w głównym katalogu projektu, aby zignorować niepotrzebne pliki:

```
# Ignoruj pliki node_modules
node_modules/

# Ignoruj pliki .env
.env

# Ignoruj wszystkie pliki .log
*.log

# Ignoruj folder build
build/
dist/
```

## 5. Praca ze zdalnym repozytorium

### Dodanie zdalnego repozytorium

```bash
# Dodaj zdalne repozytorium o nazwie "origin"
git remote add origin https://github.com/tiszczesz/niepo_2025_26.git
```

### Wysyłanie zmian

```bash
# Wyślij zmiany do zdalnego repozytorium
git push origin main

# Przy pierwszym pushu ustaw upstream
git push -u origin main
```

### Pobieranie zmian

```bash
# Pobierz i scal zmiany ze zdalnego repozytorium
git pull origin main

# Tylko pobierz zmiany (bez scalania)
git fetch origin
```

## 6. Cofanie do wybranego commita

### Wyświetlenie historii commitów

```bash
# Pokaż historię z hashami commitów
git log --oneline

# Szczegółowa historia
git log
```

### Reset do wybranego commita (usuwanie commitów)

#### Soft reset - zachowuje zmiany w staging area

```bash
# Cofnij do wybranego commita, zmiany pozostają w staging area
git reset --soft [hash_commita]

# Przykład
git reset --soft a1b2c3d
```

#### Mixed reset - zachowuje zmiany, ale usuwa ze staging area (domyślny)

```bash
# Cofnij do wybranego commita, zmiany pozostają w katalogu roboczym
git reset --mixed [hash_commita]

# lub krócej (mixed jest domyślny)
git reset [hash_commita]
```

#### Hard reset - usuwa wszystkie zmiany

```bash
# UWAGA: Trwale usuwa wszystkie zmiany po wybranym commicie
git reset --hard [hash_commita]

# Przykład
git reset --hard a1b2c3d
```

### Powrót do konkretnego commita bez usuwania historii (revert)

```bash
# Utworzy nowy commit, który cofa zmiany z wybranego commita
git revert [hash_commita]

# Cofnięcie kilku commitów
git revert [hash_od]..[hash_do]
```

### Przeniesienie HEAD do wybranego commita (checkout)

```bash
# Przejdź do wybranego commita (tryb odczepiony HEAD)
git checkout [hash_commita]

# Powrót do głównej gałęzi
git checkout main
```

### Przydatne komendy do nawigacji

```bash
# Cofnij się o jeden commit
git reset HEAD~1

# Cofnij się o trzy commity
git reset HEAD~3

# Hard reset o jeden commit wstecz
git reset --hard HEAD~1
```

### Wypchnięcie zmian po resecie (jeśli już wypchałeś commity)

```bash
# UWAGA: Używaj z rozwagą! Zmienia historię zdalnego repozytorium
git push --force origin main

# Bezpieczniejsza opcja
git push --force-with-lease origin main
```

## Przykładowy workflow

```bash
# 1. Zainicjuj repozytorium
git init

# 2. Skonfiguruj użytkownika
git config user.name "Jan Kowalski"
git config user.email "jan.kowalski@example.com"

# 3. Utwórz plik .gitignore
echo "node_modules/" > .gitignore

# 4. Dodaj pliki
git add .

# 5. Wykonaj pierwszy commit
git commit -m "Initial commit"

# 6. Dodaj zdalne repozytorium
git remote add origin https://github.com/tiszczesz/niepo_2025_26.git

# 7. Wyślij zmiany
git push -u origin main
```

## Przydatne wskazówki

- **Commituj często** - małe, logiczne zmiany są łatwiejsze do śledzenia
- **Pisz jasne komunikaty** - opisuj co i dlaczego zmieniłeś
- **Sprawdzaj status** - używaj `git status` przed dodawaniem i commitowaniem
- **Używaj .gitignore** - nie przechowuj plików tymczasowych i wrażliwych danych
- **Synchronizuj regularnie** - często rób `pull` i `push`, aby uniknąć konfliktów
