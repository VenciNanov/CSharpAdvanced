using System;
using System.Linq;

namespace _02.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            char[][] table = new char[n][];

            for (int i = 0; i < table.Length; i++)
            {
                char[] inputRow = Console.ReadLine().ToCharArray();
                table[i] = new char[n];
                table[i] = inputRow;
            }

            var currentKnightsInDanger = 0;
            var maxKnightsInDanger = -1;
            var mostDangerousKnightRow = 0;
            var mostDangerousKnightCol = 0;
            int count = 0;


            while (true)
            {
                for (int row = 0; row < table.Length; row++)
                {
                    for (int col = 0; col < table[row].Length; col++)
                    {
                        if (table[row][col].Equals('K'))
                        {
                            //Vertical
                            //Up LEFT
                            if (IsCellInMatrix(row - 2, col - 1, table))
                            {
                                if (table[row - 2][col - 1].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }
                            //Up Right
                            if (IsCellInMatrix(row - 2, col + 1, table))
                            {
                                if (table[row - 2][col + 1].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }
                            //Down Left
                            if (IsCellInMatrix(row + 2, col - 1, table))
                            {
                                if (table[row + 2][col - 1].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }
                            //Down Right
                            if (IsCellInMatrix(row + 2, col + 1, table))
                            {
                                if (table[row + 2][col + 1].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }
                            //horizontal
                            //

                            if (IsCellInMatrix(row - 1, col - 2, table))
                            {
                                if (table[row - 1][col - 2].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }
                            //Up Right
                            if (IsCellInMatrix(row - 1, col + 2, table))
                            {
                                if (table[row - 1][col + 2].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }
                            //Down Left
                            if (IsCellInMatrix(row + 1, col - 2, table))
                            {
                                if (table[row + 1][col - 2].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }
                            //Down Right
                            if (IsCellInMatrix(row + 1, col + 2, table))
                            {
                                if (table[row + 1][col + 2].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }
                        }

                        if (currentKnightsInDanger > maxKnightsInDanger)
                        {
                            maxKnightsInDanger = currentKnightsInDanger;
                            mostDangerousKnightRow = row;
                            mostDangerousKnightCol = col;

                        }
                        currentKnightsInDanger=0;
                    }
                }
                if (maxKnightsInDanger != 0)
                {
                    table[mostDangerousKnightRow][mostDangerousKnightCol] = 'O';
                    count++;
                    maxKnightsInDanger = 0;
                }
                else
                {
                    Console.WriteLine(count);
                    return;
                }
            }
        }
        public static bool IsCellInMatrix(int row, int col, char[][] matrix)
        {
            if (0 <= row && row < matrix.Length && 0 <= col & col < matrix[row].Length)
            {
                return true;
            }
            return false;

        }
    }
}
