# Ustawianie szerokości i wysokości w WPF (ze szczególnym uwzględnieniem `StackPanel`)

Ten dokument omawia praktyczne sposoby ustawiania rozmiaru kontrolek w WPF:

- `Width` / `Height`
- `MinWidth` / `MinHeight`
- `MaxWidth` / `MaxHeight`
- `HorizontalAlignment` / `VerticalAlignment`
- `Margin` i `Padding`
- zachowanie kontrolek w `StackPanel`
- alternatywne panele (`Grid`, `DockPanel`, `WrapPanel`) i kiedy ich używać

---

## 1. Podstawy: jak WPF wylicza rozmiar

WPF układa elementy w dwóch krokach:

1. **Measure** – element zgłasza, ile miejsca chciałby dostać.
2. **Arrange** – rodzic przydziela finalny obszar.

Dlatego sam `Width="200"` nie zawsze „wystarczy”, bo ostatecznie dużo zależy od panelu-rodzica.

---

## 2. Najważniejsze właściwości rozmiaru

### `Width` i `Height`
- Domyślnie mają wartość `NaN` (czyli `Auto`).
- `Auto` oznacza: „dopasuj do zawartości i reguł panelu”.

Przykład:

```xml
<Button Content="Zapisz" Width="160" Height="40" />
```

### `MinWidth` / `MinHeight`
- Gwarantują minimalny rozmiar.
- Przydatne np. dla przycisków i pól tekstowych.

```xml
<TextBox MinWidth="180" />
```

### `MaxWidth` / `MaxHeight`
- Ograniczają maksymalny rozmiar.
- Dobre przy „rozlewających się” kontrolkach.

```xml
<TextBox MaxWidth="400" />
```

> Najlepsza praktyka: zamiast sztywnego `Width` często lepiej użyć kombinacji `MinWidth` + `MaxWidth`.

---

## 3. `HorizontalAlignment` i `VerticalAlignment`

Wyrównanie wpływa na to, czy element ma się rozciągać:

- `Left`, `Center`, `Right` – brak rozciągania w poziomie
- `Stretch` – rozciągnięcie (jeśli panel to wspiera)

Przykład:

```xml
<TextBox HorizontalAlignment="Stretch" MinWidth="180" />
```

---

## 4. `Margin` vs `Padding`

- `Margin` – odstęp **na zewnątrz** kontrolki
- `Padding` – odstęp **wewnątrz** kontrolki (np. między tekstem a obramowaniem)

```xml
<Button Content="OK" Margin="8" Padding="12,6" />
```

---

## 5. Kluczowe: `StackPanel` a szerokość/wysokość

`StackPanel` układa elementy **jeden po drugim**:

- przy `Orientation="Vertical"` – od góry do dołu
- przy `Orientation="Horizontal"` – od lewej do prawej

To ma duży wpływ na rozmiary dzieci.

## 5.1 `StackPanel` pionowy (`Orientation="Vertical"`)

- Dzieci dostają praktycznie „nieograniczoną” wysokość do pomiaru.
- W poziomie zwykle mogą się rozciągać, ale zależy to od `HorizontalAlignment` i szerokości rodzica.

```xml
<StackPanel Orientation="Vertical" Margin="16">
    <TextBox Margin="0,0,0,8" MinWidth="200" />
    <Button Content="Zapisz" Width="120" />
</StackPanel>
```

## 5.2 `StackPanel` poziomy (`Orientation="Horizontal"`)

- Dzieci układane są obok siebie.
- Szerokość całego panelu to suma szerokości dzieci.
- `HorizontalAlignment="Stretch"` dzieci **nie działa tu tak, jak wiele osób oczekuje** (nie ma podziału miejsca „po równo”).

```xml
<StackPanel Orientation="Horizontal" Margin="16">
    <Button Content="Wstecz" Margin="0,0,8,0" />
    <Button Content="Dalej" />
</StackPanel>
```

## 5.3 Najczęstszy błąd w `StackPanel`

Chęć uzyskania „elastycznych kolumn” (np. 50/50) w `StackPanel`.

`StackPanel` **nie jest** do tego najlepszy. Do podziału przestrzeni użyj `Grid`.

---

## 6. Kiedy zamiast `StackPanel` użyć `Grid`

Jeśli potrzebujesz:

- równego podziału szerokości,
- layoutu formularzowego,
- precyzyjnej kontroli rozciągania,

to `Grid` będzie lepszym wyborem.

Przykład 2 kolumn „po równo”:

```xml
<Grid Margin="16">
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="*" />
        <ColumnDefinition Width="*" />
    </Grid.ColumnDefinitions>

    <TextBox Grid.Column="0" Margin="0,0,8,0" />
    <TextBox Grid.Column="1" Margin="8,0,0,0" />
</Grid>
```

Przykład formularza etykieta + pole:

```xml
<Grid Margin="16">
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="Auto" />
        <ColumnDefinition Width="*" />
    </Grid.ColumnDefinitions>

    <TextBlock Text="Imię:" VerticalAlignment="Center" Margin="0,0,8,8" />
    <TextBox Grid.Column="1" MinWidth="220" Margin="0,0,0,8" />
</Grid>
```

---

## 7. Inne panele i ich wpływ na rozmiar

## `DockPanel`
- Dobre do layoutu typu: menu u góry, status na dole, treść wypełnia resztę.

## `WrapPanel`
- Elementy „zawijają się” do nowej linii po przekroczeniu szerokości.
- Dobre np. dla kafelków/tagów.

## `UniformGrid`
- Wszystkie komórki mają identyczny rozmiar.
- Dobre do prostych siatek przycisków.

---

## 8. Praktyczne strategie (recommended)

1. **Nie ustawiaj sztywnego `Width/Height` wszędzie.**
2. Używaj `MinWidth/MinHeight` dla użyteczności.
3. Ograniczaj `MaxWidth` tam, gdzie szerokie ekrany psują czytelność.
4. Do prostych „stosów” używaj `StackPanel`.
5. Do układów responsywnych i kolumnowych używaj `Grid`.
6. Spójne odstępy realizuj przez `Margin` i style.

---

## 9. Przykład: poprawiony układ przycisków (zamiast poziomego StackPanel)

Zamiast:

```xml
<StackPanel Orientation="Horizontal">
    <Button Content="Anuluj" />
    <Button Content="Zapisz" />
</StackPanel>
```

lepiej:

```xml
<Grid Margin="16">
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="*" />
        <ColumnDefinition Width="Auto" />
        <ColumnDefinition Width="8" />
        <ColumnDefinition Width="Auto" />
    </Grid.ColumnDefinitions>

    <Button Grid.Column="1" Content="Anuluj" MinWidth="100" />
    <Button Grid.Column="3" Content="Zapisz" MinWidth="100" />
</Grid>
```

Dzięki temu przyciski są przewidywalnie wyrównane do prawej i wyglądają dobrze na różnych rozdzielczościach.

---

## 10. TL;DR

- `StackPanel` jest świetny do prostego układania elementów „jeden po drugim”.
- Nie nadaje się najlepiej do elastycznego podziału przestrzeni.
- Jeśli walczysz z `Width`/`Height` w poziomym `StackPanel`, najczęściej potrzebujesz `Grid`.
- Najbardziej odporne UI w WPF zwykle bazuje na `Grid` + sensowne `Min/Max` + `Margin`.
