using System;
using System.Collections.Generic;
using System.Text;


public class CarEngine
{
    private int speed;
    private int power;

    public CarEngine(int speed, int power)
    {
        this.speed = speed;
        this.power = power;
    }

    public int Power
    {
        get { return this.power; }
    }
}
