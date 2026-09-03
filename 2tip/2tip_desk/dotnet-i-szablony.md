# .NET CLI i szablony `dotnet new`

Ten przewodnik opisuje najważniejsze polecenia interfejsu wiersza poleceń
(.NET CLI), ze szczególnym uwzględnieniem wyszukiwania, instalowania i używania
szablonów. Przykłady można uruchamiać w PowerShellu, Bashu oraz w terminalu
Visual Studio Code.

## 1. Przygotowanie środowiska

### SDK a Runtime

Do tworzenia projektów potrzebny jest **.NET SDK**. SDK zawiera między innymi:

- runtime .NET,
- kompilator i narzędzia MSBuild,
- narzędzie `dotnet`,
- wbudowane szablony projektów i plików.

Sam **.NET Runtime** wystarcza do uruchamiania gotowych aplikacji, ale nie
udostępnia pełnego zestawu poleceń potrzebnych do ich tworzenia i budowania.

Po instalacji SDK sprawdź środowisko:

```bash
dotnet --version
dotnet --info
dotnet --list-sdks
dotnet --list-runtimes
```

`dotnet --version` zwraca wersję SDK używaną w bieżącym katalogu.
`dotnet --info` pokazuje również system operacyjny, architekturę, ścieżki
instalacji i aktywne mechanizmy rozwiązywania wersji.

Jeżeli repozytorium zawiera plik `global.json`, jego ustawienia mogą wymusić
konkretne SDK:

```json
{
  "sdk": {
    "version": "10.0.100",
    "rollForward": "latestPatch"
  }
}
```

Wartość `version` musi odpowiadać SDK zainstalowanemu na komputerze (albo być
obsługiwana przez ustawienie `rollForward`). Brak wymaganego SDK powoduje błąd
już przy wykonywaniu poleceń takich jak `dotnet build` lub `dotnet new`.

## 2. Podstawy .NET CLI

Ogólna składnia polecenia to:

```text
dotnet <polecenie> [opcje] [argumenty]
```

Przykładowe polecenia używane w codziennej pracy:

| Polecenie | Zastosowanie |
| --- | --- |
| `dotnet restore` | Pobiera zależności NuGet. |
| `dotnet build` | Kompiluje projekt lub rozwiązanie. |
| `dotnet run` | Buduje (jeśli trzeba) i uruchamia aplikację. |
| `dotnet test` | Buduje i uruchamia testy. |
| `dotnet publish` | Przygotowuje pliki do wdrożenia. |
| `dotnet add package` | Dodaje pakiet NuGet do projektu. |
| `dotnet sln` | Zarządza projektami w rozwiązaniu. |
| `dotnet tool` | Instaluje i uruchamia narzędzia CLI. |
| `dotnet workload` | Zarządza dodatkowymi workloadami SDK. |

Pomoc jest dostępna na kilku poziomach:

```bash
dotnet --help
dotnet new --help
dotnet new list --help
dotnet new webapi --help
```

Polecenia można wykonywać z innego katalogu za pomocą `--project`, `--solution`
lub `--output`, zależnie od obsługi danej komendy. Najprostszym sposobem
uniknięcia niejednoznaczności jest przejście do katalogu projektu przed
uruchomieniem `restore`, `build`, `run` albo `test`.

## 3. Czym jest szablon .NET?

Szablon to opis plików, katalogów i parametrów używanych do wygenerowania
projektu lub pojedynczego pliku. Szablon ma co najmniej:

- **nazwę (template name)**, używaną po `dotnet new`,
- **krótki opis**,
- **krótkie nazwy (short name/alias)**, na przykład `console`, `classlib`,
  `webapi` lub `xunit`,
- zestaw parametrów, takich jak framework, język, typ uwierzytelniania czy
  włączenie kontenerów.

Szablony dostarczane z SDK są dostępne od razu. Dodatkowe szablony mogą być
pakietami NuGet albo lokalnymi pakietami `.nupkg`.

## 4. Lista dostępnych szablonów

W aktualnych wersjach SDK używaj podkomendy `list`:

```bash
dotnet new list
```

Wyświetla ona tabelę zawierającą zwykle nazwę, krótki alias, język i typ
szablonu. Starsza forma `dotnet new --list` może być spotykana w dokumentacji
dla wcześniejszych SDK; `dotnet new list` jest czytelniejszą i zalecaną formą
dla współczesnego CLI.

### Filtrowanie listy

Przekazanie tekstu do `list` ogranicza wyniki do pasujących szablonów:

```bash
dotnet new list web
dotnet new list test
dotnet new list --language C#
dotnet new list --type project
```

Najpierw sprawdź pomoc konkretnej wersji SDK, jeśli chcesz łączyć filtry:

```bash
dotnet new list --help
```

Przykładowe wbudowane szablony (ich dokładny zestaw zależy od wersji SDK):

| Alias | Typowy rezultat |
| --- | --- |
| `console` | Aplikacja konsolowa. |
| `classlib` | Biblioteka klas. |
| `web` | Minimalna aplikacja ASP.NET Core. |
| `webapi` | API ASP.NET Core. |
| `mvc` | Aplikacja ASP.NET Core MVC. |
| `razor` | Aplikacja Razor Pages. |
| `blazor` | Aplikacja Blazor. |
| `worker` | Usługa typu Worker. |
| `xunit` | Projekt testów xUnit. |
| `nunit` | Projekt testów NUnit. |
| `mstest` | Projekt testów MSTest. |
| `globaljson` | Plik `global.json`. |
| `gitignore` | Plik `.gitignore` dla .NET. |

Nie zakładaj, że każdy alias jest dostępny w każdym SDK. Zawsze traktuj wynik
`dotnet new list` jako źródło prawdy dla konkretnej instalacji.

## 5. Wyszukiwanie, instalowanie i aktualizowanie szablonów

### Wyszukiwanie w katalogu szablonów

Podkomenda `search` szuka szablonów w skonfigurowanych źródłach:

```bash
dotnet new search aspire
dotnet new search "clean architecture"
```

Wyniki mogą wymagać dostępu do sieci. Wyszukiwanie nie instaluje szablonu.
Przed instalacją sprawdź nazwę pakietu, autora i wersję.

### Instalowanie pakietu szablonów

Pakiet z NuGet instaluje się poleceniem:

```bash
dotnet new install Microsoft.DotNet.Web.ProjectTemplates.10.0
dotnet new install <nazwa-pakietu>
dotnet new install <nazwa-pakietu>::<wersja>
```

Można także wskazać lokalny pakiet:

```bash
dotnet new install .\templates\My.Templates.1.0.0.nupkg
```

Po instalacji sprawdź, czy alias pojawił się na liście:

```bash
dotnet new list
```

Instalacja jest zwykle globalna dla bieżącego profilu użytkownika, a nie dla
jednego repozytorium. Z tego powodu w zespole należy zapisać wymaganą nazwę i
wersję pakietu w dokumentacji lub skrypcie przygotowującym środowisko.

### Zarządzanie zainstalowanymi pakietami

```bash
dotnet new uninstall
dotnet new update
dotnet new update --check-only
dotnet new uninstall <nazwa-pakietu-lub-ścieżka>
```

`uninstall` bez argumentów wyświetla listę pakietów i pozwala ustalić właściwy
identyfikator. Nie usuwaj pakietu tylko na podstawie aliasu szablonu, ponieważ
jeden pakiet może dostarczać wiele aliasów.

## 6. Tworzenie projektu za pomocą `dotnet new`

### Minimalny przykład

```bash
mkdir MojaAplikacja
cd MojaAplikacja
dotnet new console
dotnet run
```

Jeżeli katalog docelowy jest pusty, `dotnet new console` tworzy w nim plik
projektu i kod startowy. Nazwę projektu można jawnie podać parametrem `--name`:

```bash
dotnet new console --name Kalkulator
```

### Tworzenie projektu w wybranym katalogu

```bash
dotnet new webapi --name Catalog.Api --output .\src\Catalog.Api
```

`--output` określa katalog wyjściowy, a `--name` nazwę projektu i domyślną
przestrzeń nazw. Katalog wyjściowy powinien być pusty albo należy świadomie
użyć opcji pozwalającej na nadpisanie plików.

### Wybór frameworka, języka i opcji

Najpierw wyświetl parametry konkretnego szablonu:

```bash
dotnet new webapi --help
dotnet new blazor --help
```

Typowe parametry wyglądają następująco:

```bash
dotnet new classlib --name Shared --framework net10.0
dotnet new console --language F#
dotnet new webapi --name Orders.Api --auth Individual
```

Nie każdy szablon obsługuje te same opcje. Wartości parametrów są wrażliwe na
wersję szablonu; używaj dokładnie nazw pokazanych przez `--help`.

### Generowanie rozwiązania z kilkoma projektami

Przykładowa struktura:

```text
Sklep/
  Sklep.slnx
  src/
    Sklep.Api/
    Sklep.Core/
  tests/
    Sklep.Tests/
```

Polecenia tworzące taką strukturę:

```bash
mkdir Sklep
cd Sklep
dotnet new sln --name Sklep
dotnet new webapi --name Sklep.Api --output .\src\Sklep.Api
dotnet new classlib --name Sklep.Core --output .\src\Sklep.Core
dotnet new xunit --name Sklep.Tests --output .\tests\Sklep.Tests
dotnet sln add .\src\Sklep.Api\Sklep.Api.csproj
dotnet sln add .\src\Sklep.Core\Sklep.Core.csproj
dotnet sln add .\tests\Sklep.Tests\Sklep.Tests.csproj
dotnet add .\src\Sklep.Api\Sklep.Api.csproj reference .\src\Sklep.Core\Sklep.Core.csproj
dotnet add .\tests\Sklep.Tests\Sklep.Tests.csproj reference .\src\Sklep.Core\Sklep.Core.csproj
dotnet restore
dotnet build
dotnet test
```

W nowszych SDK rozwiązanie może mieć rozszerzenie `.slnx`; nie należy mieszać
go z `.sln` bez sprawdzenia, jaką formę obsługuje używana wersja narzędzi.

## 7. Nadpisywanie plików i bezpieczeństwo pracy

Domyślnie generator chroni istniejące pliki i może zgłosić konflikt. Przed
użyciem `--force` sprawdź różnice w repozytorium:

```bash
git status
dotnet new gitignore --force
```

`--force` może zastąpić pliki bez możliwości odzyskania ich treści z generatora.
Nie używaj go w katalogu zawierającym kod bez kopii zapasowej lub kontroli
wersji. Warto również uruchamiać generator w nowym katalogu i dopiero potem
przenosić potrzebne pliki.

## 8. Typowy przepływ pracy

1. Zainstaluj wymagane SDK i sprawdź `dotnet --info`.
2. Wybierz wersję przez `global.json`, jeśli repozytorium jej wymaga.
3. Uruchom `dotnet new list` i wybierz szablon.
4. Sprawdź parametry przez `dotnet new <alias> --help`.
5. Wygeneruj projekt w pustym katalogu za pomocą `--output`.
6. Dodaj projekt do rozwiązania i skonfiguruj referencje.
7. Uruchom `dotnet restore`, `dotnet build` oraz `dotnet test`.
8. Sprawdź zmiany w `git diff` i dopiero wtedy dodaj je do repozytorium.

## 9. Rozwiązywanie problemów

### „No templates found matching”

Sprawdź alias i listę szablonów:

```bash
dotnet new list
dotnet new search <fraza>
```

Jeśli szablon jest zewnętrzny, zainstaluj jego pakiet ponownie i zweryfikuj
wynik poleceniem `dotnet new uninstall`.

### Używane jest inne SDK niż oczekiwane

Uruchom `dotnet --version` w katalogu projektu i sprawdź `global.json`.
Pamiętaj, że terminal uruchomiony przed instalacją SDK może mieć nieaktualny
stan środowiska; otwarcie nowego terminala często rozwiązuje ten problem.

### Konflikt plików przy generowaniu

Użyj nowego katalogu albo usuń tylko pliki utworzone przez nieudaną próbę.
`--force` stosuj dopiero po sprawdzeniu `git diff` i upewnieniu się, że
nadpisanie jest zamierzone.

### Projekt nie buduje się po wygenerowaniu

Wykonaj polecenia osobno, aby rozróżnić problem z zależnościami, kompilacją
i testami:

```bash
dotnet restore
dotnet build --no-restore
dotnet test --no-build
```

Następnie sprawdź wersję frameworka w pliku `.csproj`, zainstalowane SDK oraz
komunikat pierwszego błędu. Kolejne błędy często są tylko konsekwencją tego
samego problemu.

## 10. Przydatne polecenia — ściągawka

```bash
# Informacje o środowisku
dotnet --info

# Lista, wyszukiwanie i pomoc dla szablonów
dotnet new list
dotnet new search <fraza>
dotnet new --help

# Instalacja i aktualizacja
dotnet new install <pakiet>
dotnet new update
dotnet new uninstall

# Generowanie
dotnet new console --name App --output .\src\App
dotnet new classlib --name Domain --output .\src\Domain
dotnet new xunit --name App.Tests --output .\tests\App.Tests

# Walidacja
dotnet restore
dotnet build
dotnet test
dotnet run --project .\src\App\App.csproj
```

