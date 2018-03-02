using System;
using System.Collections.Generic;
using System.Text;

public class Car : IVehicle
{
    private double fuelQuantity;
    private double fuelConsumption;

    private const double summerIncreasedConsumption = 0.9;

    public double FuelConsumption
    {
        get { return fuelConsumption; }
        set { fuelConsumption = value; }
    }

    public double FuelQuantity
    {
        get { return fuelQuantity; }
        set { fuelQuantity = value; }
    }

    public Car(double fuelQuantity, double fuelConsumption)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumption = fuelConsumption;
    }

    public void Drive(double distance)
    {
        var neededFuel = distance * (this.FuelConsumption + summerIncreasedConsumption);

        if (neededFuel <= FuelQuantity)
        {
            FuelQuantity -= neededFuel;
            Console.WriteLine($"Car travelled {distance} km");
        }
        else
        {
            Console.WriteLine("Car needs refueling");
        }
    }

    public void Refill(double fuelAmount)
    {
        FuelQuantity += fuelAmount;
    }
}
