using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.ParkingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var rows = input[0];
            var cols = input[1];

            var parking = new Dictionary<int, HashSet<int>>();

            var line = string.Empty;

            while ((line = Console.ReadLine()) != "stop")
            {
                var tokens = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                var entryRow = tokens[0];
                var endRow = tokens[1];
                var endCol = tokens[2];

                var parkCol = 0;

                if (!IsOccupied(parking, endRow, endCol))
                {
                    parkCol = endCol;
                }
                else
                {
                    for (int i = 1; i < cols - 1; i++)
                    {
                        if (((endCol - i) > 0) && !IsOccupied(parking, endRow, (endCol - i)))
                        {
                            parkCol = (endCol - i);
                            break;
                        }
                        else if (((endCol + i) < cols) && !IsOccupied(parking, endRow, (endCol + i)))
                        {
                            parkCol = (endCol + i);
                            break;
                        }
                    }
                }
                if (parkCol == 0)
                {
                    Console.WriteLine($"Row {endRow} full");
                }
                else
                {
                    parking[endRow].Add(parkCol);
                    var steps = Math.Abs(entryRow - endRow) + 1 + parkCol;
                    Console.WriteLine(steps);
                }
            }

        }

        private static bool IsOccupied(Dictionary<int, HashSet<int>> parking, int endRow, int endCol)
        {
            if (parking.ContainsKey(endRow))
            {
                if (parking[endRow].Contains(endCol))
                {
                    return true;
                }
            }
            else
            {
                parking.Add(endRow, new HashSet<int>());
            }
            return false;
        }
    }
}