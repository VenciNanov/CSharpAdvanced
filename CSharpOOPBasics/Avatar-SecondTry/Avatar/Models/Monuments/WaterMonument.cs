using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class WaterMonument : Monument
{
    public WaterMonument(string name,int waterAffinity) : base(name)
    {
        this.WaterAffinity = waterAffinity;
    }

    public int WaterAffinity { get; set; }

    public override int GetAfffinity()
    {
        return WaterAffinity;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Water Affinity: {WaterAffinity}";
    }
}
