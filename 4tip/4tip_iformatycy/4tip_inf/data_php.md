# Obsługa daty w PHP

PHP ma dość rozbudowany zestaw narzędzi do pracy z datą i czasem. Warto znać zarówno funkcje „klasyczne” (`date()`, `strtotime()`), jak i nowocześniejsze obiekty `DateTime` oraz `DateTimeImmutable`.

## 1. Podstawowe informacje

W PHP data i czas są zwykle reprezentowane na trzy sposoby:

- jako znacznik czasu (timestamp): liczba sekund od 1 stycznia 1970 r. UTC
- jako ciąg znaków w określonym formacie (`Y-m-d H:i:s`)
- jako obiekt `DateTime` / `DateTimeImmutable`

### Znacznik czasu

```php
$timestamp = time();
echo $timestamp; // np. 1712312345
```

`time()` zwraca aktualny timestamp w sekundach.

## 2. Formatowanie daty

Najprostsza metoda to funkcja `date()`:

```php
$tekst = date('Y-m-d H:i:s');
echo $tekst; // np. 2026-09-24 14:35:10
```

Najczęstsze znaczniki:

- `Y` – rok, 4 cyfry
- `y` – rok, 2 cyfry
- `m` – miesiąc, 2 cyfry
- `d` – dzień, 2 cyfry
- `H` – godzina 24h
- `h` – godzina 12h
- `i` – minuty
- `s` – sekundy
- `F` – nazwa miesiąca
- `l` – nazwa dnia tygodnia

Przykłady:

```php
echo date('d-m-Y');      // 24-09-2026
echo date('l, d F Y');  // Wednesday, 24 September 2026
```

## 3. Tworzenie daty z łańcucha

Funkcja `strtotime()` pozwala zamienić tekst daty na timestamp:

```php
$timestamp = strtotime('2026-09-24 15:30:00');
echo date('Y-m-d H:i:s', $timestamp);
```

Można używać wielu form wyrażeń:

```php
strtotime('now');
strtotime('+1 day');
strtotime('+2 weeks');
strtotime('next Monday');
strtotime('2026-12-31 23:59:59');
```

Uwaga: `strtotime()` jest wygodne, ale bywa mniej czytelne i czasem niejednoznaczne dla różnych lokalizacji i języków.

## 4. Obiekt `DateTime`

Najbezpieczniejszym i najczytelniejszym sposobem pracy z datą jest klasa `DateTime`.

```php
$date = new DateTime('2026-09-24 15:30:00');
echo $date->format('Y-m-d H:i:s');
```

### Aktualny czas

```php
$now = new DateTime();
echo $now->format('Y-m-d H:i:s');
```

### Dodawanie i odejmowanie czasu

```php
$date = new DateTime('2026-09-24');
$date->modify('+1 day');
echo $date->format('Y-m-d');

$date->modify('-2 hours');
echo $date->format('Y-m-d H:i:s');
```

### Porównywanie dat

```php
$date1 = new DateTime('2026-09-24');
$date2 = new DateTime('2026-09-25');

if ($date1 < $date2) {
    echo 'Data 1 jest wcześniejsza.';
}
```

## 5. `DateTimeImmutable`

`DateTimeImmutable` działa podobnie do `DateTime`, ale nie modyfikuje istniejącego obiektu. Zamiast tego zwraca nowy obiekt po każdej operacji.

```php
$date = new DateTimeImmutable('2026-09-24');
$nowaData = $date->modify('+3 days');

echo $date->format('Y-m-d');   // 2026-09-24

echo $nowaData->format('Y-m-d'); // 2026-09-27
```

Jest to bezpieczniejsze przy pracy w większych projektach, ponieważ zmiany nie „nadpisują” danych.

## 6. Strefy czasowe

PHP obsługuje strefy czasowe za pomocą klasy `DateTimeZone`.

```php
$date = new DateTime('now', new DateTimeZone('Europe/Warsaw'));
echo $date->format('Y-m-d H:i:s P');
```

Wyjście może wyglądać tak:

```php
2026-09-24 15:30:00 +02:00
```

### Konwersja pomiędzy strefami

```php
$warsaw = new DateTimeZone('Europe/Warsaw');
$utc = new DateTimeZone('UTC');

$date = new DateTime('2026-09-24 12:00:00', $warsaw);
$date->setTimezone($utc);

echo $date->format('Y-m-d H:i:s P');
```

## 7. Różnice między datami

Można policzyć różnicę pomiędzy datami za pomocą `DateInterval`:

```php
$dataStart = new DateTime('2026-09-01');
$dataKoniec = new DateTime('2026-09-30');

$roznica = $dataStart->diff($dataKoniec);

echo $roznica->format('%a dni');
```

Wynik:

```php
29 dni
```

## 8. Praca z przedziałami czasu

`DateInterval` pozwala określić odstępy czasu:

```php
$interval = new DateInterval('P2W'); // 2 tygodnie

$date = new DateTime('2026-09-24');
$date->add($interval);

echo $date->format('Y-m-d');
```

Składnia `DateInterval`:

- `P1D` – 1 dzień
- `P2W` – 2 tygodnie
- `P1M` – 1 miesiąc
- `PT2H` – 2 godziny
- `P1Y2M3DT4H5M6S` – 1 rok, 2 miesiące, 3 dni, 4 godziny, 5 minut, 6 sekund

## 9. Iteracja po datach

`DatePeriod` pozwala przechodzić po kolejnych datach:

```php
$start = new DateTime('2026-09-01');
$end = new DateTime('2026-09-05');

$period = new DatePeriod($start, new DateInterval('P1D'), $end);

foreach ($period as $date) {
    echo $date->format('Y-m-d') . PHP_EOL;
}
```

## 10. Wartości null i niepoprawne daty

Przy parsowaniu użytkownika lub danych wejściowych warto sprawdzać poprawność:

```php
$date = DateTime::createFromFormat('d-m-Y', '24-09-2026');

if ($date && $date->format('d-m-Y') === '24-09-2026') {
    echo 'Data poprawna';
} else {
    echo 'Data niepoprawna';
}
```

`createFromFormat()` jest bardzo przydatne, gdy dane są zapisane w nietypowym formacie.

## 11. Rekomendacja praktyczna

W nowoczesnym PHP najczęściej warto stosować:

- `DateTimeImmutable` do obiektów daty
- `DateTimeZone` do pracy ze strefami czasowymi
- `format()` do wyświetlania w określonym formacie
- `modify()` lub `add()` / `sub()` do zmiany daty

Przykład:

```php
$date = new DateTimeImmutable('2026-09-24 13:00:00', new DateTimeZone('Europe/Warsaw'));
$date = $date->modify('+3 days')->setTimezone(new DateTimeZone('UTC'));

echo $date->format('Y-m-d H:i:s P');
```

## 12. Podsumowanie

PHP daje kilka warstw obsługi czasu:

- `date()` i `strtotime()` – szybkie i proste rozwiązania
- `DateTime` / `DateTimeImmutable` – bardziej przewidywalne i bezpieczne
- `DateTimeZone` – obsługa stref czasowych
- `DateInterval` i `DatePeriod` – operacje na przedzia��ach czasu

Dla większości aplikacji najbezpieczniej jest używać klasy `DateTimeImmutable`, ponieważ jest łatwiejsza do zrozumienia i mniej podatna na błędy przy modyfikacji danych.

## 13. Linki do dokumentacji

- https://www.php.net/manual/en/book.datetime.php
- https://www.php.net/manual/en/class.datetime.php
- https://www.php.net/manual/en/class.datetimeimmutable.php
- https://www.php.net/manual/en/function.date.php
- https://www.php.net/manual/en/function.strtotime.php

To wystarczy, aby skutecznie pracować z datą i czasem w PHP.
