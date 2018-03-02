using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Rebelion> rebbels = new List<Rebelion>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split();

                if (tokens[0] == "Citizen")
                {
                    var name = tokens[1];
                    var age = int.Parse(tokens[2]);
                    var id = tokens[3];
                    var birthdate = tokens[4];

                    rebbels.Add(new Citizen(name, age, id, birthdate));
                }
                else if (tokens[0]=="Pet")
                {
                    var name = tokens[1];
                    var birthdate = tokens[2];

                    rebbels.Add(new Pet(name, birthdate));
                }
            }
            var year = Console.ReadLine();

            rebbels.Where(x => x.Birthdate.EndsWith(year)).ToList().ForEach(x => Console.WriteLine(x));
        }
    }
}
