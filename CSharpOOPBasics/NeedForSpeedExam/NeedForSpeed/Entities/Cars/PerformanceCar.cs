using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PerformanceCar : Car
{
    private List<string> addOns;

    public PerformanceCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
         : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
        this.AddOns = new List<string>();
        this.Horespower += horsepower * 50 / 100;
        this.Suspension -= suspension * 25 / 100;
    }

    public List<string> AddOns
    {
        get;
    }

    public override string ToString()
    {
        var sb = base.ToString();

        if (this.AddOns.Any())
        {
            sb+= Environment.NewLine + $"Add-ons: {string.Join(", ",this.AddOns)}";
        }
        else
        {
            sb += Environment.NewLine + $"Add-ons: None";
        }

        return sb.ToString().Trim();
    }
}
