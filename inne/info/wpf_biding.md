# Bindowanie danych w WPF

Binding (powiązanie danych) synchronizuje właściwość kontrolki z właściwością źródłową.

- `Mode=OneWay` - zmiana źródła odświeża kontrolkę.
- `Mode=TwoWay` - zmiana źródła odświeża kontrolkę, a zmiana w kontrolce aktualizuje źródło.
- Dla zmian widocznych w interfejsie klasa źródłowa powinna implementować `INotifyPropertyChanged`.
- Dla list, które mogą być zmieniane po wyświetleniu, używaj `ObservableCollection<T>`.

## 1. Między kontrolkami

### Jednostronne

Wartość `Slider` jest wyświetlana w `TextBlock`. Edycja tekstu nie zmienia suwaka.

```xml
<StackPanel Margin="20">
    <Slider x:Name="volumeSlider" Minimum="0" Maximum="100" Value="25" />
    <TextBlock Text="{Binding ElementName=volumeSlider, Path=Value,
                              Mode=OneWay, StringFormat=Głośność: {0:F0}}" />
</StackPanel>
```

### Dwustronne

`Slider` i `TextBox` pokazują oraz zmieniają tę samą wartość.

```xml
<StackPanel Margin="20">
    <Slider x:Name="quantitySlider" Minimum="1" Maximum="100" Value="10" />
    <TextBox Text="{Binding ElementName=quantitySlider, Path=Value,
                            Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" />
</StackPanel>
```

`UpdateSourceTrigger=PropertyChanged` powoduje aktualizację podczas wpisywania. Bez niego `TextBox.Text` zwykle aktualizuje źródło po utracie fokusu.

## 2. Kontrolka i zmienna (właściwość ViewModelu)

WPF nie binduje bezpośrednio do lokalnej zmiennej metody. Zmienna powinna być wystawiona jako publiczna właściwość obiektu ustawionego w `DataContext`.

```csharp
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class SettingsViewModel : INotifyPropertyChanged
{
    private string _userName = "Alicja";

    public string UserName
    {
        get => _userName;
        set
        {
            if (_userName == value) return;
            _userName = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
```

Ustawienie `DataContext` w oknie:

```csharp
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new SettingsViewModel();
    }
}
```

### Jednostronne

```xml
<TextBlock Text="{Binding UserName, Mode=OneWay}" />
```

Zmiana `UserName` w kodzie odświeży `TextBlock`.

### Dwustronne

```xml
<TextBox Text="{Binding UserName, Mode=TwoWay,
                        UpdateSourceTrigger=PropertyChanged}" />
```

Wpisanie tekstu zmienia `SettingsViewModel.UserName`, a zmiana właściwości w kodzie odświeża pole tekstowe.

## 3. Między ListBox a listą obiektów

Przykładowy model oraz ViewModel:

```csharp
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class Product : INotifyPropertyChanged
{
    private string _name = string.Empty;
    private decimal _price;

    public string Name
    {
        get => _name;
        set { _name = value; OnPropertyChanged(); }
    }

    public decimal Price
    {
        get => _price;
        set { _price = value; OnPropertyChanged(); }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public class ProductsViewModel : INotifyPropertyChanged
{
    private Product? _selectedProduct;

    public ObservableCollection<Product> Products { get; } = new()
    {
        new Product { Name = "Klawiatura", Price = 199.99m },
        new Product { Name = "Mysz", Price = 89.99m }
    };

    public Product? SelectedProduct
    {
        get => _selectedProduct;
        set { _selectedProduct = value; OnPropertyChanged(); }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
```

### Jednostronne: elementy listy

```xml
<ListBox ItemsSource="{Binding Products, Mode=OneWay}"
         DisplayMemberPath="Name" />
```

Dodanie lub usunięcie obiektu w `Products` odświeża `ListBox`, ponieważ kolekcja jest typu `ObservableCollection<Product>`.

### Dwustronne: wybrany element

```xml
<ListBox ItemsSource="{Binding Products}"
         DisplayMemberPath="Name"
         SelectedItem="{Binding SelectedProduct, Mode=TwoWay}" />
```

Wybranie elementu na liście ustawia `SelectedProduct`. Ustawienie `SelectedProduct` w ViewModelu zaznacza odpowiadający element w `ListBox`.

## 4. Między DataGrid a listą obiektów

`DataGrid` prezentuje kolekcję przez `ItemsSource`. Aby użytkownik mógł edytować dane, właściwości elementów kolekcji muszą mieć settery; `INotifyPropertyChanged` zapewnia odświeżanie zmian wykonanych w kodzie.

### Jednostronne: tylko odczyt

```xml
<DataGrid ItemsSource="{Binding Products, Mode=OneWay}"
          AutoGenerateColumns="False"
          IsReadOnly="True">
    <DataGrid.Columns>
        <DataGridTextColumn Header="Nazwa" Binding="{Binding Name}" />
        <DataGridTextColumn Header="Cena" Binding="{Binding Price, StringFormat={}{0:C}}" />
    </DataGrid.Columns>
</DataGrid>
```

Zmiany w `Products` oraz jej elementach są widoczne w tabeli, ale użytkownik nie może ich zmieniać.

### Dwustronne: edycja w tabeli

```xml
<DataGrid ItemsSource="{Binding Products}"
          AutoGenerateColumns="False"
          CanUserAddRows="False">
    <DataGrid.Columns>
        <DataGridTextColumn Header="Nazwa"
            Binding="{Binding Name, Mode=TwoWay,
                              UpdateSourceTrigger=PropertyChanged}" />
        <DataGridTextColumn Header="Cena"
            Binding="{Binding Price, Mode=TwoWay,
                              UpdateSourceTrigger=PropertyChanged,
                              StringFormat={}{0:F2}}" />
    </DataGrid.Columns>
</DataGrid>
```

Edycja komórki aktualizuje właściwość danego obiektu `Product`. Zmiana `Product.Name` lub `Product.Price` w kodzie jest również widoczna w `DataGrid`.

## Najważniejsze zależności

| Sytuacja                                    | Wymagany mechanizm                    |
| ------------------------------------------- | ------------------------------------- |
| Właściwość ViewModelu zmienia się w kodzie  | `INotifyPropertyChanged`              |
| Dodawanie i usuwanie elementów listy        | `ObservableCollection<T>`             |
| Edycja kontrolki ma zmienić źródło          | `Mode=TwoWay`                         |
| Aktualizacja `TextBox` w trakcie wpisywania | `UpdateSourceTrigger=PropertyChanged` |
