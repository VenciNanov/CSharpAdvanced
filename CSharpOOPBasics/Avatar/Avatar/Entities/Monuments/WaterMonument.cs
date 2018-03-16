using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class WaterMonument : Monument
{
    private int waterAffinity;

    public WaterMonument(string name, int waterAffinity) : base(name)
    {
        this.waterAffinity = waterAffinity;
    }

    public override int GetAffinity()
    {
        return waterAffinity;
    }

    public override string ToString() =>
        $"{base.ToString()}, Water Affinity: {this.waterAffinity}";
}
