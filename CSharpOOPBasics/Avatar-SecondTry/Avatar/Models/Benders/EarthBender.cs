using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EarthBender : Bender
{
    public EarthBender(string name, int power,double groundSaturation) : base(name, power)
    {
        this.GroundSaturation = groundSaturation;
    }

    public double GroundSaturation { get; set; }

    public override double GetPower()
    {
        return this.Power * this.GroundSaturation;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Ground Saturation: {this.GroundSaturation:f2}";
    }
}
