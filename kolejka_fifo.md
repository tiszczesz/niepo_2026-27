# Kolejka FIFO a stos LIFO w C++

## Kolejka — pierwszy wchodzi, pierwszy wychodzi

Kolejka działa według zasady **FIFO** (*First In, First Out*): element dodany jako pierwszy zostanie obsłużony jako pierwszy. Można ją porównać do kolejki osób do kasy — nowa osoba dołącza na końcu, a obsługiwana jest osoba stojąca na początku.

Przykład:

```text
dodaj A, dodaj B, dodaj C  →  [A, B, C]
usuń element                →  [B, C]       (usunięto A)
```

W C++ kolejkę udostępnia `std::queue` z nagłówka `<queue>`. Najważniejsze operacje:

| Operacja | Znaczenie |
|---|---|
| `push(x)` | dodaje `x` na końcu kolejki |
| `front()` | zwraca pierwszy element, który będzie obsłużony |
| `back()` | zwraca ostatni element |
| `pop()` | usuwa pierwszy element |
| `empty()` | sprawdza, czy kolejka jest pusta |
| `size()` | zwraca liczbę elementów |

`pop()` usuwa element, ale go nie zwraca. Jeśli potrzebujemy jego wartości, najpierw odczytujemy `front()`, a potem wywołujemy `pop()`. Przed użyciem `front()`, `back()` lub `pop()` należy sprawdzić, czy kolejka nie jest pusta.

## Przykład kolejki w C++

```cpp
#include <iostream>
#include <queue>
#include <string>

int main() {
    std::queue<std::string> kolejka;

    kolejka.push("Ala");
    kolejka.push("Bartek");
    kolejka.push("Celina");

    while (!kolejka.empty()) {
        std::cout << kolejka.front() << '\n';
        kolejka.pop();
    }
}
```

Program wypisze:

```text
Ala
Bartek
Celina
```

Elementy są obsługiwane w tej samej kolejności, w której zostały dodane.

## Stos — ostatni wchodzi, pierwszy wychodzi

Stos działa według zasady **LIFO** (*Last In, First Out*): jako pierwszy zostanie zdjęty element dodany jako ostatni. Przykładem jest stos talerzy — można położyć talerz na górze i zdjąć tylko ten, który leży na samej górze.

```text
dodaj A, dodaj B, dodaj C  →  dół [A, B, C] góra
usuń element                →  dół [A, B]    góra   (usunięto C)
```

W C++ stos udostępnia `std::stack` z nagłówka `<stack>`. Dodawanie wykonuje się przez `push(x)`, odczyt ostatnio dodanego elementu przez `top()`, a jego usuwanie przez `pop()`. Tak jak w kolejce, `pop()` nie zwraca usuwanego elementu. Przed użyciem `top()` lub `pop()` należy sprawdzić `empty()`.

```cpp
#include <iostream>
#include <stack>
#include <string>

int main() {
    std::stack<std::string> stos;

    stos.push("Ala");
    stos.push("Bartek");
    stos.push("Celina");

    while (!stos.empty()) {
        std::cout << stos.top() << '\n';
        stos.pop();
    }
}
```

Program wypisze:

```text
Celina
Bartek
Ala
```

## Porównanie

| Cecha | Kolejka `std::queue` | Stos `std::stack` |
|---|---|---|
| Zasada | FIFO — pierwszy dodany, pierwszy usunięty | LIFO — ostatni dodany, pierwszy usunięty |
| Dodawanie | `push(x)` na końcu | `push(x)` na górze |
| Odczyt następnego elementu | `front()` — początek kolejki | `top()` — wierzchołek stosu |
| Usuwanie | `pop()` z początku | `pop()` z wierzchołka |
| Typowy przykład | kolejka zadań do wykonania | historia operacji „cofnij” |

Oba kontenery pozwalają dodawać i usuwać elementy w czasie stałym `O(1)`. Nie służą do swobodnego dostępu do elementu o wybranym indeksie. Wybierz kolejkę, gdy ważna jest kolejność zgłoszeń; wybierz stos, gdy najpierw trzeba obsłużyć ostatnio dodany element.

## Własna kolejka FIFO bez bibliotek `std`

Poniższa klasa przechowuje liczby całkowite w tablicy o pojemności pięciu elementów. `poczatek` wskazuje pierwszy element, a `liczba` przechowuje aktualny rozmiar. Tablica jest traktowana jak pierścień: po ostatnim indeksie wracamy do indeksu `0`, dzięki czemu można ponownie wykorzystać zwolnione miejsca.

Metoda `dodaj` zwraca `false`, gdy kolejka jest pełna. Metoda `pobierz` zapisuje pierwszy element w zmiennej przekazanej przez referencję i usuwa go; gdy kolejka jest pusta, zwraca `false` i nie zmienia tej zmiennej.

```cpp
class Kolejka {
    static const int POJEMNOSC = 5;
    int elementy[POJEMNOSC];
    int poczatek = 0;
    int liczba = 0;

public:
    bool pusta() const {
        return liczba == 0;
    }

    bool dodaj(int wartosc) {
        if (liczba == POJEMNOSC) {
            return false;
        }

        int koniec = (poczatek + liczba) % POJEMNOSC;
        elementy[koniec] = wartosc;
        ++liczba;
        return true;
    }

    bool pobierz(int& wartosc) {
        if (pusta()) {
            return false;
        }

        wartosc = elementy[poczatek];
        poczatek = (poczatek + 1) % POJEMNOSC;
        --liczba;
        return true;
    }
};

int main() {
    Kolejka kolejka;
    if (!kolejka.dodaj(10) || !kolejka.dodaj(20) || !kolejka.dodaj(30)) {
        return 1;
    }

    int wartosc = 0;
    if (!kolejka.pobierz(wartosc) || wartosc != 10) return 1;
    if (!kolejka.pobierz(wartosc) || wartosc != 20) return 1;
    if (!kolejka.pobierz(wartosc) || wartosc != 30) return 1;
    if (!kolejka.pusta()) return 1;

    return 0;
}
```

Kolejne wywołania `pobierz` zwracają przez `wartosc` liczby `10`, `20`, `30`: pierwszy dodany element jest pobierany jako pierwszy.

## Własny stos LIFO bez bibliotek `std`

Stos również korzysta z tablicy o pojemności pięciu elementów. `liczba` wskazuje liczbę zajętych miejsc, a zarazem indeks następnego wolnego miejsca. Element na wierzchu znajduje się pod indeksem `liczba - 1`.

Metoda `dodaj` zwraca `false`, gdy stos jest pełny. Metoda `pobierz` zapisuje i usuwa element z wierzchu; gdy stos jest pusty, zwraca `false` i nie zmienia przekazanej zmiennej.

```cpp
class Stos {
    static const int POJEMNOSC = 5;
    int elementy[POJEMNOSC];
    int liczba = 0;

public:
    bool pusty() const {
        return liczba == 0;
    }

    bool dodaj(int wartosc) {
        if (liczba == POJEMNOSC) {
            return false;
        }

        elementy[liczba] = wartosc;
        ++liczba;
        return true;
    }

    bool pobierz(int& wartosc) {
        if (pusty()) {
            return false;
        }

        --liczba;
        wartosc = elementy[liczba];
        return true;
    }
};

int main() {
    Stos stos;
    if (!stos.dodaj(10) || !stos.dodaj(20) || !stos.dodaj(30)) {
        return 1;
    }

    int wartosc = 0;
    if (!stos.pobierz(wartosc) || wartosc != 30) return 1;
    if (!stos.pobierz(wartosc) || wartosc != 20) return 1;
    if (!stos.pobierz(wartosc) || wartosc != 10) return 1;
    if (!stos.pusty()) return 1;

    return 0;
}
```

Kolejne wywołania `pobierz` zwracają przez `wartosc` liczby `30`, `20`, `10`: ostatni dodany element jest pobierany jako pierwszy.

Każdy z dwóch przykładów jest osobnym programem i nie wymaga żadnych nagłówków ani bibliotek `std`. Nie wypisuje tekstu: kończy się kodem `0`, jeśli operacje i ich wyniki są poprawne, albo kodem `1` w przeciwnym razie. Przykład można zapisać do pliku `przyklad.cpp` i skompilować poleceniem `g++ -std=c++11 -Wall -Wextra -pedantic przyklad.cpp -o przyklad`, a następnie uruchomić przez `./przyklad`.

W obu klasach dodawanie i pobieranie mają złożoność czasową `O(1)`. Pojemność jest stała; wstawienie elementu do pełnej struktury nie nadpisuje istniejących danych.
