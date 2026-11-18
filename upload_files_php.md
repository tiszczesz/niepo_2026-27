# Upload plików w czystym PHP

Przykład dla PHP 8+: formularz wysyła jeden plik, a serwer sprawdza jego
rozmiar, rozszerzenie i rzeczywisty typ MIME przed zapisaniem. Nie potrzeba
frameworka ani zewnętrznych bibliotek.

## 1. Formularz

Zapisz jako `public/index.php`. Atrybut `enctype` jest niezbędny — bez niego
plik nie trafi do `$_FILES`.

```html
<form action="" method="post" enctype="multipart/form-data">
    <label for="plik">Wybierz PDF lub obraz JPG/PNG (maks. 5 MB):</label>
    <input id="plik" name="plik" type="file" required>
    <button type="submit">Wyślij</button>
</form>
```

## 2. Obsługa i walidacja

Umieść poniższy kod na początku `public/index.php`, przed formularzem.
Katalog `private_uploads` powinien znajdować się poza katalogiem publicznym
serwera WWW.

```php
<?php
$komunikat = '';
$maxRozmiar = 5 * 1024 * 1024; // 5 MB
$dozwoloneTypy = [
    'pdf'  => 'application/pdf',
    'jpg'  => 'image/jpeg',
    'jpeg' => 'image/jpeg',
    'png'  => 'image/png',
];

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    if (!isset($_FILES['plik']) || !is_array($_FILES['plik'])) {
        $komunikat = 'Nie odebrano pliku.';
    } elseif ($_FILES['plik']['error'] !== UPLOAD_ERR_OK) {
        $komunikat = match ($_FILES['plik']['error']) {
            UPLOAD_ERR_INI_SIZE, UPLOAD_ERR_FORM_SIZE => 'Plik jest za duży.',
            UPLOAD_ERR_NO_FILE => 'Nie wybrano pliku.',
            default => 'Wystąpił błąd podczas wysyłania pliku.',
        };
    } elseif ($_FILES['plik']['size'] <= 0 || $_FILES['plik']['size'] > $maxRozmiar) {
        $komunikat = 'Plik jest pusty lub przekracza limit 5 MB.';
    } else {
        $plik = $_FILES['plik'];
        $rozszerzenie = strtolower(pathinfo($plik['name'], PATHINFO_EXTENSION));
        $finfo = new finfo(FILEINFO_MIME_TYPE);
        $mime = $finfo->file($plik['tmp_name']);

        // Sprawdzamy oba elementy — nazwa i nagłówek MIME od użytkownika nie są wiarygodne.
        if (!isset($dozwoloneTypy[$rozszerzenie]) || $dozwoloneTypy[$rozszerzenie] !== $mime) {
            $komunikat = 'Niedozwolony format pliku.';
        } else {
            $katalog = dirname(__DIR__) . '/private_uploads';

            if (!is_dir($katalog) && !mkdir($katalog, 0750, true) && !is_dir($katalog)) {
                error_log('Nie można utworzyć katalogu na uploady.');
                $komunikat = 'Nie udało się zapisać pliku.';
            } else {
                // Oryginalna nazwa nie jest używana: losowa nazwa zapobiega kolizjom i path traversal.
                $nazwa = bin2hex(random_bytes(16)) . '.' . $rozszerzenie;
                $sciezka = $katalog . '/' . $nazwa;

                if (move_uploaded_file($plik['tmp_name'], $sciezka)) {
                    $komunikat = 'Plik został zapisany.';
                } else {
                    error_log('Nie udało się przenieść przesłanego pliku.');
                    $komunikat = 'Nie udało się zapisać pliku.';
                }
            }
        }
    }
}
?>
```

Wyświetl komunikat bezpiecznie, kodując go dla HTML:

```php
<?php if ($komunikat !== ''): ?>
    <p><?= htmlspecialchars($komunikat, ENT_QUOTES, 'UTF-8') ?></p>
<?php endif; ?>
```

## Jak działa walidacja?

- `$_FILES['plik']['error']` informuje, czy PHP poprawnie odebrało plik.
- Rozmiar sprawdzamy po stronie serwera; `accept` w HTML nie zastępuje walidacji.
- `pathinfo()` pobiera rozszerzenie, a `finfo` rozpoznaje typ na podstawie zawartości.
- `move_uploaded_file()` przenosi wyłącznie plik przesłany przez PHP.
- `random_bytes()` tworzy nazwę niezależną od nazwy podanej przez użytkownika.

## Ważne w praktyce

- Sprawdź, czy `private_uploads` faktycznie jest poza `DocumentRoot` i czy PHP ma
  prawo do niego zapisywać. Pliki prywatne udostępniaj przez kontrolowany skrypt,
  a nie jako statyczne zasoby.
- Limit musi być zgodny z konfiguracją PHP (`upload_max_filesize` oraz
  `post_max_size` w `php.ini`). Jeśli żądanie przekroczy `post_max_size`,
  `$_FILES` może być puste.
- W produkcji dodaj uwierzytelnianie i ochronę CSRF, limity liczby uploadów oraz
  skanowanie plików, jeśli wymaga tego zastosowanie.
- Dozwolone MIME mogą zależeć od systemu; sprawdź wynik `finfo` dla formatów,
  które chcesz obsługiwać.
