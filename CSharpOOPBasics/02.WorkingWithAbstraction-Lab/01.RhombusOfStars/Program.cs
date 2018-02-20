using System;

namespace _01.RhombusOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            PrintTopSide(n);
            PrintBottomSide(n);
        }

        private static void PrintBottomSide(int n)
        {
            for (int row = n - 1; row >= 1; row--)
            {
                for (int c = 1; c <= n - row; c++)
                {
                    Console.Write(' ');
                }
                Console.Write('*');
                for (int i = 1; i < row; i++)
                {
                    Console.Write(" *");
                }
                Console.WriteLine();
            }
        }

        private static void PrintTopSide(int n)
        {
            for (int row = 1; row <= n; row++)
            {
                for (int i = 1; i <= n - row; i++)
                {
                    Console.Write(' ');
                }
                Console.Write('*');
                for (int c = 1; c < row; c++)
                {
                    Console.Write(" *");
                }
                Console.WriteLine();
            }
        }
    }
}
