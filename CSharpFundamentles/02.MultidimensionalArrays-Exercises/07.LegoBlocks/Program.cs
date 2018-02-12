using System;
using System.Linq;

namespace _07.LegoBlocks
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            int[][] jaggedOne = new int[n][];
            int[][] jaggedTwo = new int[n][];

            for (int i = 0; i < n; i++)
            {
                jaggedOne[i] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }
            for (int i = 0; i < n; i++)
            {
                jaggedTwo[i] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            for (int i = 0; i < n; i++)
            {
                Array.Reverse(jaggedTwo[i]);
            }

            bool isRestPossible = false;
            var rowsLenghtSum = jaggedOne[0].Length + jaggedTwo[0].Length;

            for (int i = 0; i < n; i++)
            {
                if (jaggedOne[i].Length + jaggedTwo[i].Length != rowsLenghtSum)
                {
                    break;

                }
                else if (i== (n-1))
                {
                    isRestPossible = true;
                }
            }

            if (isRestPossible)
            {
                var arrSum = new int[n][];

                for (int i = 0; i < n; i++)
                {
                    arrSum[i] = new int[rowsLenghtSum];
                    jaggedOne[i].CopyTo(arrSum[i], 0);
                    jaggedTwo[i].CopyTo(arrSum[i],jaggedOne[i].Length);

                    Console.WriteLine("[{0}]",string.Join(", ",arrSum[i]));
                }
            }
            else
            {
                var totalCells = GetCellsNumber(jaggedOne) + GetCellsNumber(jaggedTwo);

                Console.WriteLine($"The total number of cells is: {totalCells}");
            }
        }

       private static int GetCellsNumber (int[][] matrix)
        {
            var result = 0;
            foreach (var array in matrix)
            {
                result += array.Length;
            }
            return result;
        }
    }
}
