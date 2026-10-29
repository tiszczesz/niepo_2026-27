# Sito Eratostenesa — liczby pierwsze w C++

- **Cel:** znaleźć wszystkie liczby pierwsze nie większe niż podana liczba `n`.
- **Liczba pierwsza** to liczba całkowita większa od `1`, która ma dokładnie dwa dzielniki: `1` i samą siebie. Zatem `0` i `1` nie są pierwsze.
- **Pomysł algorytmu:** zamiast sprawdzać każdą liczbę osobno, stopniowo skreślamy wielokrotności kolejnych liczb pierwszych. Liczby, które nie zostaną skreślone, są pierwsze.
- **Kroki działania:**
  1. Przygotuj tablicę `czy_pierwsza` dla liczb od `0` do `n` i ustaw jej wartości na `true`.
  2. Ustaw `czy_pierwsza[0]` oraz `czy_pierwsza[1]` na `false` — te liczby nie są pierwsze.
  3. Rozpatruj kolejne liczby `p` zaczynając od `2`, dopóki `p * p <= n`.
  4. Jeśli `p` nadal jest oznaczone jako pierwsze, skreśl jego wielokrotności: `p*p`, `p*p+p`, `p*p+2*p` i tak dalej.
  5. Zacznij skreślanie od `p*p`, ponieważ mniejsze wielokrotności `p` mają już mniejszy dzielnik i zostały skreślone wcześniej.
  6. Po zakończeniu wszystkie indeksy z wartością `true` oznaczają liczby pierwsze.
- **Dlaczego wystarczy sprawdzać do pierwiastka z `n`?** Każda liczba złożona nie większa niż `n` ma co najmniej jeden dzielnik nie większy niż `sqrt(n)`. W kodzie warunek `p <= n / p` sprawdza to bez mnożenia `p * p` w warunku.
- **Złożoność:** czasowa `O(n log log n)`, pamięciowa `O(n)`.

## Implementacja w C++

Program wczytuje `n` i wypisuje wszystkie liczby pierwsze od `2` do `n`.

```cpp
#include <iostream>
#include <vector>

int main() {
    int n;
    if (!(std::cin >> n) || n < 0) {
        return 1;
    }

    std::vector<bool> czy_pierwsza(static_cast<std::size_t>(n) + 1, true);
    czy_pierwsza[0] = false;
    if (n >= 1) czy_pierwsza[1] = false;

    for (int p = 2; p <= n / p; ++p) {
        if (czy_pierwsza[p]) {
            for (long long wielokrotnosc = 1LL * p * p;
                 wielokrotnosc <= n;
                 wielokrotnosc += p) {
                czy_pierwsza[static_cast<std::size_t>(wielokrotnosc)] = false;
            }
        }
    }

    for (int liczba = 2; liczba <= n; ++liczba) {
        if (czy_pierwsza[liczba]) {
            std::cout << liczba << ' ';
        }
    }
    std::cout << '\n';
}
```

### Przykład

Dla wejścia `20` program wypisze:

```text
2 3 5 7 11 13 17 19
```
