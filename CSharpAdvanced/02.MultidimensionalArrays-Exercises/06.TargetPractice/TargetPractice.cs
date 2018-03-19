using System;
using System.Linq;

namespace _06.TargetPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var rowsInput = input[0];
            var colsInput = input[1];

            var word = Console.ReadLine();

            var target = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            char[][] playfield = new char[rowsInput][];

            //filling

            int charIndex = 0;
            bool reverse = true;

            for (int i = rowsInput - 1; i >= 0; i--)
            {
                playfield[i] = new char[colsInput];
                if (reverse)
                {
                    for (int j = colsInput - 1; j >= 0; j--)
                    {
                        playfield[i][j] = word[charIndex];
                        charIndex = (charIndex + 1) % word.Length;
                    }
                    reverse = false;
                }
                else
                {
                    for (int j = 0; j < colsInput; j++)
                    {
                        playfield[i][j] = word[charIndex];
                        charIndex = (charIndex + 1) % word.Length;
                    }
                    reverse = true;
                }
            }

            int posRow = target[0];
            int posCol = target[1];
            int radius = target[2];

            //Bombing

            for (int i = 0; i < rowsInput; i++)
            {
                for (int j = 0; j < colsInput; j++)
                {
                    if (Math.Sqrt(Math.Pow((posRow - i), 2) + Math.Pow((posCol - j), 2)) <= radius)
                    {
                        playfield[i][j] = ' ';
                    }
                }
            }

            //Colapse

            for (int j = 0; j < colsInput; j++)
            {
                for (int i = rowsInput - 1; i >= 0; i--)
                {
                    if (playfield[i][j] == ' ')
                    {
                        var tempRowIndex = i;
                        while (playfield[i][j]==' ')
                        {
                            tempRowIndex--;
                            if (tempRowIndex < 0)
                            {
                                break;
                            }
                            else if (playfield[tempRowIndex][j]!=' ')
                            {
                                playfield[i][j] = playfield[tempRowIndex][j];
                                playfield[tempRowIndex][j] = ' ';
                            }

                        }

                    }
                }
            }

            //printing

            foreach (var ch in playfield)
            {
                Console.WriteLine(string.Join("",ch));
            }
        }
    }
}
