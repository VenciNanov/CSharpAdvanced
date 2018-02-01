using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            var evenNumbers = input.Where(x => x % 2 == 0).ToList();

            Console.WriteLine(string.Join(", ",evenNumbers.OrderBy(x=>x)));
            
             
        }
    }
}
