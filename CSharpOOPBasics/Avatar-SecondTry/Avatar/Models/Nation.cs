using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Nation
{
    private List<Bender> benders;
    private List<Monument> monuments;

    public Nation()
    {
        this.benders = new List<Bender>();
        this.monuments = new List<Monument>();
    }

    public double GetTotalPower()
    {
        var monumentsPercentage = this.monuments.Sum(x => x.GetAfffinity());
        var totalBendersPower = this.benders.Sum(x => x.GetPower());
        var totalPowerIncreased = totalBendersPower / 100 * monumentsPercentage;

        return totalBendersPower + totalPowerIncreased;
    }

    public void AddBender(Bender bender) => this.benders.Add(bender);
    public void AddMonument(Monument monument) => this.monuments.Add(monument);

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.Append("Benders:");
        if (this.benders.Any())
        {
            sb.AppendLine().AppendLine(string.Join(Environment.NewLine, this.benders.Select(x => $"###{x}")));
        }
        else
        {
            sb.AppendLine(" None");
        }

        sb.Append("Monuments:");
        if (this.monuments.Any())
        {
            sb.Append(string.Join(Environment.NewLine, this.monuments.Select(x => $"###{x}")));
        }
        else
        {
            sb.Append($" None");
        }

        return sb.ToString();
    }

    public void DeclareDefeat()
    {
        this.benders.Clear();
        this.monuments.Clear();
    }
}