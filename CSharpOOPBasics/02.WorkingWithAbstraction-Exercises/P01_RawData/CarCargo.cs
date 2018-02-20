using System;
using System.Collections.Generic;
using System.Text;

public class CarCargo
{
    private int cargoWeight;
    private string cargoType;

    public CarCargo(int cargoWeight,string cargoType)
    {
        this.cargoWeight = cargoWeight;
        this.cargoType = cargoType;
    }

    public string Type
    {
        get { return this.cargoType; }
    }
}
