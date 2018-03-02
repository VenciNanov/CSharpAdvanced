using System;
using System.Linq;

namespace _01.Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputCar = Console.ReadLine().Split();
            var inputTruck = Console.ReadLine().Split();

            var car = new Car(double.Parse(inputCar[1]), double.Parse(inputCar[2]));

            var truck = new Truck(double.Parse(inputTruck[1]), double.Parse(inputTruck[2]));

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split();

                var command = tokens[0];
                var type = tokens[1];
                var param = double.Parse(tokens[2]);

                switch (type)
                {
                    case "Car":
                        ExecuteCommand(car, command, param);
                        break;
                    case "Truck":
                        ExecuteCommand(truck, command, param);
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");

        }

        private static void ExecuteCommand(IVehicle vehicle, string command, double param)
        {
            switch (command)
            {
                case "Drive":
                    vehicle.Drive(param);
                    break;
                case "Refuel":
                    vehicle.Refill(param);
                    break;
            }
        }
    }
}
