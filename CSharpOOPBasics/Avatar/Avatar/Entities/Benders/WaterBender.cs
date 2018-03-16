using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class WaterBender : Bender
{
    private double waterClarity;

    public WaterBender(string name, int power, double waterClarity) : base(name, power)
    {
        this.waterClarity = waterClarity;
    }

    public override double GetPower()
    {
        return waterClarity * this.Power;
    }

    public override string ToString() =>
        $"{base.ToString()}, Water Clarity: {this.waterClarity:f2}";

}
