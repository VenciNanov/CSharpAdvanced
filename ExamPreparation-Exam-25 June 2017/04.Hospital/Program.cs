using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Hospital
{
    class Program
    {
        public const int maxDepartmentCapacity = 20 * 3;

        static void Main(string[] args)
        {
            var input = string.Empty;

            var departmentsDict = new Dictionary<string, HashSet<string>>();
            var doctorsDict = new Dictionary<string, SortedSet<string>>();

            while ((input = Console.ReadLine()) != "Output")
            {
                var splitted = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                var departament = splitted[0];
                var doctor = splitted[1] + " " + splitted[2];
                var patient = splitted[3];


                if (!departmentsDict.ContainsKey(departament))
                {
                    departmentsDict[departament] = new HashSet<string>();
                }
                if (!doctorsDict.ContainsKey(doctor))
                {
                    doctorsDict[doctor] = new SortedSet<string>();
                }
                var departmentCapacity = departmentsDict[departament].Count();
                if (departmentCapacity < maxDepartmentCapacity)
                {
                    departmentsDict[departament].Add(patient);
                    doctorsDict[doctor].Add(patient);
                }
                
            }

            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                var departament = tokens[0];

                switch (tokens.Count)
                {
                    case 2:
                        if (departmentsDict.ContainsKey(departament))
                        {
                            int room = int.Parse(tokens[1]);
                            departmentsDict[departament].Skip(3 * (room - 1))
                                .Take(3).OrderBy(p => p)
                                .ToList()
                                .ForEach(p => Console.WriteLine(p));
                        }
                        else
                        {
                            var doctor = tokens[0] + ' ' + tokens[1];
                            if (doctorsDict.ContainsKey(doctor))
                            {
                                doctorsDict[doctor].ToList().ForEach(p => Console.WriteLine(p));
                            }
                        }
                        break;
                    case 1:
                        if (departmentsDict.ContainsKey(departament))
                        {
                            departmentsDict[departament].ToList().ForEach(p => Console.WriteLine(p));
                        }
                        break;
                }
            }


        }
    }
}
