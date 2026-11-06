# ASP.NET Core MVC – upload zdjęć do katalogu `images`

Tutorial krok po kroku: wysyłanie plików graficznych z formularza na serwer z użyciem modelu `Image(Id, Title, FileName, Description)`.

## Krok 1. Utworzenie projektu

```bash
dotnet new mvc -n ImageUpload
cd ImageUpload
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
```

## Krok 2. Model `Image`

`Models/Image.cs` – model zapisywany w bazie (w bazie trzymamy tylko **nazwę pliku**, nie sam plik).

```csharp
using System.ComponentModel.DataAnnotations;

namespace ImageUpload.Models;

public class Image
{
    public int Id { get; set; }

    [Required, StringLength(100)]
    public string Title { get; set; } = string.Empty;

    // nazwa pliku zapisanego w wwwroot/images
    public string FileName { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Description { get; set; }
}
```

## Krok 3. ViewModel do formularza

Plik (`IFormFile`) nie należy do modelu bazodanowego, dlatego tworzymy osobną klasę.

`Models/ImageCreateViewModel.cs`:

```csharp
using System.ComponentModel.DataAnnotations;

namespace ImageUpload.Models;

public class ImageCreateViewModel
{
    [Required(ErrorMessage = "Podaj tytuł")]
    [StringLength(100)]
    public string Title { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Wybierz plik")]
    public IFormFile File { get; set; } = null!;
}
```

## Krok 4. Kontekst bazy danych

`Data/AppDbContext.cs`:

```csharp
using ImageUpload.Models;
using Microsoft.EntityFrameworkCore;

namespace ImageUpload.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Image> Images => Set<Image>();
}
```

Rejestracja w `Program.cs` (przed `builder.Build()`):

```csharp
using ImageUpload.Data;
using Microsoft.EntityFrameworkCore;

builder.Services.AddDbContext<AppDbContext>(o =>
    o.UseSqlite("Data Source=images.db"));
```

Migracja:

```bash
dotnet tool install --global dotnet-ef
dotnet ef migrations add Init
dotnet ef database update
```

## Krok 5. Katalog `images`

Utwórz folder `wwwroot/images`. Wszystko w `wwwroot` jest serwowane statycznie
(`app.UseStaticFiles()` jest domyślnie w szablonie), więc plik będzie dostępny pod adresem `/images/nazwa.jpg`.

Aby folder trafił do repozytorium, dodaj pusty plik `wwwroot/images/.gitkeep`.

## Krok 6. Kontroler

`Controllers/ImagesController.cs`:

```csharp
using ImageUpload.Data;
using ImageUpload.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ImageUpload.Controllers;

public class ImagesController : Controller
{
    private static readonly string[] AllowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
    private const long MaxFileSize = 5 * 1024 * 1024; // 5 MB

    private readonly AppDbContext _db;
    private readonly IWebHostEnvironment _env;

    public ImagesController(AppDbContext db, IWebHostEnvironment env)
    {
        _db = db;
        _env = env;
    }

    // Lista zdjęć
    public async Task<IActionResult> Index()
        => View(await _db.Images.ToListAsync());

    // Formularz
    [HttpGet]
    public IActionResult Create() => View();

    // Odbiór formularza
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ImageCreateViewModel vm)
    {
        if (!ModelState.IsValid)
            return View(vm);

        var file = vm.File;

        // 1. walidacja rozmiaru
        if (file.Length == 0 || file.Length > MaxFileSize)
        {
            ModelState.AddModelError(nameof(vm.File), "Plik jest pusty lub większy niż 5 MB.");
            return View(vm);
        }

        // 2. walidacja rozszerzenia
        var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
        if (!AllowedExtensions.Contains(ext))
        {
            ModelState.AddModelError(nameof(vm.File), "Dozwolone formaty: jpg, png, gif, webp.");
            return View(vm);
        }

        // 3. unikalna nazwa (nigdy nie ufamy nazwie od użytkownika)
        var uniqueName = $"{Guid.NewGuid()}{ext}";
        var folder = Path.Combine(_env.WebRootPath, "images");
        Directory.CreateDirectory(folder);
        var fullPath = Path.Combine(folder, uniqueName);

        // 4. zapis pliku na dysku
        await using (var stream = new FileStream(fullPath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        // 5. zapis rekordu w bazie
        var image = new Image
        {
            Title = vm.Title,
            Description = vm.Description,
            FileName = uniqueName
        };
        _db.Images.Add(image);
        await _db.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    // Usuwanie (rekord + plik)
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var image = await _db.Images.FindAsync(id);
        if (image is null) return NotFound();

        var path = Path.Combine(_env.WebRootPath, "images", image.FileName);
        if (System.IO.File.Exists(path))
            System.IO.File.Delete(path);

        _db.Images.Remove(image);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
```

## Krok 6a. Wyjaśnienie kluczowych elementów

| Element | Znaczenie |
|---|---|
| `IFormFile` | reprezentuje plik przesłany w żądaniu `multipart/form-data` |
| `IWebHostEnvironment.WebRootPath` | fizyczna ścieżka do `wwwroot` |
| `Guid.NewGuid()` | unikalna nazwa – chroni przed nadpisaniem i atakami typu path traversal |
| `CopyToAsync` | asynchroniczny zapis strumienia na dysk |
| `[ValidateAntiForgeryToken]` | ochrona przed CSRF (token generuje `<form>` z tag helperem) |

## Krok 7. Widok formularza

`Views/Images/Create.cshtml`.
**Najważniejsze:** `enctype="multipart/form-data"` – bez tego plik nie zostanie wysłany.

```html
@model ImageUpload.Models.ImageCreateViewModel
@{
    ViewData["Title"] = "Dodaj zdjęcie";
}

<h1>Dodaj zdjęcie</h1>

<form asp-action="Create" method="post" enctype="multipart/form-data">
    <div asp-validation-summary="ModelOnly" class="text-danger"></div>

    <div class="mb-3">
        <label asp-for="Title" class="form-label"></label>
        <input asp-for="Title" class="form-control" />
        <span asp-validation-for="Title" class="text-danger"></span>
    </div>

    <div class="mb-3">
        <label asp-for="Description" class="form-label"></label>
        <textarea asp-for="Description" class="form-control"></textarea>
        <span asp-validation-for="Description" class="text-danger"></span>
    </div>

    <div class="mb-3">
        <label asp-for="File" class="form-label">Plik</label>
        <input asp-for="File" type="file" class="form-control" accept="image/*" />
        <span asp-validation-for="File" class="text-danger"></span>
    </div>

    <button type="submit" class="btn btn-primary">Wyślij</button>
    <a asp-action="Index" class="btn btn-secondary">Anuluj</a>
</form>

@section Scripts {
    <partial name="_ValidationScriptsPartial" />
}
```

## Krok 8. Widok listy

`Views/Images/Index.cshtml`:

```html
@model IEnumerable<ImageUpload.Models.Image>
@{
    ViewData["Title"] = "Galeria";
}

<h1>Galeria</h1>
<a asp-action="Create" class="btn btn-success mb-3">Dodaj zdjęcie</a>

<div class="row">
@foreach (var item in Model)
{
    <div class="col-md-4 mb-4">
        <div class="card">
            <img src="~/images/@item.FileName" class="card-img-top" alt="@item.Title" />
            <div class="card-body">
                <h5 class="card-title">@item.Title</h5>
                <p class="card-text">@item.Description</p>
                <form asp-action="Delete" asp-route-id="@item.Id" method="post">
                    <button class="btn btn-sm btn-danger">Usuń</button>
                </form>
            </div>
        </div>
    </div>
}
</div>
```

## Krok 9. Link w menu

W `Views/Shared/_Layout.cshtml` dodaj:

```html
<li class="nav-item">
    <a class="nav-link" asp-controller="Images" asp-action="Index">Galeria</a>
</li>
```

## Krok 10. Limity rozmiaru (opcjonalnie)

Domyślny limit pojedynczego żądania to ok. 28 MB (Kestrel). Aby ustawić własny limit dla akcji:

```csharp
[HttpPost, ValidateAntiForgeryToken]
[RequestSizeLimit(5 * 1024 * 1024)]
public async Task<IActionResult> Create(ImageCreateViewModel vm) { ... }
```

## Krok 11. Uruchomienie i test

```bash
dotnet run
```

1. Wejdź na `/Images/Create`.
2. Wpisz tytuł i opis, wybierz plik graficzny, kliknij **Wyślij**.
3. Sprawdź, że plik pojawił się w `wwwroot/images`, a rekord w tabeli `Images`.
4. Na `/Images` powinna być widoczna miniatura.

## Dobre praktyki bezpieczeństwa

- Nie używaj oryginalnej nazwy pliku do zapisu (`file.FileName`) – generuj własną.
- Waliduj rozszerzenie **i** rozmiar; w produkcji dodatkowo sprawdź sygnaturę pliku (magic bytes) lub typ MIME.
- Nie zapisuj uploadów poza `wwwroot`, jeśli mają być niepubliczne – serwuj je wtedy przez akcję kontrolera.
- Zawsze używaj `[ValidateAntiForgeryToken]` dla akcji POST.
- Rozważ ograniczenie dostępu (`[Authorize]`) do akcji `Create` i `Delete`.

## Najczęstsze problemy

| Problem | Przyczyna / rozwiązanie |
|---|---|
| `File` jest `null` | brak `enctype="multipart/form-data"` w `<form>` |
| Nazwa inputa nie pasuje | nazwa właściwości w ViewModelu musi być zgodna z `name` inputa (`File`) |
| Obraz nie wyświetla się | zły katalog – plik musi być w `wwwroot/images`, a `UseStaticFiles()` włączone |
| Błąd 404.13 / za duży plik | zwiększ limit `RequestSizeLimit` / `MaxRequestBodySize` |
