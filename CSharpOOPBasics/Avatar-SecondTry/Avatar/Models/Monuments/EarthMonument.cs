using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EarthMonument : Monument
{
    public EarthMonument(string name,int earthAffinity) : base(name)
    {
        this.EarthAffinity = earthAffinity;
    }

    public int EarthAffinity { get; set; }

    public override int GetAfffinity()
    {
        return EarthAffinity;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Earth Affinity: {EarthAffinity}";
    }
}
