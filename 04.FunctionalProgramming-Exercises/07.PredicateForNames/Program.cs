using System;
using System.Linq;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var names = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Print(names, x => x.Length <= n);


        }

        private static void Print(string[] names, Func<string, bool> filter)
        {
            Console.WriteLine(string.Join(Environment.NewLine, names.Where(filter)));
        }
    }
}
