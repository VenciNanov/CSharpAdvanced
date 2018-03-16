using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private List<Harvester> harvesters;
    private List<Provider> providers;

    private double totalEnergyProvided;
    private double totalMinedOre;

    private ModeType mode;

    public DraftManager()
    {
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();

        this.mode = ModeType.Full;
    }

    public string RegisterHarvester(List<string> arguments)
    {
        var type = arguments[0];

        try
        {
            Harvester harvester = HarvesterFactory.Create(arguments);
            harvesters.Add(harvester);
            return $"Successfully registered {type} Harvester - {harvester.Id}";
        }
        catch (ArgumentOutOfRangeException aoore)
        {
            return $"Harvester is not registered, because of it's {aoore.ParamName}";

        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        var type = arguments[0];

        try
        {
            Provider provider = ProviderFactory.Create(arguments);
            providers.Add(provider);

            return $"Successfully registered {type} Provider - {provider.Id}";

        }
        catch (ArgumentOutOfRangeException aoore)
        {
            return $"Provider is not registered, because of it's {aoore.ParamName}";
        }
    }

    public string Day()
    {
        var currentEnergyProvided = this.providers.Sum(p => p.EnergyOutput);

        this.totalEnergyProvided += currentEnergyProvided;

        var totalEnergyRequirement = CalculateEnergyByRequiredMode();

        StringBuilder sb = new StringBuilder();

        sb.Append($"A day has passed.{Environment.NewLine}");
        sb.Append($"Energy Provided: {currentEnergyProvided}{Environment.NewLine}");

        if (this.totalEnergyProvided >= totalEnergyRequirement)
        {
            this.totalEnergyProvided -= totalEnergyRequirement;
            var totalOreOutput = CalculateOreOutput();

            this.totalMinedOre += totalOreOutput;

            sb.Append($"Plumbus Ore Mined: {totalOreOutput}");
        }
        else
        {
            sb.Append($"Plumbus Ore Mined: 0");
        }

        return sb.ToString();

    }

    private double CalculateOreOutput()
    {
        double ore = this.harvesters.Sum(h => h.OreOutput * (double)this.mode / 100);

        return ore;

    }

    private double CalculateEnergyByRequiredMode()
    {
        double energy = 0;

        if (this.mode.ToString() == "Half")
        {
            energy += this.harvesters.Sum(h => h.EnergyRequirement * (((double)this.mode + 10) / 100));
        }
        else
        {
            energy += this.harvesters.Sum(h => h.EnergyRequirement * (((double)this.mode) / 100));
        }
        return energy;
    }

    public string Mode(List<string> arguments)
    {
        var newMode = arguments[0];

        Enum.TryParse(newMode, out this.mode);

        return $"Successfully changed working mode to {this.mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        var checkId = arguments[0];

        if (this.harvesters.Any(h => h.Id == checkId))
        {
            Harvester harvester = this.harvesters.FirstOrDefault(h => h.Id == checkId);
            return harvester.ToString();
        }
        else if (this.providers.Any(x => x.Id == checkId))
        {
            Provider provider = this.providers.FirstOrDefault(x => x.Id == checkId);
            return provider.ToString();
        }
        else
        {
            return $"No element found with id - {checkId}";
        }
    }

    public string ShutDown()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"System Shutdown");
        sb.AppendLine($"Total Energy Stored: {this.totalEnergyProvided}");
        sb.AppendLine($"Total Mined Plumbus Ore: {this.totalMinedOre}");

        return sb.ToString().Trim();
    }
}
