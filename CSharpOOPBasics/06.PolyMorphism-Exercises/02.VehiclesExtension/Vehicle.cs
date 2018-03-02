using System;
using System.Collections.Generic;
using System.Text;

public abstract class Vehicle : IVehicle
{
    private string type;
    private double fuelQuantity;
    private double fuelConsumption;
    private double fuelTank;
    private bool airConditioner;

    public double FuelTank
    {
        get
        {
            return this.fuelTank;
        }
        private set
        {

            this.fuelTank = value;
        }
    }

    public string Type
    {
        get
        {
            return this.type;
        }
        private set
        {
            this.type = value;
        }
    }

    public double FuelQuantity
    {
        get
        {
            return this.fuelQuantity;
        }
        set
        {
            if (value > this.FuelTank)
            {
                this.fuelQuantity = 0;
            }
            else
            {
                this.fuelQuantity = value;
            }
        }
    }

    public double FuelConsumption
    {
        get
        {
            return this.fuelConsumption;
        }
        set
        {
            this.fuelConsumption = value;
        }
    }



    public bool AirConditioner
    {
        get
        {
            return this.airConditioner;
        }
        set
        {
            this.airConditioner = value;
        }
    }

    protected Vehicle(string type, double fuelQuantity, double fuelConsumption, double fuelTank)
    {
        Type = type;
        FuelTank = fuelTank;
        FuelQuantity = fuelQuantity;
        FuelConsumption = fuelConsumption;

    }

    public abstract void Drive(double distance);

    public abstract void Refill(double fuel);

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
    }
}
