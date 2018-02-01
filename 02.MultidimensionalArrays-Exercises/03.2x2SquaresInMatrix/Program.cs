using System;
using System.Linq;

namespace _03._2x2SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rowsInput = input[0];
            var colsInput = input[1];

            char[,] matrix = new char[rowsInput, colsInput];

            for (int i = 0; i < rowsInput; i++)
            {
                var inputs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int j = 0; j < colsInput; j++)
                {
                    matrix[i, j] = inputs[j];
                }
            }

            var squareCount = 0;
            
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] && matrix[row , col] == matrix[row + 1, col]&& matrix[row, col] == matrix[row+1, col+1])
                    {
                        squareCount++;
                    }
                }
            }
            Console.WriteLine(squareCount);
        }
    }
}
