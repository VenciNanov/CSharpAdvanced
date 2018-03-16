using System;
using System.Collections.Generic;
using System.Text;

public abstract class Provider : Miner
{
    private double energyOutput;

    public Provider(string id, double energyOutput) : base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get { return energyOutput; }
        protected set
        {
            if (value < 0)
            {
                throw new System.ArgumentOutOfRangeException(
                    nameof(EnergyOutput),
                    $"Value must be a positive"
                    );
            }

            if (value > 10000)
            {
                throw new System.ArgumentOutOfRangeException(
                    nameof(EnergyOutput),
                    $"Value must be less than 10000"
                    );

            }
            energyOutput = value;
        }
    }



    public override string ToString()
    {
        var str = string.Empty;

        if (this.GetType().Name.Equals("SolarProvider"))
        {
            str = "Solar";
        }
        else if (this.GetType().Name.Equals("PressureProvider"))
        {
            str = "Pressure";
        }

        return $"{str} Provider - {Id}{Environment.NewLine}" +
$"Energy Output: {EnergyOutput}";
    }
}