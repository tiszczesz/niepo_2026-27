# Dodawanie obrazka do aplikacji WPF

W WPF można dodać obrazek na dwa sposoby:

1. **Z poziomu designera** – przez kontrolkę `Image`.
2. **Z poziomu kodu C#** – ustawiając źródło obrazu w kodzie.

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

## 4. Wskazówki

- Dla obrazków w projekcie najlepiej używać `Resource`.
- Do prostego podglądu w designerze wystarczy ścieżka względna.
- Dla obrazków z dysku pamiętaj o poprawnej ścieżce i uprawnieniach.

## 5. Podsumowanie

W WPF obrazek możesz dodać zarówno w XAML, jak i w C#. Najwygodniejsze jest użycie zasobów projektu oraz kontrolki `Image`.
