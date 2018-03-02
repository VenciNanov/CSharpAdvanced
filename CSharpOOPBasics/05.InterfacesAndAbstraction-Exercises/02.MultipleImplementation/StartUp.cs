using System;

public class Program
{
    static void Main(string[] args)
    {
        var name = Console.ReadLine();
        var age = int.Parse(Console.ReadLine());
        var id = Console.ReadLine();
        var birthdate = Console.ReadLine();

        IIdentifiable person = new Citizen(name, age,id,birthdate);
        IBirthable birthable = new Citizen(name, age, id, birthdate);

        Console.WriteLine(person.Id);
        Console.WriteLine(birthable.Birthdate);

    }
}

