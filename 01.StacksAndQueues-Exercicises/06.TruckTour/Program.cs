using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            var entries = int.Parse(Console.ReadLine());

            var pumps = new Queue<int[]>();

            for (int i = 0; i < entries; i++)
            {
                pumps.Enqueue(Console.ReadLine().Split().Select(int.Parse).ToArray());
            }

            for (int i = 0; i < entries; i++)
            {
                if (IsSoulution(entries,pumps))
                {
                    Console.WriteLine(i);
                    break;
                }
                int[] startringPump = pumps.Dequeue();
                pumps.Enqueue(startringPump);
            }
        }

        static bool IsSoulution(int entries, Queue<int[]> pumps)
        {
            var tankFuel = 0;
            bool foundAnswer = true;

            for (int i = 0; i < entries; i++)
            {
                int[] currPump = pumps.Dequeue();
                tankFuel += currPump[0] - currPump[1];

                if (tankFuel<0)
                {
                    foundAnswer = false;
                }
                pumps.Enqueue(currPump);
            }

            if (foundAnswer)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
