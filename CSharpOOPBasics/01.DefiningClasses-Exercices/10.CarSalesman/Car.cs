using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    private string model;
    private Engine engine;
    private double? weight;
    private string color;

    public Car(string model, Engine engine)
    {
        this.model = model;
        this.engine = engine;
    }

    public int Weight
    {
        set { this.weight = value; }
    }

    public string Color
    {
        set { this.color = value; }
    }

    public override string ToString()
    {
        var result = $"{this.model}:";
        result = string.Concat(result, Environment.NewLine);
        result = string.Concat(result, this.engine.ToString());
        result = string.Concat(result, Environment.NewLine);

        if (this.weight == null)
        {
            result = string.Concat(result, "  Weight: n/a");
        }
        else result = string.Concat(result, $"  Weight: {this.weight}");
        result = string.Concat(result, Environment.NewLine);
        if (this.color == null)
        {
            result = string.Concat(result, "  Color: n/a");
        }
        else result = string.Concat(result, $"  Color: {this.color}");


        return result;
    }

}
