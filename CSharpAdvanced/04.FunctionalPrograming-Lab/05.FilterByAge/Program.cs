using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var ppl = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                var names = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                ppl[names[0]] = int.Parse(names[1]);

            }
            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();



            Func<int, bool> tester = CreateTester(condition, age);

            Action<KeyValuePair<string, int>> printer = CreatePrinter(format);

            PrintFilteredStudents(ppl, tester, printer);
        }

        public static void PrintFilteredStudents(Dictionary<string, int> ppl, Func<int, bool> tester, Action<KeyValuePair<string, int>> printer)
        {
            

            foreach (var person in ppl)
            {
                if (tester(person.Value))
                {
                    printer(person);
                }
            }
        }

        public static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return person => Console.WriteLine($"{person.Key}");
                case "age":
                    return person => Console.WriteLine($"{person.Value}");
                case "name age":
                    return person => Console.WriteLine($"{person.Key} - {person.Value}");
                default: return null;
            }
        }

        public static Func<int, bool> CreateTester(string condition, int age)
        {
            switch (condition)
            {
                case "younger": return x => x < age;
                case "older": return x => x >= age;
                default: return null;
            }
        }
    }
}
