using GrandPrixExam.Models;
using System;

public abstract class Car
{
    private int hp;
    private double fuelAmount;
    private Tyre tyre;

    private const int MaximumFuelTankCapacity = 160;

    public double FuelAmount
    {
        get { return fuelAmount; }
        private set {
            if (value<0)
            {
                throw new ArgumentException("Out of fuel");
            }
            fuelAmount = value; }
    }

    public int Hp
    {
        get;
    }

    public Tyre Tyre
    {
        get => this.tyre;
        private set => this.tyre = value;
    }

    public void ReduceFuel(int length, double fuelConsumption)
    {

    }
}