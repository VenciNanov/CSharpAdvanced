using System;
using System.Linq;

namespace _08.RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var row = input[0];
            var col = input[1];

            var output = string.Empty;
            var cave = new char[row, col];

            for (int i = 0; i < row; i++)
            {
                var caveInput = Console.ReadLine().Trim();
                for (int j = 0; j < col; j++)
                {
                    cave[i, j] = caveInput[j];
                }
            }

            var finalCave = new char[row, col];
            Array.Copy(cave, finalCave, cave.Length);

            var commandInput = Console.ReadLine().Trim();

            var dead = false;
            var escaped = false;

            for (int i = 0; i < commandInput.Length; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    for (int k = 0; k < col; k++)
                    {
                        if (!cave[j, k].Equals('P')) continue;
                        switch (commandInput[i])
                        {

                            case 'U':
                                try
                                {
                                    if (finalCave[j - 1, k].Equals('B'))
                                    {
                                        output = $"dead: {j - 1} {k}";
                                        finalCave[j, k] = '.';
                                        dead = true;
                                    }
                                    else
                                    {
                                        finalCave[j - 1, k] = 'P';
                                        finalCave[j, k] = '.';
                                    }
                                }
                                catch (Exception)
                                {
                                    output = $"won: {j} {k}";
                                    escaped = true;
                                    finalCave[j, k] = '.';
                                }
                                break;
                            case 'L':
                                try
                                {
                                    if (finalCave[j, k - 1].Equals('B'))
                                    {
                                        output = $"dead: {j} {k - 1}";
                                        finalCave[j, k] = '.';
                                        dead = true;
                                    }
                                    else
                                    {
                                        finalCave[j, k - 1] = 'P';
                                        finalCave[j, k] = '.';
                                    }
                                }
                                catch (Exception)
                                {
                                    output = $"won: {j} {k}";
                                    escaped = true;
                                    finalCave[j, k] = '.';
                                }
                                break;
                            case 'R':
                                try
                                {
                                    if (finalCave[j, k + 1].Equals('B'))
                                    {
                                        output = $"dead: {j} {k + 1}";
                                        finalCave[j, k] = '.';
                                        dead = true;
                                    }
                                    else
                                    {
                                        finalCave[j, k + 1] = 'P';
                                        finalCave[j, k] = '.';
                                    }
                                }
                                catch (Exception)
                                {
                                    output = $"won: {j} {k}";
                                    escaped = true;
                                    finalCave[j, k] = '.';
                                }
                                break;
                            case 'D':
                                try
                                {
                                    if (finalCave[j + 1, k].Equals('B'))
                                    {
                                        output = $"dead: {j + 1} {k}";
                                        finalCave[j, k] = '.';
                                        dead = true;
                                    }
                                    else
                                    {
                                        finalCave[j + 1, k] = 'P';
                                        finalCave[j, k] = '.';
                                    }
                                }
                                catch (Exception)
                                {
                                    output = $"won: {j} {k}";
                                    escaped = true;
                                    finalCave[j, k] = '.';
                                }
                                break;
                        }
                    }
                }

                for (int j = 0; j < row; j++)
                {
                    for (int k = 0; k < col; k++)
                    {
                        if (!cave[j, k].Equals('B'))
                        {
                            continue;
                        }
                        try
                        {
                            var element = finalCave[j - 1, k];
                            if (element.Equals('P'))
                            {
                                dead = true;
                                output = $"dead: {j - 1}{k}";
                            }

                            finalCave[j - 1, k] = 'B';
                        }
                        catch (Exception)
                        {

                        }
                        try
                        {
                            var element = finalCave[j + 1, k];
                            if (element.Equals('P'))
                            {
                                dead = true;
                                output = $"dead: {j + 1} {k}";
                            }
                            finalCave[j + 1, k] = 'B';
                        }
                        catch (Exception)
                        {
                            // ignored
                        }
                        try
                        {
                            var element = finalCave[j, k - 1];
                            if (element.Equals('P'))
                            {
                                dead = true;
                                output = $"dead: {j } {k - 1}";
                            }
                            finalCave[j, k - 1] = 'B';
                        }
                        catch (Exception)
                        {
                            // ignored
                        }
                        try
                        {
                            var element = finalCave[j, k + 1];
                            if (element.Equals('P'))
                            {
                                dead = true;
                                output = $"dead: {j } {k + 1}";
                            }
                            finalCave[j, k + 1] = 'B';
                        }
                        catch (Exception)
                        {
                            // ignored
                        }
                        finalCave[j, k] = 'B';

                    }

                }
                Array.Copy(finalCave, cave, finalCave.Length);
                if (!dead&& !escaped)
                {
                    continue;
                }
                for (int l = 0; l < row; l++)
                {
                    for (int m = 0; m < col; m++)
                    {
                        Console.Write(finalCave[l,m]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine(output);
                return;
            }
        }
    }
}
