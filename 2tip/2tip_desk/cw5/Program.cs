void Ex1()
{
    //tablica 10 elementowa typu int z zerami
    int[] numbers = new int[10];
    //tablica zainicjalizowana wartościami
    char[] chars = new char[]{'a','e','i','o','u','y'};
    Console.WriteLine($"Rozmiar tablicu numbers: {numbers.Length}");
    Console.WriteLine($"Rozmiar tablicu chars: {chars.Length}");
    numbers[3] = 33;
    numbers[7] = 77;
    //numbers[10] = 6666;
    for(int i=0; i<numbers.Length; i++)
    {
        Console.Write(numbers[i]+" ");
    }
    Console.WriteLine();
    foreach(char c in chars)
    {
        Console.Write(c+" ");
    }
    Console.WriteLine();
}
Ex1();
//Napisz funkcję która zwraca tablice o ustalonym w
//argumencie rozmiarze zawierajacą liczby losowe
// int[] GenerTab(int size){...}
// napisz też funkcję wyświetlajaca tablice
// void ShowTab(int[] tab){...}
int[] GenerTab(int size)
{
    int[] result = new int[size];
   Random rnd = new Random(); 
   for(int i=0; i < result.Length; i++)
    {
        result[i] = rnd.Next(100);
    }
    return result;
}
void ShowTab(int[] tab)
{
    foreach(int elem in tab)
    {
        Console.Write(elem+" ");
    }
    Console.WriteLine();
}
// ShowTab(GenerTab(22));

void Ex2()
{
   //tablice wielowymiarowe 
   Random rnd = new Random();
   int [,] tab2D = new int[10,20];
   for(int i = 0; i < tab2D.GetLength(0); i++)
    {
        for(int j = 0; j < tab2D.GetLength(1); j++)
        {
            tab2D[i,j] = rnd.Next(100);
        }
    }
    //wyswietlanie tablicy
     for(int i = 0; i < tab2D.GetLength(0); i++)
    {
        for(int j = 0; j < tab2D.GetLength(1); j++)
        {
            Console.Write(tab2D[i,j]+"\t");
        }
        Console.WriteLine();
    }
}
Ex2();