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
