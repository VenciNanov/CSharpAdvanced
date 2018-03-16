using System;
using System.Collections.Generic;
using System.Text;

public abstract class Harvester : Miner
{
    private double oreOutput;
    private double energyRequirement;

    public Harvester(string id, double oreOutput, double energyRequirement) : base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }
       
    public double EnergyRequirement
    {
        get { return energyRequirement; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(EnergyRequirement), $"Value must be a positive");
            }
            if (value > 20000)
            {
                throw new ArgumentOutOfRangeException(nameof(EnergyRequirement), $"Value mus be less than 20000");
            }
            energyRequirement = value;
        }
    }

    public double OreOutput
    {
        get { return oreOutput; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(OreOutput), $"Value must be a positive");
            }
            oreOutput = value;
        }
    }

    public override string ToString()
    {
        var type = string.Empty;

        if (this.GetType().Name.Equals("HammerHarvester"))
        {
            type = "Hammer";
        }
        else if (this.GetType().Name.Equals("SonicHarvester"))
        {
            type = "Sonic";
        }

        return $"{type} Harvester - {this.Id}{Environment.NewLine}" +
            $"Ore Output: {OreOutput}{Environment.NewLine}" +
            $"Energy Requirement: {EnergyRequirement}";
    }
}