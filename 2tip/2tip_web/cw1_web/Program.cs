void ex1()
{
    //wykorzystanie instrukcji warunkowej if
    Console.Write(("Podaj swoje imię:  "));
    string? firstname = Console.ReadLine();
    if (firstname?.Length < 3)   //(?)tylko gdy firstname nie jest null,
                                 //sprawdzamy długość
    {
        Console.WriteLine("Twoje imię jest za krótkie");
    }
    else
    {
        Console.WriteLine(
        $"Witaj {firstname} dzisiaj jest {DateTime.Now.ToShortDateString()}"
        );
    }
}
//wywołanie funkcji ex1
//ex1();
void ex2()
{
    //pobieranie liczby od użytkownika i sprawdzenie czy jest parzysta
    Console.Write("Podaj liczbę całkowitą: ");
    int number = Convert.ToInt32(Console.ReadLine());//proba zamiany string na int
    if(number % 2 == 0)
    {
        Console.WriteLine($"Liczba {number} jest parzysta");
    }
    else
    {
        Console.WriteLine($"Liczba {number} jest nieparzysta");
    }
}
//ex2();
//napisac funkcje ex3() ktora pobiera od uzytkownika dwie liczby całkowite
// i wypisuje większą z nich
void ex3()
{
    Console.Write("Podaj pierwszą liczbę całkowitą: ");
    int number1 = Convert.ToInt32(Console.ReadLine());
    Console.Write("Podaj drugą liczbę całkowitą: ");
    int number2 = Convert.ToInt32(Console.ReadLine());

    if (number1 > number2)
    {
        Console.WriteLine($"Większa liczba to {number1}");
    }
    else if (number2 > number1)
    {
        Console.WriteLine($"Większa liczba to {number2}");
    }
    else
    {
        Console.WriteLine("Liczby są równe");
    }
}
//ex3();

void ex4()
{
    //wyswietlenie liczb naturalnych oraz ich kwadratów  i sześcianów 
     Console.Write("Podaj ile liczb: ");
    uint n = Convert.ToUInt32(Console.ReadLine()); //pobranie liczby naturalnej od użytkownika
    for (uint i = 1; i <= n; i++)   //for(;;);
    {
        Console.WriteLine($"{i}\t i^2 = {Math.Pow(i, 2)}\t i^3 = {Math.Pow(i, 3)}");
    }
}
ex4();