using System;
using System.Linq;

namespace _02.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            int[][] matrix = new int[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = Console.ReadLine().Split(new char[] { ' '},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            var sum = 0;

            for (int row = 0; row < n; row++)
            {
                sum += matrix[row][row];
            }

            var sum2 = 0;

            for (int row = 0, col = n - 1; row < n; row++, col--)
            {
                sum2 += matrix[row][col];
            }

            Console.WriteLine(Math.Abs(sum - sum2));
        }
    }
}
