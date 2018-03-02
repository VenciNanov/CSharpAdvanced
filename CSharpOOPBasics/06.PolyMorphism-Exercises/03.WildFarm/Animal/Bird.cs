using System;
using System.Collections.Generic;
using System.Text;

public abstract class Bird : Animal, IBird
{
    private double wingSize;

    public Bird(string animalType, string name, double weight,double wingSize) : base(animalType, name, weight)
    {
        this.WingSize = wingSize;
    }

    public double WingSize
    {
        get { return wingSize; }
        set { wingSize = value; }
    }
}
