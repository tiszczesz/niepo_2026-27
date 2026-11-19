# Razor Pages — od pustego projektu do pierwszej strony

Razor Pages to sposób tworzenia stron WWW w ASP.NET Core. Strona łączy HTML ze składnią Razor (`@`), a jej logika może znajdować się w osobnej klasie C#.

## 1. Przygotuj środowisko

Zainstaluj .NET SDK i sprawdź w terminalu, czy jest dostępne:

```bash
dotnet --version
```

Wystarczy .NET SDK 8 lub nowsze. Do edycji plików możesz użyć np. Visual Studio Code.

## 2. Utwórz pustą aplikację WWW

W wybranym katalogu wykonaj:

```bash
dotnet new web -n RazorStart
cd RazorStart
```

Szablon `web` tworzy pustą aplikację ASP.NET Core, a nie gotowy projekt Razor Pages. Konfigurację i strony dodamy samodzielnie. Nazwa `RazorStart` jest istotna dla przestrzeni nazw użytej w przykładzie.

## 3. Włącz Razor Pages

Zastąp zawartość pliku `Program.cs`:

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var app = builder.Build();

app.MapRazorPages();

app.Run();
```

- `AddRazorPages()` rejestruje usługi potrzebne do obsługi Razor Pages.
- `MapRazorPages()` udostępnia strony jako adresy aplikacji.
- `app.Run()` uruchamia serwer.

Usuwamy przykładowe `MapGet("/")` z szablonu: adres `/` będzie obsługiwany przez stronę `Pages/Index.cshtml`.

## 4. Dodaj stronę główną

W katalogu projektu utwórz folder `Pages`, a w nim plik `Index.cshtml`:

```cshtml
@page
@model RazorStart.Pages.IndexModel
<!DOCTYPE html>
<html lang="pl">
<head>
    <meta charset="utf-8" />
    <title>Powitanie</title>
</head>
<body>
    <h1>Moja pierwsza strona Razor</h1>

    <form method="get">
        <label for="imie">Podaj imię:</label>
        <input id="imie" name="imie" value="@Model.Imie" />
        <button type="submit">Przywitaj</button>
    </form>

    @if (!string.IsNullOrWhiteSpace(Model.Imie))
    {
        <p>Cześć, @Model.Imie!</p>
    }

    <a href="/OProgramie">O programie</a>
</body>
</html>
```

- `@page` oznacza, że plik jest stroną dostępną pod adresem WWW. `Index.cshtml` w folderze `Pages` obsługuje adres `/`.
- `@model` wskazuje klasę z logiką strony. `@Model.Imie` odczytuje jej właściwość.
- Formularz wysyła imię metodą GET, np. jako `/?imie=Ala`. Razor koduje wartość wyświetlaną w HTML, zamiast traktować ją jako kod HTML.

## 5. Dodaj logikę strony

Obok `Index.cshtml` utwórz plik `Index.cshtml.cs`:

```csharp
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorStart.Pages;

public class IndexModel : PageModel
{
    public string? Imie { get; private set; }

    public void OnGet(string? imie)
    {
        Imie = imie;
    }
}
```

Przy żądaniu GET metoda `OnGet` otrzymuje wartość parametru `imie` z adresu i zapisuje ją we właściwości dostępnej w widoku. Znak `?` oznacza, że imienia może nie być — na przykład podczas pierwszego wejścia na stronę.

## 6. Dodaj drugą stronę

Utwórz plik `Pages/OProgramie.cshtml`:

```cshtml
@page
<!DOCTYPE html>
<html lang="pl">
<head>
    <meta charset="utf-8" />
    <title>O programie</title>
</head>
<body>
    <h1>O programie</h1>
    <p>To prosta aplikacja Razor Pages.</p>
    <a href="/">Wróć do strony głównej</a>
</body>
</html>
```

Ta strona nie potrzebuje osobnej klasy `PageModel`, ponieważ zawiera tylko statyczną treść. Będzie dostępna pod adresem `/OProgramie`.

## 7. Sprawdź strukturę projektu

```text
RazorStart/
├── Pages/
│   ├── Index.cshtml
│   ├── Index.cshtml.cs
│   └── OProgramie.cshtml
├── Program.cs
├── RazorStart.csproj
└── ... pliki utworzone przez szablon
```

Nie zmieniaj wygenerowanego pliku `RazorStart.csproj` — szablon `web` ma już konfigurację potrzebną do tego przykładu.

## 8. Uruchom i sprawdź aplikację

W katalogu `RazorStart` wykonaj:

```bash
dotnet run
```

Otwórz w przeglądarce adres HTTP wyświetlony w terminalu przy `Now listening on:`, np. `http://localhost:5000` — numer portu może być inny.

1. Na stronie głównej wpisz `Ala` i kliknij **Przywitaj**. Powinien pojawić się napis `Cześć, Ala!`.
2. Kliknij **O programie**, a następnie wróć na stronę główną.
3. Zatrzymaj aplikację w terminalu skrótem `Ctrl+C`.

Imię znajduje się w adresie, ponieważ formularz używa GET; nie wpisuj tam danych poufnych. Aplikacja nie zapisuje imienia na stałe.
