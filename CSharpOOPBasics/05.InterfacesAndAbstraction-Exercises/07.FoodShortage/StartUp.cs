using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.FoodShortage
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            GetMarket(people);

            Shopping(people);

            Console.WriteLine(Person.TotalFood);
        }

        private static void Shopping(List<Person> people)
        {
            var name = string.Empty;

            while ((name = Console.ReadLine()) != "End")
            {
                if (people.Any(x => x.Name == name))
                {
                    Person person = people.FirstOrDefault(x => x.Name == name);
                    person.BuyFood();
                }
            }
        }

        private static void GetMarket(List<Person> people)
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split();

                if (tokens.Length == 4)
                {
                    var CitizenName = tokens[0];
                    var age = int.Parse(tokens[1]);
                    var id = tokens[2];
                    var birthdate = tokens[3];

                    people.Add(new Citizen(CitizenName, age, id, birthdate));
                }

                else if (tokens.Length == 3)
                {
                    var rebelName = tokens[0];
                    var age = int.Parse(tokens[1]);
                    var group = tokens[2];

                    people.Add(new Rebel(rebelName, age, group));
                }
            }
        }
    }
}
