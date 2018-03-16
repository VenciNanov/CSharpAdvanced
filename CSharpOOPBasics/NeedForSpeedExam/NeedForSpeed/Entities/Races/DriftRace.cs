using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DriftRace : Race
{
    public DriftRace(int length, string route, int prizePool) : base(length, route, prizePool)
    {
    }
    public List<Car> GetWinners()
    {
        var winners = this.Paritcipants.Values.OrderByDescending(c => c.GetSuspensionPerformance())
            .Take(3)
            .ToList();
        return winners;
    }

    public override int GetPerformancePoints()
    {
        var winners = GetWinners();

        var performancePoints = winners.Sum(x => x.GetSuspensionPerformance());

        return performancePoints;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"{this.Route} - {this.Length}");

        var winners = GetWinners();
        var counter = 1;
        var participant = 0;
        var prize = 0;
        foreach (var winner in winners)
        {
            participant = winner.GetSuspensionPerformance();

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
            sb.AppendLine($"{counter}. {winner.Brand} {winner.Model} {participant}PP - ${prize}");
            counter++;
        }

        return sb.ToString().Trim();
    }
}