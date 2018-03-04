using System;
using System.Collections.Generic;

namespace _10.ExplicitInterfaces
{
    class StrartUp
    {
        static void Main(string[] args)
        {
            var input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split();

                var name = tokens[0];
                var country = tokens[1];
                var age = int.Parse(tokens[2]);

                Citizen citizen = new Citizen(name, country, age);

                IPerson person = citizen;
                IResident resident = citizen;

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
