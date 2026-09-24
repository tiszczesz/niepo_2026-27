void ex1()
{
    //petla while(war) {...}
    Random rnd = new Random();// losowacz liczb
    const uint range = 100; //liczby całkowite dodatnie
    uint sum = 0;
    while(sum < range)
    {
        //losujemy i rzutujemy na dodatnie
        uint losowa = (uint)rnd.Next(0,20); 
        sum += losowa; //sum = sum + losowa
        Console.Write(losowa+" ");
    }
    Console.WriteLine("\n Suma koncowa = "+ sum);
}
ex1();