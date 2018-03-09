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
        int monumentsIncreasePercentage = this.monuments.Sum(x => x.GetAffinity());
        double totalBendersPower = this.benders.Sum(x => x.GetPower());
        double totalPowerIncrease = totalBendersPower / 100 * monumentsIncreasePercentage;

        return totalBendersPower + totalPowerIncrease;
    }

    public void AddBender(Bender bender) => this.benders.Add(bender);

}
