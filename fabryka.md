# Wzorzec Fabryka w C++

## Cel wzorca

Wzorzec **Fabryka** (Factory Method) oddziela tworzenie obiektu od kodu, który z niego korzysta. Zamiast samodzielnie wybierać i tworzyć konkretną klasę, kod klienta korzysta ze wspólnego interfejsu fabryki. Konkretne fabryki decydują, jaki obiekt utworzyć.

Dzięki temu łatwiej dodawać nowe rodzaje obiektów bez zmieniania kodu, który wykonuje na nich operacje. Przykładem może być aplikacja wysyłająca powiadomienia e-mailem lub SMS-em.

## Przykład w C++

Poniższy program pyta o rodzaj powiadomienia, tworzy odpowiednią fabrykę i wysyła wiadomość. Klasa `FabrykaPowiadomien` deklaruje metodę wytwórczą, a jej klasy pochodne tworzą konkretne powiadomienia.

```cpp
#include <iostream>
#include <memory>
#include <string>

class Powiadomienie {
public:
    virtual ~Powiadomienie() = default;
    virtual void wyslij(const std::string& wiadomosc) const = 0;
};

class Email : public Powiadomienie {
public:
    void wyslij(const std::string& wiadomosc) const override {
        std::cout << "Wysyłam e-mail: " << wiadomosc << '\n';
    }
};

class SMS : public Powiadomienie {
public:
    void wyslij(const std::string& wiadomosc) const override {
        std::cout << "Wysyłam SMS: " << wiadomosc << '\n';
    }
};

class FabrykaPowiadomien {
public:
    virtual ~FabrykaPowiadomien() = default;
    virtual std::unique_ptr<Powiadomienie> utworzPowiadomienie() const = 0;
};

class FabrykaEmail : public FabrykaPowiadomien {
public:
    std::unique_ptr<Powiadomienie> utworzPowiadomienie() const override {
        return std::make_unique<Email>();
    }
};

class FabrykaSMS : public FabrykaPowiadomien {
public:
    std::unique_ptr<Powiadomienie> utworzPowiadomienie() const override {
        return std::make_unique<SMS>();
    }
};

int main() {
    std::cout << "Wybierz rodzaj powiadomienia (email/sms): ";

    std::string typ;
    if (!(std::cin >> typ)) {
        std::cerr << "Nie udało się odczytać wyboru.\n";
        return 1;
    }

    std::unique_ptr<FabrykaPowiadomien> fabryka;
    if (typ == "email") {
        fabryka = std::make_unique<FabrykaEmail>();
    } else if (typ == "sms") {
        fabryka = std::make_unique<FabrykaSMS>();
    } else {
        std::cerr << "Nieznany rodzaj powiadomienia.\n";
        return 1;
    }

    std::unique_ptr<Powiadomienie> powiadomienie = fabryka->utworzPowiadomienie();
    powiadomienie->wyslij("Twoje zamówienie zostało przyjęte.");
}
```

Program można skompilować jako C++14 lub nowszy, na przykład:

```bash
g++ -std=c++14 -Wall -Wextra -pedantic fabryka.cpp -o fabryka
./fabryka
```

Przykładowe uruchomienie:

```text
Wybierz rodzaj powiadomienia (email/sms): email
Wysyłam e-mail: Twoje zamówienie zostało przyjęte.
```

## Jak działa przykład?

1. `Powiadomienie` określa wspólny interfejs dla wszystkich kanałów wysyłki.
2. `Email` i `SMS` implementują metodę `wyslij()` na różne sposoby.
3. `FabrykaPowiadomien` deklaruje metodę wytwórczą `utworzPowiadomienie()`.
4. `FabrykaEmail` i `FabrykaSMS` tworzą odpowiednie obiekty.
5. `main()` wybiera fabrykę. Dalej pracuje z obiektem przez interfejs `Powiadomienie`, nie musi więc znać jego konkretnej klasy.
6. `std::unique_ptr` automatycznie zarządza pamięcią. Wirtualne destruktory pozwalają bezpiecznie usuwać obiekty klas pochodnych przez wskaźnik do klasy bazowej.

## Dodanie nowego rodzaju powiadomienia

Aby dodać np. powiadomienia push, należy utworzyć klasę `Push`, która implementuje `Powiadomienie`, oraz `FabrykaPush`, która zwraca `std::make_unique<Push>()`. Następnie nowy wybór trzeba dodać w miejscu, w którym program wybiera fabrykę. Kod korzystający z gotowego powiadomienia nie wymaga zmian.

## Fabryka a prosta funkcja tworząca

Czasem wybór produktu jest niewielki i nie zmienia się często. Wtedy wystarczy prosta funkcja, która na podstawie parametru zwraca odpowiedni obiekt — często nazywana **prostą fabryką** (Simple Factory). Nie jest ona tym samym co wzorzec Factory Method z katalogu GoF. W pokazanym tutaj Factory Method tworzenie obiektu jest delegowane do klas fabryk, które można wymieniać lub rozszerzać.

## Kiedy stosować?

- Gdy kod nie powinien być zależny od konkretnych klas tworzonych obiektów.
- Gdy typ tworzonego obiektu zależy od konfiguracji lub kontekstu.
- Gdy przewidujemy dodawanie kolejnych implementacji wspólnego interfejsu.

Jeśli istnieje tylko jeden prosty typ obiektu i nie przewidujemy zmian, dodatkowe klasy fabryk mogą niepotrzebnie komplikować program. Warto stosować wzorzec wtedy, gdy rzeczywiście upraszcza rozszerzanie lub testowanie kodu.