using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        SortedSet<Person> nameSortedSet = new SortedSet<Person>(new NameComparer());
        SortedSet<Person> ageSortedSet = new SortedSet<Person>(new AgeComparator());

        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var tokens = Console.ReadLine().Split();

            var name = tokens[0];
            var age = int.Parse(tokens[1]);

            Person person = new Person(name, age);

            nameSortedSet.Add(person);
            ageSortedSet.Add(person);

        }

        Console.WriteLine(string.Join(Environment.NewLine, nameSortedSet));
        Console.WriteLine(string.Join(Environment.NewLine, ageSortedSet));

    }
}
