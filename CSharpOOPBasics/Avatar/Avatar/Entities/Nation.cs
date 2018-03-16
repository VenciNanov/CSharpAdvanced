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
        var monumentsIncreasePercentage = this.monuments.Sum(x => x.GetAffinity());
        var totalBendersPower = this.benders.Sum(x => x.GetPower());
        var totalPowerIncrease = totalBendersPower / 100 * monumentsIncreasePercentage;

        return totalBendersPower + totalPowerIncrease;
    }

    public void AddBender(Bender currentBender) => this.benders.Add(currentBender);

    public void AddMonument(Monument currentMonument) => this.monuments.Add(currentMonument);

    public override string ToString()
    {
        var result = new StringBuilder();
        result.Append("Benders:");
        if (this.benders.Any())
        {
            result.AppendLine()
                .AppendLine(string.Join(Environment.NewLine, this.benders.Select(bender => $"###{bender}")));
        }
        else
        {
            result.AppendLine(" None");
        }

        result.Append("Monuments:");
        if (this.monuments.Any())
        {
            result.AppendLine()
                .AppendLine(string.Join(Environment.NewLine, this.monuments.Select(m => $"###{m}")));
        }
        else
        {
            result.Append(" None");
        }

        return result.ToString();
    }

    public void DeclareDefeat()
    {
        this.benders.Clear();
        this.monuments.Clear();
    }
}
