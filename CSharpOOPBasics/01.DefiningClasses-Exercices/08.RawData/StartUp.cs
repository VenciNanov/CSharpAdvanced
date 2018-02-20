using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        var cars = new Queue<Car>();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var carModel = input[0];
            var engingeSpeed = int.Parse(input[1]);
            var enginePower = int.Parse(input[2]);
            var cargoWeight = int.Parse(input[3]);
            var cargoType = input[4];

            var engine = new CarEngine(engingeSpeed, enginePower);
            var cargo = new CarCargo(cargoWeight, cargoType);
            var tires = new CarTires[]
            {
                new CarTires(int.Parse(input[6]), double.Parse(input[5])),
                new CarTires(int.Parse(input[8]), double.Parse(input[7])),
                new CarTires(int.Parse(input[10]), double.Parse(input[9])),
                new CarTires(int.Parse(input[12]), double.Parse(input[11])),
            };
            cars.Enqueue(new Car(carModel, engine, cargo, tires));
        }

        var line = Console.ReadLine();

        if (line=="fragile")
        {
            Console.WriteLine(string.Join(Environment.NewLine, cars.Where(c => c.Cargo.Type == line && c.Tires.Where(t => t.Pressure < 1).FirstOrDefault()!=null).Select(c=>c.Model)));
        }
        else if(line == "flamable")
        {
            Console.WriteLine(string.Join(Environment.NewLine, cars.Where(c=>c.Cargo.Type==line&&c.Engine.Power>250).Select(c=>c.Model)));
        }
    }
}

