using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DriftRace : Race
{
    public DriftRace(int lenght, string route, int prizePool) : base(lenght, route, prizePool)
    {
    }

    public List<Car> GetWinners()
    {
        var winners = this.Participants.Values.OrderByDescending(x => x.GetSuspensionPerformance()).Take(3).ToList();

        return winners;
    }

    public override int GetPerformancePoints()
    {
        var winners = GetWinners();

        var pp = winners.Sum(x => x.GetSuspensionPerformance());

        return pp;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"{this.Route} - {this.Length}");

        var winners = GetWinners();
        var counter = 1;
        var pp = 0;
        var prize = 0;

        foreach (var winner in winners)
        {
            pp = winner.GetSuspensionPerformance();

            if (counter == 1)
            {
                prize = (this.PrizePool * 50) / 100;
            }
            else if (counter == 2)
            {
                prize = (this.PrizePool * 30) / 100;
            }
            else if (counter == 3)
            {
                prize = (this.PrizePool * 20) / 100;
            }

            sb.AppendLine($"{counter}. {winner.Brand} {winner.Model} {pp}PP - ${prize}");
            counter++;
        }
        return sb.ToString().Trim();
    }
}
