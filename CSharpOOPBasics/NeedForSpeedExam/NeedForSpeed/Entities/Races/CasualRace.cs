using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CasualRace : Race
{
    public CasualRace(int length, string route, int prizePool) : base(length, route, prizePool)
    {
    }

    public List<Car> GetWinners()
    {
        var winners = this.Paritcipants.Values.OrderByDescending(c => c.GetOverallPerformance())
            .Take(3)
            .ToList();
        return winners;
    }

    public override int GetPerformancePoints()
    {
        var winners = GetWinners();

        var performancePoints = winners.Sum(x => x.GetOverallPerformance());

        return performancePoints;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"{this.Route} - {this.Length}");

        var winners = GetWinners();
        var conter = 1;
        var participant = 0;
        var prize = 0;
        foreach (var winner in winners)
        {
            participant = winner.GetOverallPerformance();

            if (conter == 1)
            {
                prize = (this.PrizePool * 50) / 100;
            }
            else if (conter == 2)
            {
                prize = (this.PrizePool * 30) / 100;
            }
            else if (conter == 3)
            {
                prize = (this.PrizePool * 20) / 100;
            }
            sb.AppendLine($"{conter}. {winner.Brand} {winner.Model} {participant}PP - ${prize}");
            conter++;
        }

        return sb.ToString().Trim();
    }
}