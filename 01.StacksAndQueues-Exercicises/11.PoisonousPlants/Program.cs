﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PoisonousPlants
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var plants = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var days = new int[n];
            var indexes = new Stack<int>();
            indexes.Push(0);

            for (int i = 0; i < plants.Length; i++)
            {
                int maxDays = 0;

                while (indexes.Count>0 && plants[indexes.Peek()]>= plants[i])
                {
                    maxDays = Math.Max(maxDays, days[indexes.Pop()]);
                }
                if (indexes.Count>0)
                {
                    days[i] = maxDays + 1;
                }

                indexes.Push(i);
            }
            Console.WriteLine(days.Max());
        }
    }
}
