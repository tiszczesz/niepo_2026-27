# Wzorce projektowe — wprowadzenie

## Czym są wzorce projektowe?

Wzorzec projektowy to sprawdzony, wielokrotnie stosowany sposób rozwiązania typowego problemu w projekcie oprogramowania. Nie jest gotowym fragmentem kodu ani obowiązkowym przepisem — opisuje pomysł, role współpracujących elementów i sytuację, w której rozwiązanie może być przydatne.

Wzorce pomagają porządkować kod, ograniczać zależności i ułatwiać jego rozwijanie. Zastosowane bez potrzeby mogą jednak niepotrzebnie zwiększyć liczbę klas i poziom skomplikowania. Najpierw należy zrozumieć problem, a dopiero potem zdecydować, czy wzorzec rzeczywiście pomaga.

## Podział wzorców

Klasyczny katalog wzorców opisany przez tzw. Gang of Four (GoF) dzieli je na trzy grupy:

1. **Kreacyjne** — dotyczą tworzenia obiektów. Oddzielają sposób tworzenia od kodu, który z obiektów korzysta.
2. **Strukturalne** — opisują, jak łączyć klasy i obiekty w większe, łatwiejsze w użyciu struktury.
3. **Czynnościowe (behawioralne)** — dotyczą komunikacji i podziału odpowiedzialności między obiektami.

## Podstawowe wzorce

### Wzorce kreacyjne

#### Fabryka (Factory Method)

**Problem:** kod klienta musi tworzyć obiekty, ale nie powinien być ściśle związany z konkretnymi klasami.

**Rozwiązanie:** tworzenie obiektu zostaje przekazane metodzie lub osobnemu komponentowi, który wybiera właściwy typ.

**Zastosowanie:** tworzenie różnych rodzajów powiadomień (e-mail, SMS), parserów plików lub połączeń z usługami zależnie od konfiguracji. Fabryka jest przydatna, gdy wybór konkretnej implementacji zmienia się lub zależy od danych wejściowych.

#### Budowniczy (Builder)

**Problem:** obiekt ma wiele opcjonalnych ustawień albo jego utworzenie wymaga kilku czytelnych kroków.

**Rozwiązanie:** budowniczy pozwala konfigurować obiekt etapami, a na końcu go tworzy.

**Zastosowanie:** konstruowanie złożonego zapytania, raportu lub konfiguracji. Dzięki temu unika się długich konstruktorów z wieloma argumentami pozycyjnymi.

#### Singleton

**Problem:** w aplikacji ma istnieć tylko jedna współdzielona instancja danego elementu.

**Rozwiązanie:** klasa lub moduł kontroluje tworzenie instancji i udostępnia jeden wspólny punkt dostępu.

**Zastosowanie:** czasem przydatny dla zasobu, który rzeczywiście powinien mieć jeden właścicielski obiekt, np. koordynatora dostępu do urządzenia. Należy stosować go ostrożnie: ukryty globalny stan utrudnia testowanie, kontrolę zależności i pracę równoległą. Często lepiej utworzyć obiekt raz i przekazywać go tam, gdzie jest potrzebny.

### Wzorce strukturalne

#### Adapter

**Problem:** dwa elementy mają niezgodne interfejsy i nie mogą bezpośrednio ze sobą współpracować.

**Rozwiązanie:** adapter udostępnia oczekiwany interfejs, tłumacząc wywołania na interfejs istniejącego elementu.

**Zastosowanie:** użycie zewnętrznej biblioteki płatniczej w aplikacji, która oczekuje własnego, ujednoliconego interfejsu. Adapter może też ułatwić zastąpienie jednej biblioteki inną.

#### Dekorator (Decorator)

**Problem:** chcemy dodać obiektowi zachowanie bez zmiany jego klasy i bez tworzenia wielu podklas dla każdej kombinacji funkcji.

**Rozwiązanie:** dekorator opakowuje obiekt o tym samym interfejsie i rozszerza jego działanie.

**Zastosowanie:** dodanie buforowania, logowania lub kompresji do komponentu obsługującego dane. Dekoratory można łączyć, dobierając potrzebne funkcje.

#### Fasada (Facade)

**Problem:** korzystanie z rozbudowanego podsystemu wymaga znajomości wielu klas i szczegółów ich współpracy.

**Rozwiązanie:** fasada udostępnia prosty interfejs, który koordynuje działanie podsystemu.

**Zastosowanie:** jedna metoda `uruchomRaport()` może kolejno pobrać dane, przetworzyć je i zapisać wynik, ukrywając szczegóły tych operacji przed kodem wywołującym.

### Wzorce czynnościowe

#### Strategia (Strategy)

**Problem:** ten sam cel można osiągnąć na kilka sposobów, a rozbudowane instrukcje warunkowe utrudniają dodawanie i testowanie kolejnych wariantów.

**Rozwiązanie:** każdy wariant jest osobną, wymienną strategią o wspólnym interfejsie. Kod klienta korzysta z wybranej strategii, nie musząc znać jej szczegółów.

**Zastosowanie:** wybór algorytmu sortowania, sposobu naliczania rabatu lub metody dostawy zależnie od sytuacji.

```text
interfejs StrategiaDostawy:
    obliczKoszt(zamowienie)

StrategiaKurier:
    obliczKoszt(zamowienie) -> koszt kuriera

StrategiaPaczkomat:
    obliczKoszt(zamowienie) -> koszt paczkomatu

koszt = wybranaStrategia.obliczKoszt(zamowienie)
```

#### Obserwator (Observer)

**Problem:** kilka elementów powinno reagować na zmianę stanu innego elementu, ale nie powinny być ze sobą mocno powiązane.

**Rozwiązanie:** obserwatorzy zapisują się do obiektu publikującego zdarzenia. Gdy stan się zmienia, obiekt powiadamia zarejestrowanych odbiorców.

**Zastosowanie:** aktualizowanie widoków po zmianie danych, powiadamianie o zdarzeniach w aplikacji lub obsługa subskrypcji. Trzeba pamiętać o wyrejestrowywaniu obserwatorów, gdy przestają być potrzebni.

#### Stan (State)

**Problem:** zachowanie obiektu zależy od jego stanu, a liczne warunki `if` lub `switch` stają się trudne do utrzymania.

**Rozwiązanie:** zachowania dla poszczególnych stanów są wydzielone, a obiekt deleguje do aktualnego stanu obsługę operacji.

**Zastosowanie:** zamówienie, które może być nowe, opłacone, wysłane lub anulowane. Wzorzec pomaga jasno określić dozwolone działania i przejścia między stanami.

#### Metoda szablonowa (Template Method)

**Problem:** kilka klas wykonuje ten sam proces składający się z ustalonych kroków, ale niektóre kroki różnią się zależnie od klasy. Powielanie całego procesu utrudnia późniejsze zmiany i może prowadzić do niespójnego działania.

**Rozwiązanie:** klasa bazowa definiuje szkielet algorytmu w metodzie szablonowej, ustalając kolejność kroków. Wybrane kroki udostępnia jako metody, które klasy pochodne implementują lub nadpisują. Sam szkielet pozostaje wspólny, więc klasy pochodne nie zmieniają kolejności całego procesu.

**Zastosowanie:** generowanie raportów w różnych formatach — wspólna procedura pobiera dane, przygotowuje je, zapisuje wynik i sprząta zasoby, a podklasy dostarczają formatowanie właściwe dla CSV lub HTML.

```text
klasa GeneratorRaportu:
    metoda szablonowa generuj():
        dane = pobierzDane()
        tresc = sformatuj(dane)
        zapisz(tresc)

    abstrakcyjna metoda sformatuj(dane)

klasa GeneratorCSV dziedziczy po GeneratorRaportu:
    metoda sformatuj(dane) -> tekst CSV

klasa GeneratorHTML dziedziczy po GeneratorRaportu:
    metoda sformatuj(dane) -> dokument HTML
```

Metodę szablonową wybieraj, gdy kolejność procesu jest stała, a różnią się jego poszczególne kroki. W odróżnieniu od **Strategii**, która przekazuje wymienny algorytm przez kompozycję, metoda szablonowa opiera warianty na dziedziczeniu. Dziedziczenie może ograniczać elastyczność, dlatego przy zmiennym zestawie zachowań strategia bywa lepszym wyborem.

## Jak wybrać wzorzec?

- Gdy problem dotyczy **tworzenia obiektów**, rozważ wzorzec kreacyjny, np. fabrykę lub budowniczego.
- Gdy trzeba **dopasować interfejs albo uprościć współpracę komponentów**, rozważ adapter lub fasadę.
- Gdy problem dotyczy **zmiennego zachowania i komunikacji**, rozważ strategię, obserwatora, stan lub metodę szablonową.
- Wybieraj rozwiązanie proporcjonalne do problemu. Jeśli prosty warunek lub funkcja są czytelne i łatwe w zmianie, dodatkowy wzorzec nie jest konieczny.
- Sprawdź, czy wzorzec ogranicza zależności i ułatwia testowanie, zamiast tylko przenosić złożoność w inne miejsce.

## Podsumowanie

Wzorce projektowe dostarczają wspólnego języka do opisywania typowych rozwiązań. Fabryka, budowniczy i singleton dotyczą tworzenia; adapter, dekorator i fasada — struktury; strategia, obserwator, stan i metoda szablonowa — zachowań. Najważniejsze jest rozpoznanie problemu i dobranie najprostszego rozwiązania, które pozostaje czytelne i łatwe w utrzymaniu.
