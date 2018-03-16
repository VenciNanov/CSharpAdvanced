using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Race
{
    private int length;
    private string route;
    private int prizePool;
    private Dictionary<int, Car> participants;

    public Race(int length, string route, int prizePool)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
        this.Paritcipants = new Dictionary<int, Car>();

    }

    public Dictionary<int, Car> Paritcipants
    {
        get { return participants; }
        protected set { participants = value; }
    }

    public int PrizePool
    {
        get { return prizePool; }
        protected set { prizePool = value; }
    }

    public string Route
    {
        get { return route; }
        protected set { route = value; }
    }

    public int Length
    {
        get { return length; }
        protected set { length = value; }
    }

    public abstract int GetPerformancePoints();

}
