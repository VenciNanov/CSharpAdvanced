using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FireMonument : Monument
{
    public FireMonument(string name, int fireAffinity) : base(name)
    {
        this.FireAffinity = fireAffinity;
    }

    public int FireAffinity { get; set; }

    public override int GetAfffinity()
    {
        return FireAffinity;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Fire Affinity: {FireAffinity}";
    }
}
