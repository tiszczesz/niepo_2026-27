# Kontenery i układy w WPF

WPF oddziela **kontrolki** (np. `Button`, `TextBox`, `TextBlock`) od **paneli**, które rozmieszczają te kontrolki. Panel jest zwykle elementem nadrzędnym, a kontrolki umieszcza się wewnątrz niego w XAML. Wybór panelu wpływa na położenie, rozciąganie i rozmiar elementów.

## 1. Najważniejsze panele (kontenery)

### `Grid` — siatka wierszy i kolumn

Najbardziej uniwersalny panel. Pozwala tworzyć formularze i układy, w których elementy mogą zajmować pojedynczą komórkę lub kilka komórek. Wiersze definiuje się w `RowDefinitions`, a kolumny w `ColumnDefinitions`.

```xml
<Grid Margin="12">
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto" />
        <RowDefinition Height="*" />
        <RowDefinition Height="Auto" />
    </Grid.RowDefinitions>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="Auto" />
        <ColumnDefinition Width="*" />
    </Grid.ColumnDefinitions>

    <TextBlock Grid.Row="0" Grid.ColumnSpan="2"
               Text="Dane użytkownika" FontSize="20" Margin="0,0,0,12" />
    <TextBlock Grid.Row="1" Grid.Column="0" Text="Imię:" Margin="0,0,8,0" />
    <TextBox Grid.Row="1" Grid.Column="1" MinWidth="180" />
    <Button Grid.Row="2" Grid.Column="1" Content="Zapisz"
            HorizontalAlignment="Right" Margin="0,12,0,0" />
</Grid>
```

Wartości `Grid.Row` i `Grid.Column` zaczynają się od zera. Jeśli ich nie podasz, element trafi domyślnie do wiersza `0` i kolumny `0`.

### `StackPanel` — elementy jeden po drugim

Elementy układane są pionowo (domyślnie) lub poziomo. Nadaje się do prostych grup przycisków, etykiet czy pól formularza.

```xml
<StackPanel Orientation="Vertical" Margin="12">
    <TextBlock Text="Login" />
    <TextBox Margin="0,4,0,12" />
    <Button Content="Zaloguj" HorizontalAlignment="Left" />
</StackPanel>
```

```xml
<StackPanel Orientation="Horizontal" Margin="12">
    <Button Content="Wstecz" Margin="0,0,8,0" />
    <Button Content="Dalej" />
</StackPanel>
```

`StackPanel` nie dzieli dostępnego miejsca na elastyczne kolumny lub wiersze. W orientacji poziomej elementy zajmują miejsce obok siebie; do elastycznego podziału przestrzeni użyj `Grid`.

### `DockPanel` — dokowanie przy krawędziach

Dzieci można przypiąć do góry, dołu, lewej lub prawej krawędzi. Ostatnie dziecko domyślnie wypełnia pozostały obszar (`LastChildFill="True"`).

```xml
<DockPanel>
    <Menu DockPanel.Dock="Top">
        <MenuItem Header="Plik" />
    </Menu>
    <StatusBar DockPanel.Dock="Bottom">
        <TextBlock Text="Gotowe" />
    </StatusBar>
    <TextBox AcceptsReturn="True" Text="Treść okna" />
</DockPanel>
```

`DockPanel.Dock` ustawiaj na dzieciach panelu. Kolejność elementów ma znaczenie, ponieważ ostatnie dziecko wypełnia resztę.

### `WrapPanel` — zawijanie elementów

Układa elementy obok siebie i przenosi je do następnego wiersza (lub kolumny), gdy zabraknie miejsca. Przydatny np. do galerii, tagów i kafelków.

```xml
<WrapPanel>
    <Button Content="Pierwszy" Margin="4" />
    <Button Content="Drugi" Margin="4" />
    <Button Content="Trzeci" Margin="4" />
</WrapPanel>
```

### `Canvas` — pozycje bezwzględne

Umożliwia ustawianie elementów przez `Canvas.Left`, `Canvas.Top`, `Canvas.Right` i `Canvas.Bottom`. Jest przydatny np. do rysunków, ale zwykle nie sprawdza się jako główny układ okna: po zmianie rozmiaru okna elementy nie układają się automatycznie.

```xml
<Canvas>
    <Button Content="Przycisk" Canvas.Left="20" Canvas.Top="30" />
</Canvas>
```

### Inne przydatne kontenery

- `Border` — dodaje obramowanie, tło i wewnętrzny odstęp (`Padding`) wokół jednego elementu potomnego.
- `ScrollViewer` — dodaje przewijanie, gdy zawartość nie mieści się w dostępnej przestrzeni.
- `UniformGrid` — rozmieszcza elementy w komórkach o jednakowym rozmiarze.
- `GroupBox` — grupuje zawartość i wyświetla jej nagłówek.

```xml
<Border BorderBrush="Gray" BorderThickness="1" Padding="10" CornerRadius="4">
    <TextBlock Text="Tekst wewnątrz obramowania" />
</Border>
```

`Border` może zawierać tylko jeden element potomny; jeśli potrzebujesz kilku, umieść je w nim w panelu, np. `StackPanel` lub `Grid`.

## 2. Rozmiary w `Grid`: liczby, `Auto` i `*`

Wartości `Width` i `Height` w definicjach wierszy i kolumn `Grid` określają sposób podziału miejsca:

| Zapis | Znaczenie |
|---|---|
| `Width="120"` lub `Height="80"` | Stały rozmiar w jednostkach WPF (DIP). |
| `Width="Auto"` lub `Height="Auto"` | Rozmiar dopasowany do zawartości. |
| `Width="*"` lub `Height="*"` | Wykorzystanie proporcjonalnej części pozostałego miejsca. |
| `Width="2*"` | Dwa udziały miejsca, np. dwa razy więcej niż kolumna `*`. |

Jednostką WPF jest **DIP** (device-independent pixel), a nie bezpośrednio fizyczny piksel ekranu: 1 DIP to 1/96 cala. System dopasowuje wyświetlanie do skalowania DPI.

### Przykład mieszanych rozmiarów

```xml
<Grid>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="Auto" />
        <ColumnDefinition Width="2*" />
        <ColumnDefinition Width="*" />
    </Grid.ColumnDefinitions>

    <TextBlock Grid.Column="0" Text="Szukaj:" Margin="8" />
    <TextBox Grid.Column="1" Margin="4" />
    <Button Grid.Column="2" Content="Szukaj" Margin="4" />
</Grid>
```

Kolumna `Auto` zajmie tyle miejsca, ile wymaga jej zawartość. Pozostałe miejsce zostanie podzielone między kolumny gwiazdkowe w proporcji `2:1`.

### Jak działa `*`

Gwiazdkowe rozmiary dzielą **pozostałe dostępne miejsce** po uwzględnieniu stałych i `Auto` rozmiarów. Dla przykładu `*, 2*` oznacza podział pozostałej przestrzeni w proporcji 1 do 2. `MinWidth`, `MaxWidth`, `MinHeight` i `MaxHeight` mogą ograniczyć wynikowy rozmiar.

`*` jest jednostką definicji wiersza lub kolumny `Grid`. Nie wpisuje się jej jako wartości `Width`/`Height` kontrolki, np. `Button Width="*"` jest nieprawidłowe. Ponadto `*` może nie zachowywać się zgodnie z oczekiwaniami, gdy `Grid` jest mierzony w kierunku, w którym rodzic nie ogranicza dostępnego miejsca; typowym przykładem jest `Grid` umieszczony w `StackPanel` o tej samej orientacji. Do podziału ograniczonego obszaru użyj panelu `Grid` jako właściwego kontenera.

## 3. Rozmiar kontrolki: pominięte `Width` / `Height` i wartości liczbowe

Dla samej kontrolki, np. `Button` lub `TextBox`, `Width` i `Height` są liczbami w DIP. Jeśli ich nie ustawisz, WPF dobierze rozmiar na podstawie zawartości, ograniczeń rodzica i wyrównania — to najczęściej odpowiednik oczekiwanego „Auto”. Zwykle nie wpisuje się `Width="Auto"` na kontrolce; `Auto` stosuje się w definicjach wierszy i kolumn `Grid`.

```xml
<Button Content="OK" MinWidth="80" Padding="12,6" />
```

Często lepiej ustawić granice zamiast sztywnego rozmiaru:

- `MinWidth` / `MinHeight` — minimalny rozmiar,
- `MaxWidth` / `MaxHeight` — maksymalny rozmiar.

## 4. Wyrównanie i odstępy

- `HorizontalAlignment` i `VerticalAlignment` określają wyrównanie lub rozciąganie elementu (`Left`, `Center`, `Right`, `Top`, `Bottom`, `Stretch`).
- `Margin` to odstęp **na zewnątrz** elementu.
- `Padding` to odstęp **wewnątrz** kontrolki lub obramowania.

```xml
<TextBox MinWidth="180"
         HorizontalAlignment="Stretch"
         Margin="0,0,0,8"
         Padding="6" />
```

Wartości `Margin` i `Padding` można podać jako jedną liczbę (wszystkie strony), dwie (lewo/prawo; góra/dół) albo cztery (lewo, góra, prawo, dół).

## 5. Praktyczne wskazówki

1. Zacznij od `Grid` dla układów formularzowych i elementów, które mają się rozciągać wraz z oknem.
2. Użyj `StackPanel`, gdy elementy mają być po prostu ułożone jeden po drugim.
3. W `Grid` używaj `Auto` dla zawartości o naturalnym rozmiarze, `*` dla elastycznej przestrzeni i liczb dla świadomie stałych wymiarów.
4. Unikaj `Canvas` do typowych formularzy i okien, które mają działać przy różnych rozmiarach.
5. Nie ustawiaj sztywnego `Width` i `Height` każdej kontrolce bez potrzeby; rozważ `MinWidth`, wyrównanie i `Margin`.
