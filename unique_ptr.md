# `std::unique_ptr` w C++

## Czym jest `std::unique_ptr`?

`std::unique_ptr` to inteligentny wskaźnik ze standardowej biblioteki C++ (`<memory>`). Reprezentuje **wyłączną własność** obiektu: po zniszczeniu wskaźnika usuwa zarządzany obiekt. Dzięki temu zwykle nie trzeba samodzielnie wywoływać `delete`.

Jest to przykład zasady RAII: zasób jest powiązany z czasem życia obiektu zarządzającego. Destruktor `unique_ptr` zwalnia zasób także wtedy, gdy funkcja kończy się wcześniej przez `return` lub wyjątek.

## Zwykły wskaźnik

Zwykły wskaźnik przechowuje adres, ale sam nie określa, kto jest właścicielem obiektu. Jeżeli tworzymy obiekt przez `new`, musimy dopilnować jego usunięcia:

```cpp
#include <iostream>

int main() {
    int* liczba = new int(42);
    std::cout << *liczba << '\n';

    delete liczba;
    liczba = nullptr;
}
```

Pominięcie `delete` powoduje wyciek pamięci. Przedwczesny `return` lub wyjątek między `new` a `delete` również mogą go spowodować. Z kolei użycie wskaźnika po `delete` albo ponowne usunięcie tego samego obiektu prowadzi do niezdefiniowanego zachowania. Ustawienie `liczba` na `nullptr` nie naprawia innych wskaźników wskazujących na usunięty obiekt.

Zwykły wskaźnik nie zawsze jest właścicielem: może wskazywać np. na obiekt lokalny lub obiekt zarządzany przez kogoś innego. Takiego wskaźnika nie należy usuwać przez `delete`.

## Ten sam przykład z `unique_ptr`

```cpp
#include <iostream>
#include <memory>

int main() {
    auto liczba = std::make_unique<int>(42);
    std::cout << *liczba << '\n';
}
```

`std::make_unique<int>(42)` tworzy obiekt i zwraca zarządzający nim `std::unique_ptr<int>`. Po wyjściu z `main()` destruktor wskaźnika automatycznie usuwa obiekt. Nie należy wywoływać `delete` na adresie zwróconym przez `liczba.get()`: wskaźnik nadal jest właścicielem i później próbowałby usunąć obiekt ponownie.

Oba przykłady wypisują `42`. Można je kompilować jako osobne programy w C++14 lub nowszym, np. `g++ -std=c++14 -Wall -Wextra -pedantic przyklad.cpp -o przyklad`. `unique_ptr` jest dostępny od C++11, a `make_unique` od C++14.

## Porównanie

| Cecha | Zwykły wskaźnik `T*` | `std::unique_ptr<T>` |
|---|---|---|
| Własność | Nie wynika z samego typu | Wyłączna własność zarządzanego obiektu |
| Zwolnienie zasobu | Właściciel musi je zapewnić, np. przez `delete` dla obiektu utworzonego przez `new` | Automatyczne przy zniszczeniu wskaźnika lub zastąpieniu obiektu |
| Kopiowanie | Kopiuje adres; nie kopiuje obiektu ani nie określa właściciela | Niedozwolone; własność można przenieść |
| Pusty wskaźnik | Może mieć wartość `nullptr` | Może być pusty, również po przeniesieniu |
| Typowe zastosowanie | Niewłaścicielski dostęp do obiektu | Przechowywanie i przekazywanie wyłącznej własności |

Sam `unique_ptr` nie zapobiega wszystkim błędom: nie wolno dereferencjonować pustego wskaźnika ani używać pożyczonego adresu po usunięciu obiektu.

## Przenoszenie własności

`unique_ptr` nie można skopiować, ale można go przenieść za pomocą `std::move`:

```cpp
#include <iostream>
#include <memory>
#include <utility>

int main() {
    auto pierwszy = std::make_unique<int>(42);
    auto drugi = std::move(pierwszy);

    if (!pierwszy) {
        std::cout << "Pierwszy wskaźnik jest pusty\n";
    }
    std::cout << *drugi << '\n';
}
```

Po przeniesieniu `drugi` jest właścicielem obiektu, a `pierwszy` jest pusty. Nie wolno dereferencjonować pustego wskaźnika. Można natomiast przypisać mu nowy obiekt.

## Przekazywanie do funkcji

Sposób przekazania powinien wyrażać zamiar:

- `void przejmij(std::unique_ptr<T> p)` — funkcja przejmuje własność; wywołujący przekazuje nazwany wskaźnik przez `std::move`.
- `void uzyj(const T& obiekt)` — funkcja tylko korzysta z istniejącego obiektu, bez przejmowania własności; można wywołać ją jako `uzyj(*p)`, jeśli `p` nie jest pusty.
- `void uzyj(T* obiekt)` — niewłaścicielski dostęp, gdy dopuszczamy również `nullptr`; można przekazać `p.get()`. Taki adres nie może być używany po zniszczeniu zarządzanego obiektu.
- `std::unique_ptr<T>&` — gdy funkcja ma zmienić sam wskaźnik, np. zastąpić jego obiekt.

Funkcja tworząca obiekt może zwrócić `std::unique_ptr<T>` przez wartość, przekazując własność wywołującemu. Tak działa `utworzPowiadomienie()` w przykładzie z pliku [fabryka.md](fabryka.md). Gdy wskaźnik do klasy bazowej zarządza obiektem klasy pochodnej, klasa bazowa powinna mieć publiczny wirtualny destruktor, aby usuwanie przez ten interfejs było bezpieczne.

## Przydatne operacje

- `p.get()` zwraca zwykły, niewłaścicielski wskaźnik; nie przekazuje własności.
- `p.reset()` usuwa obecnie zarządzany obiekt i pozostawia `p` pusty. `p.reset(adres)` zamiast tego przejmuje wskazany obiekt; adres musi być odpowiedni do sposobu usuwania i nie może być już zarządzany przez innego właściciela.
- `p.release()` oddaje adres i pozostawia `p` pusty, **nie usuwając** obiektu. Odpowiedzialność za jego zwolnienie przechodzi na wywołującego. Używaj tej operacji tylko przy świadomym przekazywaniu własności, np. do starszego API.
- `if (p)` sprawdza, czy wskaźnik nie jest pusty.

Do dynamicznej tablicy istnieje `std::unique_ptr<T[]>`, który używa `delete[]`; od C++14 można ją utworzyć przez `std::make_unique<T[]>(rozmiar)`. Nie przechowuje ona jednak rozmiaru. W większości zastosowań wygodniejszy będzie `std::vector<T>`, który zarządza pamięcią i zna swój rozmiar.

## Kiedy używać?

Jeżeli obiekt może mieć zwykły lokalny czas życia, najprościej utworzyć go bezpośrednio, np. `int liczba = 42`. `unique_ptr` przydaje się, gdy potrzebna jest dynamiczna alokacja i jeden wyraźny właściciel, np. przy polimorfizmie lub zwracaniu obiektu z fabryki. Gdy własność ma być rzeczywiście współdzielona, można rozważyć `std::shared_ptr`; nie jest on zamiennikiem koniecznym dla każdego wskaźnika.
