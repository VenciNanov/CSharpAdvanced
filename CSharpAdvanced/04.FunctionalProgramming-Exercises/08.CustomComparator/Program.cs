using System;
using System.Linq;

namespace _08.CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Array.Sort(input);

            Console.WriteLine(string.Join(" ", input.OrderBy(n=>n%2!=0).ThenBy(n=>n%2==0)));
        }
    }
}
