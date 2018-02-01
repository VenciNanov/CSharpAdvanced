using System;
using System.Linq;

namespace _04.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).Select(n=>n*1.2).ToList();

            foreach (var n in input)
            {
                Console.WriteLine($"{n:f2}");
            }

        }
    }
}
