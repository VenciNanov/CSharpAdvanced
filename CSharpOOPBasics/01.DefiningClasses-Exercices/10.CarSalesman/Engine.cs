using System;
using System.Collections.Generic;
using System.Text;


public class Engine
{
    private string model;
    private int power;
    private int? displacement;
    private string efficiency;

    public Engine(string model, int power)
    {
        this.model = model;
        this.power = power;
    }

    public string Model
    {
        get { return this.model; }
    }

    public int Displacement
    {
        set { this.displacement = value; }
    }

    public string Efficiency
    {
        set { this.efficiency = value; }
    }

    public override string ToString()
    {
        var result = $"  {this.model}:";
        result = string.Concat(result, Environment.NewLine);
        result = string.Concat(result, $"   Power: {this.power}");
        result = string.Concat(result, Environment.NewLine);
        if (this.displacement == null)
        {
            result = string.Concat(result, "   Displacement: n/a");
        }
        else result = string.Concat(result, $"   Displacement: {this.displacement}");

        result = string.Concat(result, Environment.NewLine);

        if (this.efficiency == null)
        {
            result = string.Concat(result, "   Efficiency: n/a");
        }
        else result = string.Concat(result, $"   Efficiency: {this.efficiency}");

        

        return result;
    }

}
