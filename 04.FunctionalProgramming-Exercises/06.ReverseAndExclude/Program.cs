using System;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);

            var n = int.Parse(Console.ReadLine());

            Func<int, bool> filter = x => x % n != 0;

            var remainingNumbers = numbers.Reverse().Where(filter);

            Console.WriteLine(string.Join(" ",remainingNumbers));
        }
    }
}
