# `filter_input()` i flagi `filter_var()`

Funkcje PHP `filter_var()` i `filter_input()` służą do filtrowania danych. Wybór
filtra określa, co ma być sprawdzane lub przekształcane, a **flagi** doprecyzowują
działanie tego filtra.

## `filter_var()` a `filter_input()`

`filter_var()` filtruje wartość przekazaną bezpośrednio jako argument:

```php
$email = filter_var($wartosc, FILTER_VALIDATE_EMAIL);
```

`filter_input()` pobiera wartość z zewnętrznego źródła, np. z żądania HTTP:

```php
$email = filter_input(INPUT_POST, 'email', FILTER_VALIDATE_EMAIL);
```

W obu funkcjach można używać tych samych filtrów i flag. `filter_input()` nie
zastępuje jednak `filter_var()` dla wartości, które kod już wcześniej pobrał lub
przetworzył.

## Składnia i łączenie flag

Flagi przekazuje się jako czwarty argument funkcji albo w tablicy opcji:

```php
$liczba = filter_var(
    '1e3',
    FILTER_VALIDATE_FLOAT,
    ['flags' => FILTER_FLAG_ALLOW_SCIENTIFIC]
);
```

Kilka flag łączy się operatorem bitowym `|`:

```php
$ip = filter_var(
    $wartosc,
    FILTER_VALIDATE_IP,
    FILTER_FLAG_IPV4 | FILTER_FLAG_NO_PRIV_RANGE
);
```

Można też użyć tablicy opcji:

```php
$ip = filter_var($wartosc, FILTER_VALIDATE_IP, [
    'flags' => FILTER_FLAG_IPV4 | FILTER_FLAG_NO_PRIV_RANGE,
]);
```

To, czy dana flaga ma zastosowanie, zależy od wybranego filtra. Flaga nie jest
samodzielnym filtrem i nie należy zakładać, że zadziała z każdym filtrem.

## Flagi walidujące

Walidacja zwraca przefiltrowaną wartość przy powodzeniu, a `false` przy błędzie.
Dlatego do sprawdzania wyniku używaj porównania ścisłego:

```php
$wiek = filter_var($wejscie, FILTER_VALIDATE_INT);

if ($wiek === false) {
    echo 'Nieprawidłowa liczba całkowita';
}
```

| Flaga | Filtr | Działanie |
|---|---|---|
| `FILTER_FLAG_ALLOW_OCTAL` | `FILTER_VALIDATE_INT` | Pozwala na zapis ósemkowy, np. `0755`. |
| `FILTER_FLAG_ALLOW_HEX` | `FILTER_VALIDATE_INT` | Pozwala na zapis szesnastkowy, np. `0x1A`. |
| `FILTER_FLAG_ALLOW_FRACTION` | `FILTER_VALIDATE_FLOAT` | Pozwala na część ułamkową. |
| `FILTER_FLAG_ALLOW_THOUSAND` | `FILTER_VALIDATE_FLOAT` | Pozwala na separator tysięcy (przecinek). |
| `FILTER_FLAG_ALLOW_SCIENTIFIC` | `FILTER_VALIDATE_FLOAT` | Pozwala na zapis wykładniczy, np. `1e3`. |
| `FILTER_FLAG_IPV4` | `FILTER_VALIDATE_IP` | Akceptuje tylko adresy IPv4. |
| `FILTER_FLAG_IPV6` | `FILTER_VALIDATE_IP` | Akceptuje tylko adresy IPv6. |
| `FILTER_FLAG_NO_PRIV_RANGE` | `FILTER_VALIDATE_IP` | Odrzuca prywatne zakresy adresów IP. |
| `FILTER_FLAG_NO_RES_RANGE` | `FILTER_VALIDATE_IP` | Odrzuca zarezerwowane zakresy adresów IP. |
| `FILTER_FLAG_GLOBAL_RANGE` | `FILTER_VALIDATE_IP` | Akceptuje wyłącznie globalne adresy unicast; dostępna w nowszych wersjach PHP. |
| `FILTER_FLAG_HOSTNAME` | `FILTER_VALIDATE_DOMAIN` | Wymaga, aby etykiety domeny spełniały reguły nazw hostów, np. nie zaczynały się od `-`. |
| `FILTER_FLAG_EMAIL_UNICODE` | `FILTER_VALIDATE_EMAIL` | Pozwala na znaki Unicode w części lokalnej adresu e-mail; dostępna od PHP 7.1. |
| `FILTER_FLAG_PATH_REQUIRED` | `FILTER_VALIDATE_URL` | Wymaga ścieżki w URL. |
| `FILTER_FLAG_QUERY_REQUIRED` | `FILTER_VALIDATE_URL` | Wymaga części zapytania w URL. |

Przykład: adres publiczny IPv4:

```php
$ip = filter_var(
    $wartosc,
    FILTER_VALIDATE_IP,
    FILTER_FLAG_IPV4 | FILTER_FLAG_NO_PRIV_RANGE | FILTER_FLAG_NO_RES_RANGE
);
```

Flagi adresu IP nie zastępują kontroli dostępu ani reguł sieciowych. Samo
sprawdzenie, że adres nie należy do zakresu prywatnego, nie dowodzi, że jest
osiągalny ani bezpieczny.

## Flagi sanitizujące

Sanityzacja może zmienić wejściowy tekst. Nie potwierdza jednak, że wartość ma
oczekiwany format.

| Flaga | Filtr | Działanie |
|---|---|---|
| `FILTER_FLAG_STRIP_LOW` | `FILTER_SANITIZE_STRING` (przestarzały), `FILTER_UNSAFE_RAW` | Usuwa znaki ASCII o kodach poniżej 32. |
| `FILTER_FLAG_STRIP_HIGH` | `FILTER_SANITIZE_STRING` (przestarzały), `FILTER_UNSAFE_RAW` | Usuwa znaki ASCII o kodach powyżej 127. |
| `FILTER_FLAG_ENCODE_LOW` | `FILTER_SANITIZE_STRING` (przestarzały), `FILTER_UNSAFE_RAW` | Koduje znaki ASCII o kodach poniżej 32. |
| `FILTER_FLAG_ENCODE_HIGH` | `FILTER_SANITIZE_STRING` (przestarzały), `FILTER_UNSAFE_RAW` | Koduje znaki ASCII o kodach powyżej 127. |
| `FILTER_FLAG_ENCODE_AMP` | `FILTER_SANITIZE_STRING` (przestarzały), `FILTER_UNSAFE_RAW` | Koduje znak `&`. |
| `FILTER_FLAG_NO_ENCODE_QUOTES` | `FILTER_SANITIZE_SPECIAL_CHARS` | Nie koduje cudzysłowów. |
| `FILTER_FLAG_STRIP_BACKTICK` | `FILTER_SANITIZE_STRING` (przestarzały), `FILTER_UNSAFE_RAW` | Usuwa znak odwrotnego apostrofu (`` ` ``); flaga jest przestarzała od PHP 8.1. |

`FILTER_SANITIZE_STRING` jest przestarzały od PHP 8.1.0. W nowym kodzie wybierz
sanityzację odpowiednią do kontekstu (np. kodowanie HTML przy wyświetlaniu) i
osobno waliduj dane. Nie polegaj na „oczyszczaniu” jako ochronie przed
wstrzyknięciami do SQL, HTML czy poleceń systemowych.

## Inne flagi i opcje, które warto znać

- `FILTER_FLAG_EMPTY_STRING_NULL` zamienia pusty ciąg na `null` (od PHP 8.1.0).
  Nie należy mylić go z `FILTER_NULL_ON_FAILURE`, który jest osobną opcją
  określającą wartość zwracaną przy błędzie walidacji.
- `FILTER_FLAG_NONE` oznacza brak dodatkowych flag.
- `FILTER_FLAG_SCHEME_REQUIRED` i `FILTER_FLAG_HOST_REQUIRED` są przestarzałe
  od PHP 7.3.0. To historyczne flagi filtra URL; sprawdzaj wymagania konkretnej
  wersji PHP i nie dodawaj ich do nowego kodu.
- Obsługa domen międzynarodowych (IDN) wymaga odrębnej obsługi konwersji domeny;
  nie jest tym samym co `FILTER_FLAG_EMAIL_UNICODE`.
- `FILTER_REQUIRE_ARRAY` i `FILTER_REQUIRE_SCALAR` to flagi określające
  oczekiwany kształt wartości wejściowej w rodzinie `filter_input_array()` /
  `filter_var_array()`. Nie zmieniają reguł walidacji adresu, liczby czy tekstu.

## Ważne: walidacja to nie sanityzacja

`FILTER_VALIDATE_*` odpowiada na pytanie „czy wartość spełnia reguły filtra?”.
`FILTER_SANITIZE_*` przekształca tekst. Samo przekształcenie nie gwarantuje, że
wynik jest poprawnym adresem e-mail, liczbą ani bezpieczną wartością dla
konkretnego kontekstu.

Przykład walidacji liczby z separatorem tysięcy i częścią ułamkową:

```php
$cena = filter_var(
    '1,234.50',
    FILTER_VALIDATE_FLOAT,
    FILTER_FLAG_ALLOW_THOUSAND | FILTER_FLAG_ALLOW_FRACTION
);

if ($cena === false) {
    echo 'Nieprawidłowa cena';
} else {
    echo $cena;
}
```

## Uwagi o wersji PHP

Dostępność i zachowanie niektórych filtrów oraz flag różnią się między
wersjami PHP. W szczególności część flag jest przestarzała, a niektóre pojawiły
się dopiero w nowszych wersjach. Sprawdź dokumentację wersji używanej w
projekcie, jeśli kod ma działać na wielu środowiskach.

Dokumentacja PHP:

- [Flagi filtrów](https://www.php.net/manual/en/filter.constants.php)
- [Filtry walidujące](https://www.php.net/manual/en/filter.filters.validate.php)
- [Filtry sanityzujące](https://www.php.net/manual/en/filter.filters.sanitize.php)
- [`filter_var()`](https://www.php.net/manual/en/function.filter-var.php)
- [`filter_input()`](https://www.php.net/manual/en/function.filter-input.php)
