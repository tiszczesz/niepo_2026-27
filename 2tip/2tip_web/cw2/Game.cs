

namespace cw2;

public class Game
{
    //pola klasy
    private string title;
    private decimal price;


   //metody klasy
   //konstruktor w klasie Game
   //bez argumentów
   public Game()
    {
        this.title = "jakiś";
        this.price = 120.99M;
    }
    //konstruktor z argumentami
    public Game(string title, decimal price)
    {
        this.title = title;
        this.price = price;        
    }
    //nadpisanie metodt ToString()
    public override string ToString()
    {
        return $"Tytuł: {title} cena: {price} zł";
    }

}
