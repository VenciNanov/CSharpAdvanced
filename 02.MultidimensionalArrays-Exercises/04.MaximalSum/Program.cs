using System;
using System.Linq;

namespace _04.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var n = input[0];
            var m = input[1];

            int[,] matrix = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                var values = Console.ReadLine()
                   .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();

                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = values[j];
                }
            }
            var sum = 0;
            var rowIndex = 0; var colIndex = 0;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    var tempSum = matrix[row, col] +
                        matrix[row, col + 1] +
                        matrix[row, col + 2] +
                        matrix[row + 1, col] +
                        matrix[row + 1, col + 1] +
                        matrix[row + 1, col + 2] +
                        matrix[row + 2, col] +
                        matrix[row + 2, col + 1] +
                        matrix[row + 2, col + 2];

                    if (tempSum > sum)
                    {
                        sum = tempSum;
                        rowIndex = row;
                        colIndex = col;
                    }
                }

            }
            Console.WriteLine($"Sum = {sum}");
            Console.WriteLine($"{matrix[rowIndex, colIndex]} {matrix[rowIndex, colIndex + 1]} {matrix[rowIndex, colIndex + 2]}");
            Console.WriteLine($"{matrix[rowIndex + 1, colIndex]} {matrix[rowIndex + 1, colIndex + 1]} {matrix[rowIndex + 1, colIndex + 2]}");
            Console.WriteLine($"{matrix[rowIndex + 2, colIndex]} {matrix[rowIndex + 2, colIndex + 1]} {matrix[rowIndex + 2, colIndex + 2]}");
        }
    }
}
