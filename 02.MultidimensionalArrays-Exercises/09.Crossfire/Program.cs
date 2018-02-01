using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _09.Crossfire
{
    class Program
    {
        private const int Empty = 0;

        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var rows = dimensions[0];
            var cols = dimensions[1];

            // var matrix = new int[rows][];

            var target = new List<List<long>>();

            var counter = 1;


            for (int i = 0; i < rows; i++)
            {
                target.Add(new List<long>());
                for (int j = 0; j < cols; j++)
                {
                    target[i].Add(counter++);

                }
            }

            var input = Console.ReadLine();

            while (input != "Nuke it from orbit")
            {

                var shoot = Regex.Split(input.Trim(), "\\s+").Select(int.Parse).ToArray();

                var r = shoot[0];
                var c = shoot[1];
                var radius = shoot[2];
                BombMatrix(target, r, c, radius);

                for (int i = 0; i < target.Count; i++)
                {
                    var rowVals = target[i].Where(n => n > 0).ToList();
                    
                }

            }
            input = Console.ReadLine();
        }

        private static void BombMatrix(List<List<long>> target, int r, int c, int radius)
        {
            if (r >= 0 && r < target[0].Count)
            {
                for (int coll = Math.Max(0, c - r); coll <= Math.Min(c + radius, target[r].Count - 1); coll++)
                {
                    target[r][coll] = 0;
                }
            }
            if (c >= 0 && c < target[0].Count)
            {
                for (int roww = Math.Max(0, r - radius); roww <= Math.Min(r + r, target.Count - 1); roww++)
                {
                    if (c < target[roww].Count)
                    {
                        target[roww][c] = 0;
                    }
                }
            }
        }
    }
}

