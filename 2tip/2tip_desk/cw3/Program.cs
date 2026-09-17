// Console.WriteLine("Hello, World!");// "\n"
// Console.Write("Hello, World!");
Console.Write("Podaj swoje imię: ");
string? firstname = Console.ReadLine();
Console.Write("Podaj swoje nazwisko: ");
string? lastname = Console.ReadLine();
Console.WriteLine($"Witaj {firstname} {lastname}!");

//definicja funkcji
//typ_zwracany(void) nazwa_funkcji(parametry)
// {     ciało funkcji}

//funkcja majaca dwa argumenty typu string i zwracająca string
string GetFullName(string fname, string lname){ //nagłówek funkcji
    //ciało funkcji
    return $"{fname} {lname}";
}
string result = GetFullName(firstname, lastname);
Console.WriteLine($"To jest z funkcji: {result}!");

//funkcja z dwoma argumentami typu int i nic nie zwracająca (void)
void ShowSum(int a, int b){
    int sum = a + b;
    Console.WriteLine($"Suma {a} i {b} wynosi: {sum}");    
}

//wywołanie funkcji ShowSum
ShowSum(5, 10);
ShowSum(24, 1);

//funkcja bez argumentow nic nie zwracająca (void)
void ShowHello()
{
    Console.WriteLine("Hello from function!");
}
//wywołanie funkcji ShowHello
ShowHello();
