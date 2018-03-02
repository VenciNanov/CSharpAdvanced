using System;
using System.Linq;


class StartUp
{
    static void Main(string[] args)
    {
        Car car;
        Truck truck;
        Bus bus;

        GetVehicles(out car, out truck, out bus);

        Drive(car, truck, bus);

        PrintVehicles(car, truck, bus);

    }

    private static void PrintVehicles(Car car, Truck truck, Bus bus)
    {
        Console.WriteLine(car);
        Console.WriteLine(truck);
        Console.WriteLine(bus);
    }

    private static void Drive(Car car, Truck truck, Bus bus)
    {
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
                case "Bus":
                    ExecuteCommand(bus, command, param);
                    break;
                default:
                    break;
            }
        }
    }

    private static void GetVehicles(out Car car, out Truck truck, out Bus bus)
    {
        var inputCar = Console.ReadLine().Split();
        var inputTruck = Console.ReadLine().Split();
        var inputBus = Console.ReadLine().Split();

        car = new Car(inputCar[0], double.Parse(inputCar[1]), double.Parse(inputCar[2]), double.Parse(inputCar[3]));
        truck = new Truck(inputTruck[0], double.Parse(inputTruck[1]), double.Parse(inputTruck[2]), double.Parse(inputTruck[3]));
        bus = new Bus(inputBus[0], double.Parse(inputBus[1]), double.Parse(inputBus[2]), double.Parse(inputBus[3]));
    }

    private static void ExecuteCommand(Vehicle vehicle, string command, double param)
    {
        switch (command)
        {
            case "Drive":
                vehicle.AirConditioner = true;
                vehicle.Drive(param);
                break;
            case "Refuel":
                vehicle.AirConditioner = true;
                vehicle.Refill(param);
                break;
            case "DriveEmpty":
                vehicle.AirConditioner = false;
                vehicle.Drive(param);
                break;
        }
    }
}