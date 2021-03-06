﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AirBender : Bender
{
    private double aerialIntegrity;

    public AirBender(string name, int power, double aerialIntegrity) : base(name, power)
    {
        this.aerialIntegrity = aerialIntegrity;
    }

    public override double GetPower() => this.aerialIntegrity * this.Power;
    public override string ToString() =>
        $"{base.ToString()}, Aerial Integrity: {this.aerialIntegrity:f2}";

}
