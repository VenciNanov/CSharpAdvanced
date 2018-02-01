using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            Action<List<string>> action = Print;
            action(input);
        }

        private static void Print(List<string> obj)
        {
            Console.WriteLine(string.Join(Environment.NewLine, obj));
        }
    }
}
