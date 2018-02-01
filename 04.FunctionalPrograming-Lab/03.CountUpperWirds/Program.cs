using System;
using System.Linq;

namespace _03.CountUpperWirds
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            
            Func<string, bool> checker = n => n[0] == n.ToUpper()[0];

            input.Where(checker).ToList().ForEach(n => Console.WriteLine(n));
        }
    }
}
