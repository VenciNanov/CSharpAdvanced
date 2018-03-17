using System;
using System.Collections.Generic;
using System.Text;

public abstract class Provider : IdMiner, IProvider
{
    private string type;
    private double energyOutput;

    protected Provider(string id, double energyOutput)
       : base(id)
    {
        this.type = this.GetType().Name.Replace("Provider", "");

        EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get { return energyOutput; }
        protected set
        {
            if (value < 0 || value > 10000)
            {
                throw new ArgumentException($"Provider is not registered, because of it's {nameof(EnergyOutput)}");
            }
            energyOutput = value;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"{this.type} Provider - {this.Id}");
        sb.AppendLine($"Energy Output: {this.EnergyOutput}");


        return sb.ToString().Trim();
    }

}
