using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Startup
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        var cars = new Queue<Car>();

        for (int i = 0; i < n; i++)
        {
            var inputCar = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var carModel = inputCar[0];
            var carFuelAmount = double.Parse(inputCar[1]);
            var carFuelConsumption = double.Parse(inputCar[2]);

            cars.Enqueue(new Car(carModel, carFuelAmount, carFuelConsumption));
        }

        var line = string.Empty;
        while ((line = Console.ReadLine()) != "End")
        {
            var inputLine = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var carModel = inputLine[1];
            var amountOfKm = double.Parse(inputLine[2]);


            var currCar = cars.Where(c => c.Model == carModel).FirstOrDefault();
            if (currCar!=null)
            {
                currCar.Driving(amountOfKm);
            }
        }

        Console.WriteLine(string.Join(Environment.NewLine,cars.Select(c=>$"{c.Model} {c.FuelAmount:f2} {c.DistanceTraveled}")));
    }
}

