using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<Person> ppl = new List<Person>();

        var input = string.Empty;

        while ((input=Console.ReadLine())!="END")
        {
            var tokens = input.Split().ToArray();
            var name = tokens[0];
            var age = int.Parse(tokens[1]);
            var town = tokens[2];

            ppl.Add(new Person(name, age, town));
        }

        var number = int.Parse(Console.ReadLine());

        Person personToCompare = ppl[number - 1];
        var counter = 0;

        foreach (var person in ppl)
        {
            if (personToCompare.CompareTo(person)==0)
            {
                counter++;
            }
           
        }
        if (counter == 1)
        {
            Console.WriteLine($"No matches");
        }
        else
        {
            Console.WriteLine($"{counter} {ppl.Count - counter} {ppl.Count}");
        }
    }
}