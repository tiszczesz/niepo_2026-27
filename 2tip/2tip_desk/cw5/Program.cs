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