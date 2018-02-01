using System;
using System.Linq;

namespace _01.SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[input[0], input[1]];

            var sum = 0;

            for (int row = 0; row < input[0]; row++)
            {
                var values = Console.ReadLine()
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < input[1]; col++)
                {
                    matrix[row, col] = values[col];

                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sum += matrix[row, col];
                }
            }
            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}
