using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class NationsBuilder
{
    private Dictionary<string, Nation> nations;
    private List<string> warHistoryRecord;

    public NationsBuilder()
    {
        this.nations = new Dictionary<string, Nation>()
        {
            {"Air",new Nation() },
            {"Fire",new Nation() },
            {"Earth",new Nation() },
            {"Water",new Nation() }
        };
        this.warHistoryRecord = new List<string>();
    }

    public void AssignBender(List<string> benderArgs)
    {
        var type = benderArgs[0];

        Bender bender = this.GetBender(benderArgs);
        this.nations[type].AddBender(bender);
    }

    private Bender GetBender(List<string> args)
    {
        var type = args[0];
        var name = args[1];
        var power = int.Parse(args[2]);
        var param = double.Parse(args[3]);

        switch (type)
        {
            case "Air":
                return new AirBender(name, power, param);

            case "Fire":
                return new FireBender(name, power, param);

            case "Earth":
                return new EarthBender(name, power, param);

            case "Water":
                return new WaterBender(name, power, param);

            default:
                throw new ArgumentException();
        }
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        var type = monumentArgs[0];

        Monument monument = GetMonument(monumentArgs);
        this.nations[type].AddMonument(monument);

    }

    private Monument GetMonument(List<string> monumentArgs)
    {
        var type = monumentArgs[0];
        var name = monumentArgs[1];
        var power = int.Parse(monumentArgs[2]);

        switch (type)
        {
            case "Air":
                return
                    new AirMonument(name, power);

            case "Water":
                return new WaterMonument(name, power);

            case "Fire":
                return new FireMonument(name, power);

            case "Earth":
                return new EarthMonument(name, power);
            default:
                throw new ArgumentException();
        }
    }

    public string GetStatus(string nationsType)
    {
        var result = new StringBuilder();

        result.AppendLine($"{nationsType} Nation").Append(this.nations[nationsType]);

        return result.ToString();
    }
    public void IssueWar(string nationsType)
    {
        double vicoriousPower = this.nations.Max(x => x.Value.GetTotalPower());

        foreach (var nation in this.nations.Values)
        {
            if (nation.GetTotalPower()!=vicoriousPower)
            {
                nation.DeclareDefeat();
            }
        }

        this.warHistoryRecord.Add($"War {this.warHistoryRecord.Count + 1} issued by {nationsType}");
    }
    public string GetWarsRecord() => string.Join(Environment.NewLine, this.warHistoryRecord);


}
