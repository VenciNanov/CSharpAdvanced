using System;
using System.Linq;

namespace _01.MatrixOfPalindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var rows = input[0];
            var cols = input[1];

            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            int[,] matrix = new int[rows, cols];


            for (char i = 'a'; i <= alphabet[0] + rows - 1; i++)
            {
                for (char j = i; j < i + cols; j++)
                {
                    var letters = i.ToString() + j.ToString() + i.ToString();
                    Console.Write($"{letters} ");
                }
                Console.WriteLine();
            }

        }
    }
}
