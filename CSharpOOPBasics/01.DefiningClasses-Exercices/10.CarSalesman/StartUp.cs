using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
       
        var engines = new Stack<Engine>();

        var cars = new Queue<Car>();

        var numberOfEngines = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfEngines; i++)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            engines.Push(new Engine(input[0], int.Parse(input[1])));

            if (input.Length>2)
            {
                int displacement;

                var isDigit = int.TryParse(input[2], out displacement);

                if (isDigit)
                {
                    engines.Peek().Displacement = displacement;
                }
                else
                {
                    engines.Peek().Efficiency = input[2];
                }
                if (input.Length>3)
                {
                    if (isDigit)
                    {
                        engines.Peek().Efficiency = input[3];
                    }
                    else
                    {
                        engines.Peek().Displacement = int.Parse(input[3]);
                    }
                }
            }
        }
        var numberOfCars = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfCars; i++)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var currCar = new Car(input[0],engines.Where(x=>x.Model==input[1]).FirstOrDefault());
            if (input.Length>2)
            {
                int weight;
                var isDigit = int.TryParse(input[2], out weight);

                if (isDigit)
                {
                    currCar.Weight = weight;
                }
                else
                {
                    currCar.Color = input[2];
                }

                if (input.Length>3)
                {
                    if (isDigit)
                    {
                        currCar.Color = input[3];
                    }
                    else
                    {
                        currCar.Weight = int.Parse(input[3]);
                    }
                }
            }
            cars.Enqueue(currCar);
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car.ToString());
        }
    }
}