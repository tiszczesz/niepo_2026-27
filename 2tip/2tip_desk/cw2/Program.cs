int a = 5;
int b = 6;
//konkatenacja stringów
Console.WriteLine(a + " + " + b + " = " + (a + b));
//interpolacja stringów
Console.WriteLine($"{a} + {b} = {a + b}");
Console.WriteLine($"{a} - {b} = {a - b}");
Console.WriteLine($"{a} * {b} = {a * b}");
//dzielenie całkowite w języku C# zwraca liczbę całkowitą, więc wynik dzielenia 5 / 8 to 0
Console.WriteLine($"{a} / {b} = {a / b}");
//aby uzyskać wynik dzielenia w postaci liczby zmiennoprzecinkowej, 
// należy jawnie rzutować jedną ze zmiennych na typ double
Console.WriteLine($"{a} / {b} = {(double)a / b}");
