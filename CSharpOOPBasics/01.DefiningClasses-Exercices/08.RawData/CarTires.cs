using System;
using System.Collections.Generic;
using System.Text;

public class CarTires
{
    private int age;
    private double pressure;

    public CarTires(int age, double pressure)
    {
        this.age = age;
        this.pressure = pressure;
    }
    public double Pressure
    {
        get { return this.pressure; }
    }
}

