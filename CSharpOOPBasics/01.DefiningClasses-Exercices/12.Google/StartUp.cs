using System;
using System.Collections.Generic;
using System.Linq;


public class Program
{
    static void Main(string[] args)
    {
        var data = new Queue<Person>();

        CollectData(data);

        Print(data);
    }

    public static void CollectData(Queue<Person> data)
    {
        var line = string.Empty;

        while ((line = Console.ReadLine()) != "End")
        {
            var input = line.Split();

            var personName = input[0];

            var person = data.FirstOrDefault(p => p.Name == personName);

            if (person == null)
            {
                person = new Person(personName);
                data.Enqueue(person);
            }

            OrderByGroup(input, person);

        }
    }

    public static void OrderByGroup(string[] input, Person person)
    {
        switch (input[1])
        {
            case "company":
                var companyName = input[2];
                var salary = decimal.Parse(input[4]);
                var department = input[3];
                person.AssignACompany(new Company(companyName, department, salary));
                break;
            case "pokemon":
                var pokemonName = input[2];
                var type = input[3];
                person.AddInCollection(new Pokemon(pokemonName, type));
                break;
            case "parents":
                var name = input[2];
                var birthDay = input[3];
                person.AddInCollection(new Parent(name, birthDay));
                break;
            case "children":
                var childrenName = input[2];
                var childrenBirthday = input[3];
                person.AddInCollection(new Child(childrenName, childrenBirthday));
                break;
            case "car":
                var model = input[2];
                var speed = int.Parse(input[3]);
                person.AssignACar(new Car(model, speed));
                break;
        }
    }

    public static void Print(Queue<Person> data)
    {
        var toPrint = Console.ReadLine();
        var personPrinting = data.FirstOrDefault(x => x.Name == toPrint);

        if (personPrinting != null)
        {
            Console.Write(personPrinting.ToString());
        }
    }
}
