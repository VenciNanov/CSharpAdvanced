using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        var border = new HashSet<string>();

        var input = string.Empty;

        while ((input = Console.ReadLine())!="End")
        {
            var tokens = input.Trim();

            border.Add(input);
        }

        var fakeIdNumber = Console.ReadLine();

        foreach (var citizen in border)
        {
            if (citizen.EndsWith(fakeIdNumber))
            {
                Console.WriteLine(citizen.Split().Last());
            }
        }
    }
}

