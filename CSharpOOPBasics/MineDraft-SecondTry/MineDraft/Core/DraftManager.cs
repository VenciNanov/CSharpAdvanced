using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private string mode;
    private List<Harvester> harvesters;
    private List<Provider> providers;

    private double totalEnergyProvided;
    private double totalMinedOre;

    public DraftManager()
    {
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
        this.mode = "Full";
        this.totalEnergyProvided = 0;
        this.totalMinedOre = 0;
    }

    public string RegisterHarvester(List<string> arguments)
    {
        var harvesterType = arguments[0];
        try
        {
            Harvester harvester = HarvesterFactory.Create(arguments);
            harvesters.Add(harvester);

            return $"Successfully registered {harvesterType} Harvester - {harvester.Id}";
        }
        catch (ArgumentException ex)
        {
            return ex.Message;
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
        catch (ArgumentException ex)
        {
            return ex.Message;
        }
    }
    public string Day()
    {
        var dayEnergy = 0.0;
        var dayOre = 0.0;
        var harvestNeededEnergy = 0.0;

        dayEnergy = providers.Sum(x => x.EnergyOutput);
        totalEnergyProvided += dayEnergy;

        harvestNeededEnergy += harvesters.Sum(x => x.EnergyRequirement);

        if (totalEnergyProvided >= harvestNeededEnergy)
        {
            if (mode == "Full")
            {
                dayOre += harvesters.Sum(x => x.OreOutput);
                totalEnergyProvided -= harvestNeededEnergy;
            }
            else if (mode == "Half")
            {
                dayOre += harvesters.Sum(x => (x.OreOutput * 50) / 100);
                totalEnergyProvided -= harvestNeededEnergy * 60 / 100;
            }

            totalMinedOre += dayOre;
        }

        var sb = new StringBuilder();

        sb.AppendLine($"A day has passed.");
        sb.AppendLine($"Energy Provided: {dayEnergy}");
        sb.AppendLine($"Plumbus Ore Mined: {dayOre}");

        return sb.ToString().Trim();
    }

    public string Mode(List<string> arguments)
    {
        var modeToChange = arguments[0];

        if (modeToChange == "Half")
        {
            this.mode = modeToChange;
        }
        else if (modeToChange == "Full")
        {
            this.mode = modeToChange;
        }
        else
        {
            this.mode = modeToChange;
        }

        return $"Successfully changed working mode to {this.mode} Mode";
    }
    public string Check(List<string> arguments)
    {
        var checkId = arguments[0];

        if (providers.Any(x => x.Id == checkId))
        {
            Provider provider = this.providers.FirstOrDefault(x => x.Id == checkId);
            return provider.ToString().Trim();
        }
        else if (this.harvesters.Any(x => x.Id == checkId))
        {
            Harvester harvester = this.harvesters.FirstOrDefault(x => x.Id == checkId);
            return harvester.ToString().Trim();
        }
        else
        {
            return $"No element found with id - {checkId}";
        }
    }
    public string ShutDown()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"System Shutdown");
        sb.AppendLine($"Total Energy Stored: {totalEnergyProvided}");
        sb.AppendLine($"Total Mined Plumbus Ore: {totalMinedOre}");

        return sb.ToString().Trim();
    }

}
