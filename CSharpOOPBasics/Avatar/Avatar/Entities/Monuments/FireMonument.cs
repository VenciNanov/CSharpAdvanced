using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class FireMonument : Monument
{
    private int fireAffinity;
    public FireMonument(string name, int fireAffinity) : base(name)
    {
        this.fireAffinity = fireAffinity;
    }

    public override int GetAffinity()
    {
        return this.fireAffinity;
    }

    public override string ToString() =>
       $"{base.ToString()}, Fire Affinity: {this.fireAffinity}";

}