using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Race
{
    public Race(int lenght,string route,int prizePool)
    {
        this.Length = lenght;
        this.Route = route;
        this.PrizePool = prizePool;
        this.Participants = new Dictionary<int, Car>();
    }

    public int Length { get; private set; }
    public string Route { get; private set; }
    public int PrizePool { get; private set; }
    public Dictionary<int, Car> Participants { get; private set; }

    public abstract int GetPerformancePoints();
}
