Poniżej gotowa treść pliku `programowanie_dynamiczne.md`:

Programowanie dynamiczne

# Programowanie dynamiczne

## 1\. Czym jest programowanie dynamiczne?

**Programowanie dynamiczne (PD)** to technika projektowania algorytmów, która pozwala rozwiązywać problemy poprzez podział ich na mniejsze podproblemy, a następnie zapamiętywanie wyników tych podproblemów.

Dzięki temu nie musimy wielokrotnie wykonywać tych samych obliczeń.

Programowanie dynamiczne jest szczególnie przydatne, gdy problem ma:

- **nakładające się podproblemy** – te same podproblemy pojawiają się wiele razy,
- **własność optymalnej struktury** – optymalne rozwiązanie całego problemu można zbudować z optymalnych rozwiązań jego podproblemów.

Najczęściej stosuje się dwa podejścia:

1. **Top-down (z góry na dół)** – rekurencja + zapamiętywanie wyników (memoizacja).
2. **Bottom-up (z dołu do góry)** – rozwiązujemy podproblemy od najmniejszych do największych (tabulacja).

---

## 2\. Przykład – ciąg Fibonacciego

Ciąg Fibonacciego definiujemy następująco:

$$
F(0)=0
$$

$$
F(1)=1
$$

$$
F(n)=F(n-1)+F(n-2)
$$

### Podejście rekurencyjne

Prosta implementacja rekurencyjna wygląda tak:

```
int fib(int n) {
    if (n <= 1)
        return n;

    return fib(n - 1) + fib(n - 2);
}
```

Problem polega na tym, że te same wartości są obliczane wiele razy.

Na przykład podczas obliczania `fib(5)` wartość `fib(3)` zostanie obliczona więcej niż raz.

Złożoność czasowa takiego rozwiązania jest wykładnicza – około:

$$
O(2^n)
$$

---

## 3\. Fibonacciego z wykorzystaniem programowania dynamicznego

Możemy zapamiętywać już obliczone wartości.

### Memoizacja – podejście top-down

```
#include <iostream>
#include <vector>
using namespace std;

vector<long long> dp;

long long fib(int n) {
    if (n <= 1)
        return n;

    if (dp[n] != -1)
        return dp[n];

    dp[n] = fib(n - 1) + fib(n - 2);
    return dp[n];
}

int main() {
    int n = 50;

    dp.assign(n + 1, -1);

    cout << fib(n) << '\n';

    return 0;
}
```

Tablica `dp` przechowuje wyniki już rozwiązanych podproblemów.

Dzięki temu każdą wartość obliczamy tylko raz.

**Złożoność czasowa:** `O(n)`

**Złożoność pamięciowa:** `O(n)`

---

## 4\. Tabulacja – podejście bottom-up

Drugim sposobem jest rozpoczęcie od najmniejszych wartości:

```
#include <iostream>
#include <vector>
using namespace std;

long long fib(int n) {
    if (n <= 1)
        return n;

    vector<long long> dp(n + 1);

    dp[0] = 0;
    dp[1] = 1;

    for (int i = 2; i <= n; i++) {
        dp[i] = dp[i - 1] + dp[i - 2];
    }

    return dp[n];
}

int main() {
    cout << fib(50) << '\n';

    return 0;
}
```

W tym przypadku wartości są obliczane kolejno:

```
dp[0] → dp[1] → dp[2] → dp[3] → ... → dp[n]
```

---

## 5\. Plecak 0/1

Jednym z klasycznych problemów programowania dynamicznego jest **problem plecakowy**.

Mamy kilka przedmiotów. Każdy z nich ma:

- wagę,
- wartość.

Mamy plecak o określonej maksymalnej wadze.

Chcemy wybrać przedmioty tak, aby **łączna wartość była jak największa**, nie przekraczając pojemności plecaka.

Każdy przedmiot możemy wybrać maksymalnie raz.

### Przykład

Mamy przedmioty:

| Przedmiot | Waga | Wartość |
| --- | --- | --- |
| 1 | 2 | 3 |
| 2 | 3 | 4 |
| 3 | 4 | 5 |
| 4 | 5 | 6 |

Pojemność plecaka wynosi `5`.

Możemy np. wybrać przedmioty 1 i 2:

```
waga = 2 + 3 = 5
wartość = 3 + 4 = 7
```

Najlepszy wynik to `7`.

### Implementacja w C++

```
#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

int main() {
    vector<int> weight = {2, 3, 4, 5};
    vector<int> value = {3, 4, 5, 6};

    int n = weight.size();
    int capacity = 5;

    vector<vector<int>> dp(n + 1, vector<int>(capacity + 1, 0));

    for (int i = 1; i <= n; i++) {
        for (int w = 0; w <= capacity; w++) {

            // Nie wybieramy przedmiotu
            dp[i][w] = dp[i - 1][w];

            // Wybieramy przedmiot, jeśli się mieści
            if (weight[i - 1] <= w) {
                dp[i][w] = max(
                    dp[i][w],
                    dp[i - 1][w - weight[i - 1]] + value[i - 1]
                );
            }
        }
    }

    cout << "Maksymalna wartosc: "
         << dp[n][capacity] << '\n';

    return 0;
}
```

### Jak działa tablica `dp`?

`dp[i][w]` oznacza:

> maksymalną wartość, jaką możemy uzyskać, korzystając z pierwszych `i` przedmiotów przy pojemności plecaka `w`.

Dla każdego przedmiotu mamy dwie możliwości:

1. **Nie wybieramy go**.
2. **Wybieramy go**, jeśli jego waga nie przekracza aktualnej pojemności.

Wybieramy lepszą z tych dwóch możliwości.

---

## 6\. Najdłuższy wspólny podciąg

Kolejnym klasycznym zastosowaniem programowania dynamicznego jest problem **najdłuższego wspólnego podciągu (LCS – Longest Common Subsequence)**.

Przykładowo dla napisów:

```
A = ABCBDAB
B = BDCAB
```

jednym z najdłuższych wspólnych podciągów jest:

```
BCAB
```

Nie musimy zachowywać kolejnych znaków w napisie, ale ich kolejność musi zostać zachowana.

### Implementacja

```
#include <iostream>
#include <vector>
#include <string>
#include <algorithm>
using namespace std;

int main() {
    string a = "ABCBDAB";
    string b = "BDCAB";

    int n = a.size();
    int m = b.size();

    vector<vector<int>> dp(n + 1, vector<int>(m + 1, 0));

    for (int i = 1; i <= n; i++) {
        for (int j = 1; j <= m; j++) {

            if (a[i - 1] == b[j - 1]) {
                dp[i][j] = dp[i - 1][j - 1] + 1;
            } else {
                dp[i][j] = max(dp[i - 1][j], dp[i][j - 1]);
            }
        }
    }

    cout << "Dlugosc LCS: " << dp[n][m] << '\n';

    return 0;
}
```

### Znaczenie tablicy

`dp[i][j]` oznacza długość najdłuższego wspólnego podciągu pierwszych `i` znaków napisu `a` oraz pierwszych `j` znaków napisu `b`.

Jeżeli:

```
a[i - 1] == b[j - 1]
```

to możemy wykorzystać oba znaki:

```
dp[i][j] = dp[i - 1][j - 1] + 1;
```

Jeżeli znaki są różne, wybieramy lepszy wynik:

```
dp[i][j] = max(dp[i - 1][j], dp[i][j - 1]);
```

---

## 7\. Problem wydawania reszty

Programowanie dynamiczne można również wykorzystać do znalezienia **minimalnej liczby monet potrzebnych do uzyskania określonej kwoty**.

Załóżmy, że mamy monety:

```
1, 3, 4
```

i chcemy uzyskać kwotę:

```
6
```

Najlepszym rozwiązaniem są dwie monety:

```
3 + 3 = 6
```

### Implementacja

```
#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

int main() {
    vector<int> coins = {1, 3, 4};
    int amount = 6;

    const int INF = 1e9;

    vector<int> dp(amount + 1, INF);

    dp[0] = 0;

    for (int i = 1; i <= amount; i++) {
        for (int coin : coins) {
            if (coin <= i && dp[i - coin] != INF) {
                dp[i] = min(dp[i], dp[i - coin] + 1);
            }
        }
    }

    if (dp[amount] == INF) {
        cout << "Nie mozna uzyskac tej kwoty.\n";
    } else {
        cout << "Minimalna liczba monet: "
             << dp[amount] << '\n';
    }

    return 0;
}
```

Dla kwoty `6` otrzymamy:

```
Minimalna liczba monet: 2
```

---

## 8\. Jak rozwiązywać zadania za pomocą programowania dynamicznego?

Podczas rozwiązywania zadania warto postępować według następujących kroków:

### Krok 1 – znajdź podproblemy

Zastanów się, czy problem można podzielić na mniejsze problemy tego samego rodzaju.

### Krok 2 – zdefiniuj stan

Określ, co będzie oznaczała komórka tablicy `dp`.

Na przykład:

```
dp[i]
```

może oznaczać najlepszy wynik dla pierwszych `i` elementów.

Natomiast:

```
dp[i][j]
```

może oznaczać najlepszy wynik dla dwóch parametrów `i` i `j`.

### Krok 3 – znajdź przejście

Określ, jak obliczyć aktualny stan na podstawie wcześniejszych stanów.

Przykład:

```
dp[i] = min(dp[i], dp[i - coin] + 1);
```

### Krok 4 – ustal przypadki bazowe

Musimy określić wartości początkowe.

Przykładowo dla Fibonacciego:

```
dp[0] = 0;
dp[1] = 1;
```

### Krok 5 – ustal kolejność obliczeń

Musimy obliczyć podproblemy w takiej kolejności, aby wszystkie potrzebne wcześniejsze wartości były już znane.

### Krok 6 – odczytaj odpowiedź

Na końcu odpowiedź znajduje się zazwyczaj w:

```
dp[n]
```

lub:

```
dp[n][m]
```

---

## 9\. Programowanie dynamiczne a zachłanność

Programowanie dynamiczne często porównuje się z algorytmami zachłannymi.

**Algorytm zachłanny** w każdym kroku wybiera rozwiązanie, które w danym momencie wygląda najlepiej.

**Programowanie dynamiczne** analizuje wiele możliwości i zapamiętuje wyniki podproblemów, aby znaleźć rozwiązanie optymalne.

Nie każdy problem można poprawnie rozwiązać metodą zachłanną, natomiast programowanie dynamiczne pozwala rozwiązywać wiele problemów optymalizacyjnych.

---

## 10\. Zalety i wady

### Zalety

- znacznie przyspiesza wiele algorytmów,
- eliminuje wielokrotne rozwiązywanie tych samych podproblemów,
- pozwala znajdować rozwiązania optymalne,
- można stosować zarówno rekurencję z memoizacją, jak i iteracyjne tablice.

### Wady

- może wymagać dużej ilości pamięci,
- znalezienie odpowiedniego stanu `dp` i przejścia może być trudne,
- nie każdy problem nadaje się do programowania dynamicznego,
- implementacja może być bardziej skomplikowana niż prostego algorytmu zachłannego.

---

## 11\. Podsumowanie

**Programowanie dynamiczne** polega na rozwiązywaniu problemu poprzez podział go na mniejsze podproblemy oraz zapamiętywanie ich wyników.

Najważniejsze elementy programowania dynamicznego to:

1. określenie **stanu** `dp`,
2. znalezienie **przejścia** między stanami,
3. ustalenie **przypadków bazowych**,
4. określenie **kolejności obliczeń**,
5. odczytanie końcowego wyniku.

Najczęściej spotykane zastosowania to między innymi:

- ciąg Fibonacciego,
- problem plecakowy,
- najdłuższy wspólny podciąg,
- problem wydawania reszty,
- znajdowanie najkrótszych lub najtańszych sposobów osiągnięcia celu.

Najważniejsza idea, którą warto zapamiętać, brzmi:

> **Jeżeli te same podproblemy pojawiają się wielokrotnie, zamiast rozwiązywać je ponownie, zapisz ich wyniki i wykorzystaj je później.**

Jeśli chcesz, mogę też przygotować **krótszą wersję typowo „do szkoły”, na 1–2 strony**, albo wersję z **zadaniami i rozwiązaniami w C++**.