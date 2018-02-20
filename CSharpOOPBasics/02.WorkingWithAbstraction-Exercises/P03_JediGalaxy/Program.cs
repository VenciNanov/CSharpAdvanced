using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[] dimestions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int x = dimestions[0];
            int y = dimestions[1];

            int[,] matrix = new int[x, y];

            FillMatrix(x, y, matrix);

            long sum = Battle(matrix);

            Console.WriteLine(sum);

        }

        public static long Battle(int[,] matrix)
        {
            string command = string.Empty;

            long sum = 0;

            while ((command = Console.ReadLine()) != "Let the Force be with you")
            {
                int[] ivo = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int[] evil = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                EvilMove(matrix, evil);

                sum = IvoMove(matrix, sum, ivo);
            }

            return sum;
        }

        public static long IvoMove(int[,] matrix, long sum, int[] ivo)
        {
            int ivoRow = ivo[0];
            int ivoCol = ivo[1];

            while (ivoRow >= 0 && ivoCol < matrix.GetLength(1))
            {
                if (ivoRow >= 0 && ivoRow < matrix.GetLength(0) && ivoCol >= 0 && ivoCol < matrix.GetLength(1))
                {
                    sum += matrix[ivoRow, ivoCol];
                }

                ivoCol++;
                ivoRow--;
            }

            return sum;
        }

        public static void EvilMove(int[,] matrix, int[] evil)
        {
            int evilRow = evil[0];
            int evilCol = evil[1];

            while (evilRow >= 0 && evilCol >= 0)
            {
                if (evilRow >= 0 && evilRow < matrix.GetLength(0) && evilCol >= 0 && evilCol < matrix.GetLength(1))
                {
                    matrix[evilRow, evilCol] = 0;
                }
                evilRow--;
                evilCol--;
            }
        }

        public static void FillMatrix(int x, int y, int[,] matrix)
        {
            int value = 0;

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = value++;
                }
            }
        }
    }
}
