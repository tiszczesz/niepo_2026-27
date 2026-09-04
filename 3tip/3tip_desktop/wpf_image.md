# Dodawanie obrazka do aplikacji WPF

W WPF można dodać obrazek na kilka sposobów:

1. **Z poziomu designera** – przez kontrolkę `Image`.
2. **Z poziomu kodu C#** – ustawiając źródło obrazu w kodzie.
3. **Z katalogu aplikacji** – np. z podfolderu `Images` obok pliku `.exe`.

## 1. Dodawanie obrazka w designerze

### Krok 1: Dodaj plik obrazu do projektu
Najczęściej tworzy się folder `Images` w projekcie i umieszcza tam plik, np. `logo.png`.

### Krok 2: Ustaw właściwości pliku
W Visual Studio kliknij plik obrazu i ustaw:
- **Build Action**: `Resource`
- **Copy to Output Directory**: `Do not copy` lub według potrzeb

### Krok 3: Użyj kontrolki `Image` w XAML

```xml
<Grid>
    <Image Source="Images/logo.png"
           Width="200"
           Height="200"
           Stretch="Uniform" />
</Grid>
```

Jeśli obrazek jest dodany jako zasób, możesz też użyć ścieżki z `pack://application:`.

```xml
<Image Source="pack://application:,,,/Images/logo.png"
       Width="200"
       Height="200"
       Stretch="Uniform" />
```

## 2. Dodawanie obrazka z poziomu kodu C#

### Przykład z `BitmapImage`

```csharp
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadImage();
        }

        private void LoadImage()
        {
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("pack://application:,,,/Images/logo.png", UriKind.Absolute);
            bitmap.EndInit();

            MyImage.Source = bitmap;
        }
    }
}
```

### XAML z nazwą kontrolki

```xml
<Window x:Class="WpfApp1.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="MainWindow" Height="350" Width="525">
    <Grid>
        <Image x:Name="MyImage"
               Width="200"
               Height="200"
               Stretch="Uniform" />
    </Grid>
</Window>
```

## 3. Przykład z obrazkiem z dysku

Jeśli obrazek ma być wczytany z pliku na dysku:

```csharp
private void LoadImageFromDisk()
{
    var bitmap = new BitmapImage();
    bitmap.BeginInit();
    bitmap.UriSource = new Uri(@"C:\Images\logo.png", UriKind.Absolute);
    bitmap.CacheOption = BitmapCacheOption.OnLoad;
    bitmap.EndInit();

    MyImage.Source = bitmap;
}
```

## 3a. Ładowanie obrazka z katalogu aplikacji (`Images`)

Jeśli plik obrazu znajduje się obok aplikacji, np. w `Images/logo.png` względem katalogu uruchomieniowego `.exe`, można wykryć ścieżkę dynamicznie:

```csharp
using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

private void LoadImageFromAppDirectory()
{
    // Katalog, z którego działa aplikacja (np. ...\bin\Debug\netX\)
    string appDirectory = AppDomain.CurrentDomain.BaseDirectory;

    // Ścieżka do obrazka w podkatalogu Images
    string imagePath = Path.Combine(appDirectory, "Images", "logo.png");

    if (!File.Exists(imagePath))
    {
        MessageBox.Show($"Nie znaleziono pliku: {imagePath}");
        return;
    }

    var bitmap = new BitmapImage();
    bitmap.BeginInit();
    bitmap.UriSource = new Uri(imagePath, UriKind.Absolute);
    bitmap.CacheOption = BitmapCacheOption.OnLoad;
    bitmap.EndInit();

    MyImage.Source = bitmap;
}
```

Możesz wywołać tę metodę np. w konstruktorze po `InitializeComponent()`:

```csharp
public MainWindow()
{
    InitializeComponent();
    LoadImageFromAppDirectory();
}
```

> Uwaga: aby plik był dostępny w katalogu uruchomieniowym, ustaw dla niego:
> - **Build Action**: `Content`
> - **Copy to Output Directory**: `Copy if newer` (lub `Copy always`)

## 4. Wskazówki

- Gdy obrazek jest częścią projektu i ma być osadzony w aplikacji, używaj:
  - **Build Action**: `Resource`
  - ładowanie przez `Source="Images/logo.png"` lub `pack://application:,,,/Images/logo.png`
- Gdy obrazek ma być plikiem obok aplikacji (np. `.\Images\logo.png`), używaj:
  - **Build Action**: `Content`
  - **Copy to Output Directory**: `Copy if newer` lub `Copy always`
  - ładowanie przez ścieżkę zbudowaną w C# na bazie `AppDomain.CurrentDomain.BaseDirectory`
- Do prostego podglądu w designerze zwykle wystarczy ścieżka względna.
- Przy ładowaniu z dysku zawsze sprawdzaj, czy plik istnieje (`File.Exists`) i czy aplikacja ma uprawnienia dostępu.

## 5. Podsumowanie

W WPF obrazek możesz dodać zarówno w XAML, jak i w C#. Najwygodniejsze jest użycie zasobów projektu oraz kontrolki `Image`.  
Jeśli obraz ma być podmienialny bez rekompilacji, dobrym wyborem jest trzymanie go w katalogu aplikacji (np. `Images`) i ładowanie dynamicznie po wykryciu ścieżki uruchomieniowej.
