using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            Action<IEnumerable<string>> action = collection => Console.WriteLine(string.Join(Environment.NewLine, collection.Select(name=>$"Sir {name}")));

            action(input);
        }
    }
}
