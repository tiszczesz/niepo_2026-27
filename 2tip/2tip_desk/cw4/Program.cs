void ex1()
{
    //petla while(war) {...}
    Random rnd = new Random();// losowacz liczb
    const uint range = 100; //liczby całkowite dodatnie
    uint sum = 0;
    while (sum < range)
    {
        //losujemy i rzutujemy na dodatnie
        uint losowa = (uint)rnd.Next(0, 20);
        sum += losowa; //sum = sum + losowa
        Console.Write(losowa + " ");
    }
    Console.WriteLine("\n Suma koncowa = " + sum);
}
void ex2()
{
    // petla do{...}while(war)
    //losujemy az wylosuje sie ZERO to koniec
    Random rnd = new Random();
    uint losowa = 0;
    Console.WriteLine("Liczba PI: "+ Math.PI);
    do
    {
        losowa = (uint)rnd.Next(0, 20);
        Console.Write(losowa + " ");
    } while (losowa != 0);
}
//ex1();
ex2();