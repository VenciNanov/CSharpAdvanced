using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    private string model;
    private double fuelAmount;
    private double fuelConsumption;
    private double distanceTraveled;

    public Car(string model, double fuelAmount, double fuelConsumption)
    {
        this.model = model;
        this.fuelAmount = fuelAmount;
        this.fuelConsumption = fuelConsumption;
        this.distanceTraveled = 0.0;
    }

    public double DistanceTraveled
    {
        get { return distanceTraveled; }
        set { distanceTraveled = value; }
    }

    public double FuelConsumption
    {
        get { return fuelConsumption; }
    }

    public double FuelAmount
    {
        get { return fuelAmount; }
        set { fuelAmount = value; }
    }

    public string Model
    {
        get { return model; }
    }

    public void Driving(double distance)
    {
        var neededFuel = distance * this.fuelConsumption;

        if (this.fuelAmount < neededFuel)
        {
            System.Console.WriteLine("Insufficient fuel for the drive");
            return;
        }

        this.fuelAmount -= neededFuel;
        this.distanceTraveled += distance;
    }
}
