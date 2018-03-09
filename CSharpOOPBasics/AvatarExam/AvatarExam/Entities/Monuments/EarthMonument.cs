using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EarthMonument : Monument
{
    private int earthAffinity;
    public EarthMonument(string name,int earthAffinity) : base(name)
    {
        this.earthAffinity = earthAffinity;
    }

    public override int GetAffinity()
    {
        return this.earthAffinity;
    }
}
