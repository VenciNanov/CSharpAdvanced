using System;
using System.Linq;

namespace _03.GroupNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var sizes = new int[3];

            foreach (var num in input)
            {
                sizes[Math.Abs(num % 3)]++;
            }

            int[][] jagged = new int[3][];

            for (int counter = 0; counter < sizes.Length; counter++)
            {
                jagged[counter] = new int[sizes[counter]];
            }

            int[] index = new int[3];

            foreach (var num in input)
            {
                var remainder =Math.Abs(num % 3);
                jagged[remainder][index[remainder]] = num;
                index[remainder]++;
            }

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(string.Join(" ",jagged[i]));
            }


        }
    }
}
