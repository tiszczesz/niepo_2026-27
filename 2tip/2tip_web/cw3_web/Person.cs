using System;

namespace cw3_web;

public class Person
{
   public string Firstname { get; set; }
   public string Lastname { get; set; }
   public int Age { get; set; }
}

public class PersonsRepo
{
    public static List<Person> GetPersons()
    {
        return new List<Person>
        {
            new Person{Firstname="Alan",Lastname="Romańsik",Age=17},
            new Person{Firstname="Roman",Lastname="Groński",Age=22},
            new Person{Firstname="Edyta",Lastname="Nowak",Age=34},
            new Person{Firstname="Mariola",Lastname="Kowak",Age=67},
        };
    }
}
