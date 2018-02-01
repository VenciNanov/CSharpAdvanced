using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var type = Console.ReadLine().Trim().ToLower();

            Predicate<int> isOddOrEven;

            switch (type)
            {
                case "odd":
                    isOddOrEven = n => n % 2 != 0;
                    break;
                case "even":
                    isOddOrEven = n => n % 2 == 0;
                    break;
                default:
                    isOddOrEven = null;
                    break;
            }

            var result = FindEvensOrOdds(input[0], input[1], isOddOrEven);

            Console.WriteLine(string.Join(" ", result));
        }

        private static List<int> FindEvensOrOdds(int start, int end, Predicate<int> filter)
        {
            var result = new List<int>();
            for (int i = start; i <= end; i++)
            {
                if (filter(i))
                {
                    result.Add(i);   
                }
            }
            return result;
        }
    }
}
