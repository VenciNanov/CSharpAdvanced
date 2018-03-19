using System;
using System.Linq;

namespace _02.Sneaking
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = new char[n][];
            var lineLenght = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {

                char[] inputRow = Console.ReadLine().ToCharArray();
                matrix[i] = new char[n];
                matrix[i] = inputRow;
                lineLenght = inputRow.Count();
            }

            var samRow = 0;
            var samCol = 0;


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < lineLenght; col++)
                {
                    if (matrix[row][col] == 'S')
                    {
                        samRow = row;
                        samCol = col;
                        break;
                    }
                }
            }
            var directions = Console.ReadLine().ToCharArray().ToList();

            var isSamDead = false;

            for (int i = 0; i < directions.Count; i++)
            {
                var direction = directions[i];

                // MovingEnemies(samRow, samCol, matrix,lineLenght);
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int cols = 0; cols < lineLenght; cols++)
                    {
                        if (matrix[row][cols] == 'b' && cols == lineLenght)
                        {
                            matrix[row][cols] = 'd';
                        }
                        else if ((matrix[row][cols] == 'd' && cols == 0))
                        {
                            matrix[row][cols] = 'b';
                        }

                        if (matrix[row][cols] == 'b' && cols > lineLenght)
                        {
                            matrix[row][cols + 1] = 'b';
                            matrix[row][cols] = '.';
                            continue;
                        }
                        else if (matrix[row][cols] == 'd' && cols < lineLenght)
                        {
                            matrix[row][cols - 1] = 'd';
                            matrix[row][cols] = '.';
                        }
                        
                    }
                }

                switch (direction)
                {
                    case 'U':

                        if (matrix[samRow - 1][samCol] == 'b' || matrix[samRow - 1][samCol] == 'd')
                        {
                            matrix[samRow - 1][samCol] = 'S';
                            matrix[samRow][samCol] = '.';
                            samRow++;
                        }
                        else if (!IsInDanger(samRow, samCol, matrix))
                        {
                            Console.WriteLine($"Sam died at{samRow}, {samCol}");
                            continue;
                        }
                        else
                        {

                        }
                        samRow--;
                        break;
                    case 'D':
                        samRow++;
                        break;
                    case 'L':
                        samCol--;
                        break;
                    case 'R':
                        samCol++;
                        break;
                    case 'W':
                        break;
                    default:
                        break;
                }
               
                }
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int colums = 0; colums < lineLenght; colums++)
                {
                    Console.Write(matrix[rows][colums]);
                }
                Console.WriteLine();
                //Console.WriteLine();

            }
        }
    
    public static void MovingEnemies (int samRow, int samCol, char[][] matrix,int lineLenght)
        {
            for (int row = 0; row<matrix.GetLength(0); row++)
            {
                for (int cols = 0; cols < lineLenght; cols++)
                {
                    if (matrix[row][cols]=='b'&&cols<lineLenght)
                    {
                        matrix[row][cols + 1] = 'b';
                        matrix[row][cols] = '.';
                        continue;
                    }
                    else if(matrix[row][cols]=='d'&&cols>lineLenght)
                    {
                        matrix[row][cols - 1] = 'd';
                        matrix[row][cols] = '.';
                    }
                    if (matrix[row][cols]=='b'&& cols==lineLenght)
                    {
                        matrix[row][cols] = 'd';
                    }
                    else if ((matrix[row][cols] == 'd' && cols == 0))
                    {
                        matrix[row][cols] = 'b';
                    }
                }
            }
        }

        public static bool IsInDanger(int samRow, int samCol, char[][] matrix)
{

    bool isInDanger = true;
    for (int i = 0; i < matrix[samRow].Length; i++)
    {
        if (matrix[samRow][i] == 'b')
        {
            if (i < samCol)
            {
                isInDanger = false;
            }
            else isInDanger = true;
        }
        if (matrix[samRow][i] == 'd')
        {
            if (i > samCol)
            {
                isInDanger = false;
            }
            else isInDanger = true;
        }
    }

    return isInDanger;
}
        



       
    }
}
