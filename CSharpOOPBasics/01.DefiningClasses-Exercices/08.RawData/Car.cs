using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    private string model;
    private CarEngine engine;
    private CarCargo cargo;
    private CarTires[] tires;

    public Car(string model, CarEngine engine, CarCargo cargo, CarTires[] tires)
    {
        this.model = model;
        this.engine = engine;
        this.cargo = cargo;
        this.tires = tires;
    }

    public string Model
    {
        get { return this.model; }
    }

    public CarEngine Engine
    {
        get { return this.engine; }
    }

    public CarCargo Cargo
    {
        get { return this.cargo; }
    }

    public CarTires[] Tires
    {
        get { return this.tires; }
    }
}

