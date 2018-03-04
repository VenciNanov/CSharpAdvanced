using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Cat> cats = new List<Cat>();

        var input = string.Empty;

        while ((input = Console.ReadLine()) != "End")
        {
            var tokens = input.Split();

            var breed = tokens[0];
            var name = tokens[1];
            var param = double.Parse(tokens[2]);

            switch (breed)
            {
                case "Siamese":
                    cats.Add(new Siamese(breed, name, param));
                    break;
                case "StreetExtraordinaire":
                    cats.Add(new StreetExtraordinaire(breed, name, param));
                    break;
                case "Cymric":
                    var furрLenght = decimal.Parse(tokens[2]);
                    cats.Add(new Cymric(breed, name,furрLenght));
                    break;
                default:
                    break;
            }
        }

        var catName = Console.ReadLine();

        Console.WriteLine(cats.FirstOrDefault(c => c.Name == catName).ToString());

    }
}