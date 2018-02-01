using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.RubiksMatrix
{
    class RubiksMatrix
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var rowsInput = input[0];
            var colsInput = input[1];

            int[][] rubik = new int[rowsInput][];

            for (int i = 0; i < rowsInput; i++)
            {
                rubik[i] = new int[colsInput];

                for (int j = 0; j < colsInput; j++)
                {
                    rubik[i][j] = i * colsInput + j + 1;
                }
            }

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var commands = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                var rowOrCol = int.Parse(commands[0]);
                var direction = commands[1];
                var moves = int.Parse(commands[2]);

                switch (direction)
                {
                    case "up":
                        MoveUp(rubik, rowOrCol, moves);
                        break;

                    case "down":
                        MoveDown(rubik, rowOrCol, moves);
                        break;

                    case "right":
                        MoveRight(rubik, rowOrCol, moves);
                        break;

                    case "left":
                        MoveLeft(rubik, rowOrCol, moves);
                        break;
                }
            }

            var numOfElements = rowsInput * colsInput;

            var flatRubik = new int[numOfElements];

            var k = -1;

            for (int i = 0; i < rowsInput; i++)
            {
                for (int j = 0; j < colsInput; j++)
                {
                    k++;
                    flatRubik[k] = rubik[i][j];
                }
            }

            for (int ie = 0; ie < numOfElements; ie++)
            {
                if (flatRubik[ie]==ie+1)
                {
                    Console.WriteLine("No swap required");
                }
                else
                {
                    var temp = flatRubik[ie];
                    var srch = Array.IndexOf(flatRubik, ie + 1);

                    flatRubik[srch] = temp;
                    flatRubik[ie] = ie + 1;

                    Console.WriteLine($"Swap ({ie/rowsInput}, {ie%colsInput}) with ({srch/rowsInput}, {srch%colsInput})");
                }
            }
        }

        private static void MoveLeft(int[][] rubik, int rowOrCol, int moves)
        {
            var cols = rubik[rowOrCol].Length;
            var rest = moves % cols;
            var rowQueue = new Queue<int>();

            for (int i = 0; i < cols; i++)
            {
                rowQueue.Enqueue(rubik[rowOrCol][i]);
            }

            for (int j = 0; j < rest; j++)
            {
                rowQueue.Enqueue(rowQueue.Dequeue());
            }

            for (int i = 0; i < cols; i++)
            {
                rubik[rowOrCol][i] = rowQueue.Dequeue();
            }
        }

        private static void MoveRight(int[][] rubik, int rowOrCol, int moves)
        {
            var cols = rubik[rowOrCol].Length;
            var rest = moves % cols;
            var rowQueue = new Queue<int>();

            for (int i = cols - 1; i >= 0; i--)
            {
                rowQueue.Enqueue(rubik[rowOrCol][i]);
            }
            for (int i = 0; i < rest; i++)
            {
                rowQueue.Enqueue(rowQueue.Dequeue());
            }
            for (int i = cols - 1; i >= 0; i--)
            {
                rubik[rowOrCol][i] = rowQueue.Dequeue();
            }
        }

        private static void MoveDown(int[][] rubik, int rowOrCol, int moves)
        {
            var rows = rubik.Length;
            var rest = moves % rows;
            var col = new Queue<int>();

            for (int j = rows - 1; j >= 0; j--)
            {
                col.Enqueue(rubik[j][rowOrCol]);
            }

            for (int i = 0; i < rest; i++)
            {
                col.Enqueue(col.Dequeue());
            }

            for (int j = rows - 1; j >= 0; j--)
            {
                rubik[j][rowOrCol] = col.Dequeue();
            }
        }

        private static void MoveUp(int[][] rubik, int rowOrCol, int moves)
        {
            var rows = rubik.Length;
            var rest = moves % rows;
            Queue<int> col = new Queue<int>();

            for (int j = 0; j < rows; j++)
            {
                col.Enqueue(rubik[j][rowOrCol]);
            }

            for (int i = 0; i < rest; i++)
            {
                col.Enqueue(col.Dequeue());
            }

            for (int j = 0; j < rows; j++)
            {
                rubik[j][rowOrCol] = col.Dequeue();
            }
        }
    }
}
