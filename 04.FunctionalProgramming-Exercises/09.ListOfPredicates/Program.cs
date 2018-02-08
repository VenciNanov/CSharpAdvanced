using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var dividers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse).Distinct();

            var predicates = dividers.Select(div => (Func<int, bool>)(x => x % div == 0)).ToArray();

            var result = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                if (IsValid(predicates,i))
                {
                    result.Add(i);
                }
            }
            Console.WriteLine(string.Join(" ",result));
            

        }

        private static bool IsValid(Func<int, bool>[] predicates, int i)
        {
            foreach (var predicate in predicates)
            {
                if (!predicate(i))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
