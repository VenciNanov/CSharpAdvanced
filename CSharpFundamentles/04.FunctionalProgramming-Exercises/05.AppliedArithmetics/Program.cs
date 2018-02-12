using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            var command = string.Empty;

            Predicate<int> type;



            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "add":
                        input = ForEach(input, n => n + 1);
                        break;
                    case "subtract":
                        input = ForEach(input, n => n - 1);
                        break;
                    case "multiply":
                        input = ForEach(input, n => n * 2);
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ",input));
                        break;
                    default:
                        break;
                }
            }

        }

        private static IEnumerable<int> ForEach(IEnumerable<int> input, Func<int, int> func)
        {
            return input.Select(n => func(n));
        }
    }
}
