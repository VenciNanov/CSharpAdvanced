﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AirMonument : Monument
{
    public AirMonument(string name,int airAffinity) : base(name)
    {
        this.AirAffinity = airAffinity;
    }

    public int AirAffinity { get; set; }

    public override int GetAfffinity()
    {
        return AirAffinity;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Air Affinity: {AirAffinity}";
    }
}
