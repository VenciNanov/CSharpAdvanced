using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Bender
{
    protected Bender(string name,int power)
    {
        this.Name = name;
        this.Power=power;
    }

    public string Name { get; }
    public int Power { get; protected set; }

    public abstract double GetPower();

    public override string ToString()
    {
        string type = this.GetType().Name;
        int typeEnd = type.IndexOf("Bender");
        type = type.Insert(typeEnd, " ");

        return $"{type}: {this.Name}, Power: {this.Power}";
    }
}
