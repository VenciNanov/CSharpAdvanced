using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FireBender : Bender
{
    public FireBender(string name, int power, double heatAggression) : base(name, power)
    {
        this.HeatAggression = heatAggression;
    }

    public double HeatAggression { get; set; }

    public override double GetPower()
    {
        return this.Power * HeatAggression;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Heat Aggression: {this.HeatAggression:f2}";
    }
}
