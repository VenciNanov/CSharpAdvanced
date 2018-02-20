using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Startup
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        var family = new HashSet<Person>();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var person = input[0];
            var age = int.Parse(input[1]);
            family.Add(new Person(person, age));
        }
        Console.WriteLine(string.Join(Environment.NewLine, family.Where(p=>p.Age>30).OrderBy(p=>p.Name).Select(p=>$"{p.Name} - {p.Age}")));
    }
}

