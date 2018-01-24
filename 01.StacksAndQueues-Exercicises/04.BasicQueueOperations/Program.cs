using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').ToArray();
            var pushQueue = int.Parse(input[0]);
            var popQueue = int.Parse(input[1]);
            var numberToFind = int.Parse(input[2]);

            var numbers = Console.ReadLine().Split(' ').ToArray();
            var parsedNumbers = Array.ConvertAll(numbers, int.Parse);

            var queue = new Queue<int>();

            for (int i = 0; i < pushQueue; i++)
            {
                queue.Enqueue(parsedNumbers[i]);
            }

            for (int i = 0; i < popQueue; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (queue.Contains(numberToFind))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }

        }
    }
}
