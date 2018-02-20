using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Startup
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        var family = new Family();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var person = input[0];
            var age = int.Parse(input[1]);

            var member = new Person(person, age);

            family.AddMember(member);
        }

        var oldestMember = family.GetOldestMember();
        Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
    }
}

