using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AirMonument : Monument
{
    private int airAffinity;

    public AirMonument(string name,int airAffinity) : base(name)
    {
        this.airAffinity = airAffinity;
    }

    public override int GetAffinity()
    {
        return this.airAffinity;
    }
}

