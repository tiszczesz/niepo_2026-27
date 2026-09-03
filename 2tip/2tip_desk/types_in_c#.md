# Podstawowe typy w C#

Typ określa, jakie dane może przechowywać zmienna oraz jakie operacje można na
niej wykonywać. Zmienną deklarujemy według schematu:

```csharp
typ nazwaZmiennej = wartość;
```

Na przykład:

```csharp
int liczbaUczniow = 24;
string nazwaKlasy = "2TIP";
```

## Typy całkowite

Typy całkowite przechowują liczby bez części ułamkowej. Najczęściej używany jest
`int`.

| Typ     | Zakres w przybliżeniu        | Przykład                         |
| ------- | ---------------------------- | -------------------------------- |
| `byte`  | od 0 do 255                  | `byte procent = 100;`            |
| `short` | od -32 tys. do 32 tys.       | `short temperatura = -15;`       |
| `int`   | od -2,1 mld do 2,1 mld       | `int wynik = 1250;`              |
| `long`  | bardzo duże liczby całkowite | `long licznik = 9_000_000_000L;` |

Podkreślenie w liczbie poprawia czytelność i nie zmienia jej wartości.
Litera `L` oznacza literał typu `long`.

```csharp
int rok = 2026;
long odlegloscWMetrach = 384_400_000L;
Console.WriteLine(rok + 1);
```

## Typy zmiennoprzecinkowe i `decimal`

Służą do przechowywania liczb z częścią ułamkową.

| Typ       | Typowe zastosowanie                | Przykład                    |
| --------- | ---------------------------------- | --------------------------- |
| `float`   | dane wymagające mniejszej precyzji | `float wzrost = 1.75F;`     |
| `double`  | obliczenia ogólnego przeznaczenia  | `double pi = 3.1415926535;` |
| `decimal` | kwoty i obliczenia finansowe       | `decimal cena = 19.99m;`    |

Dla `float` używa się przyrostka `F`, a dla `decimal` przyrostka `m`.
W obliczeniach pieniężnych wybieraj `decimal`, ponieważ dokładniej zapisuje
liczby dziesiętne.

```csharp
double srednia = 4.75;
decimal cenaNetto = 99.99m;
decimal vat = cenaNetto * 0.23m;
Console.WriteLine(vat);
```

## `bool` i `char`

`bool` przechowuje jedną z dwóch wartości logicznych: `true` albo `false`.
`char` przechowuje pojedynczy znak zapisany w apostrofach.

```csharp
bool czyZalogowany = true;
char ocena = 'A';

if (czyZalogowany)
{
    Console.WriteLine("Uzytkownik jest zalogowany.");
}
```

## `string`

`string` przechowuje tekst, czyli ciąg znaków. Tekst zapisujemy w cudzysłowach.
Łączenie tekstu z wartościami można wykonać interpolacją: przed cudzysłowem
stawiamy znak `$`, a zmienne umieszczamy w nawiasach klamrowych.

```csharp
string imie = "Adam";
int punkty = 42;
string komunikat = $"{imie} ma {punkty} punkty.";

Console.WriteLine(komunikat);
```

## `DateTime`

`DateTime` reprezentuje datę i czas.

```csharp
DateTime teraz = DateTime.Now;
DateTime rozpoczecieRoku = new DateTime(2026, 9, 1);

Console.WriteLine(teraz);
Console.WriteLine(rozpoczecieRoku.ToString("yyyy-MM-dd"));
```

## Tablice

Tablica przechowuje wiele wartości tego samego typu. Indeksy zaczynają się od
zera.

```csharp
int[] oceny = { 3, 4, 5, 5 };
string[] dniTygodnia = { "Poniedzialek", "Wtorek", "Sroda" };

Console.WriteLine(oceny[0]); // 3
Console.WriteLine(dniTygodnia.Length); // 3
```

## `var` i `const`

`var` pozwala kompilatorowi wywnioskować typ na podstawie wartości początkowej.
Po deklaracji typ pozostaje stały.

```csharp
var liczba = 10;       // int
var tekst = "Czesc";  // string
// liczba = "dziesiec"; // blad kompilacji
```

`const` deklaruje stałą, której wartości nie można później zmienić.

```csharp
const int LiczbaMiesiecyWRoku = 12;
const double Pi = 3.1415926535;
```

## Typy nullable

Typ wartościowy, taki jak `int` lub `bool`, domyślnie zawsze musi mieć wartość.
Znak `?` pozwala dodatkowo przechowywać `null`, czyli brak wartości.

```csharp
int? numerSali = null;
bool? czyObecny = null;

numerSali = 12;

if (numerSali.HasValue)
{
    Console.WriteLine($"Sala: {numerSali.Value}");
}
```

Dla tekstu warto zaznaczać możliwość braku wartości jako `string?`:

```csharp
string? drugieImie = null;
```

## Konwersje typów

Konwersja niejawna działa wtedy, gdy nie grozi utrata danych. Konwersję jawną
zapisujemy w nawiasach przed wartością.

```csharp
int liczbaCalkowita = 10;
double liczbaRzeczywista = liczbaCalkowita; // konwersja niejawna

double cena = 12.99;
int cenaZaokraglonaWdol = (int)cena; // 12
```

Tekst można zamienić na liczbę metodą `int.Parse`, gdy mamy pewność, że tekst
jest prawidłowy. Bezpieczniejsza jest metoda `int.TryParse`.

```csharp
string dane = "123";

if (int.TryParse(dane, out int numer))
{
    Console.WriteLine(numer + 1);
}
else
{
    Console.WriteLine("To nie jest poprawna liczba calkowita.");
}
```

## Podsumowanie

W codziennym kodzie najczęściej spotkasz `int`, `double`, `decimal`, `bool`,
`char` i `string`. Dobieraj typ do danych: `int` dla liczników, `decimal` dla
kwot, `bool` dla odpowiedzi tak/nie, a `string` dla tekstu.
