﻿using System;
using System.Collections.Generic;
using System.Text;

public class Ferrari : ICar
{
    public Ferrari(string model,string driver)
    {
        this.Model = model;
        this.Driver = driver;
    }

    public string Model { get; private set; }

    public string Driver { get; private set; }

    public string Brakes()
    {
        return "Brakes!";
    }

    public string Gas()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"{this.Model}/{this.Brakes()}/{this.Gas()}/{this.Driver}";
    }
}
