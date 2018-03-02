using System;
using System.Collections.Generic;
using System.Text;

public class Truck : Vehicle
{
    private const double summerIncreasedConsumption = 1.6;

    public Truck(string type, double fuelQuantity, double fuelConsumption, double fuelTank) : base(type, fuelQuantity, fuelConsumption, fuelTank)
    {
    }

    public override void Drive(double distance)
    {
        double neededFuel = distance * (base.FuelConsumption + summerIncreasedConsumption);

        if (neededFuel <= base.FuelQuantity)
        {
            Console.WriteLine($"{Type} travelled {distance} km");
            base.FuelQuantity -= neededFuel;
        }
        else
        {
            Console.WriteLine($"{Type} needs refueling");
        }
    }

    public override void Refill(double fuel)
    {
        if (fuel <= 0)
        {
            Console.WriteLine($"Fuel must be a positive number");
            return;
        }
        else if (base.FuelQuantity + fuel > base.FuelTank)
        {
            Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
        }
        else
        {
            base.FuelQuantity += (fuel * 0.95);
        }
    }
}
