using System;
using System.Collections.Generic;
using System.Text;

public class Bus : Vehicle
{
    private const double summerIncreasedConsumption = 1.4;

    public Bus(string type, double fuelQuantity, double fuelConsumption, double fuelTank) : base(type, fuelQuantity, fuelConsumption, fuelTank)
    {
    }

    public override void Drive(double distance)
    {
        if (base.AirConditioner)
        {
            Drive(distance, base.FuelConsumption + summerIncreasedConsumption);
        }
        else
        {
            Drive(distance, base.FuelConsumption);
        }
    }

    private void Drive(double distance,double consumption)
    {
        var neededFuel = distance * consumption;

        if (neededFuel<=base.FuelQuantity)
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
        if (base.FuelQuantity+fuel<=0)
        {
            Console.WriteLine($"Fuel must be a positive number");
            return;
        }
        else if (base.FuelQuantity+fuel>base.FuelTank)
        {
            Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
        }
        else
        {
            base.FuelQuantity += fuel;
        }
    }
}
