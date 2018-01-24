using System;
using System.Collections;
using System.Collections.Generic;

namespace _06.TrafficLight
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var input = Console.ReadLine();

            var carsQueue = new Queue<string>();

            var passedCars = 0;

            while (input != "end")
            {
                if (input == "green")
                {
                    var carsCount = carsQueue.Count;

                    for (int i = 0; i < Math.Min(carsCount, n); i++)
                    {
                        Console.WriteLine($"{carsQueue.Dequeue()} passed!");

                        passedCars++;
                    }
                }
                else
                {
                    carsQueue.Enqueue(input);
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }
    }
}
