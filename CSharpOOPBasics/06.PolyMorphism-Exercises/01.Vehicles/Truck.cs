using System;
using System.Collections.Generic;
using System.Text;

public class Truck : IVehicle
{
    private double fuelQuantity;
    private double fuelConsumption;
    private double distancetoDrive;

    private const double summerIncreasedConsumption = 1.6;

    public double DistanceToDrive
    {
        get { return distancetoDrive; }
        set { distancetoDrive = value; }
    }

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

    public Truck(double fuelQuantity, double fuelConsumption)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumption = fuelConsumption;
    }

    public void Drive(double distance)
    {
        var neededFuel = distance * (this.FuelConsumption + summerIncreasedConsumption);

        if (neededFuel <= FuelQuantity)
        {
            fuelQuantity -= neededFuel;
            Console.WriteLine($"Truck travelled {distance} km");
        }
        else
        {
            Console.WriteLine("Truck needs refueling");
        }
    }

    public void Refill(double fuelAmount)
    {
        FuelQuantity += (fuelAmount * 0.95);
    }
}
