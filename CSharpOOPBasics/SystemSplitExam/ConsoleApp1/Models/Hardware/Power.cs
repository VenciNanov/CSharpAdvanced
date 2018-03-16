using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Power : Hardware
{
    public Power(string name, int maximumCapacity, int maximumMemory) : base(name, maximumCapacity, maximumMemory)
    {
        DecreaseCapacity();
        IncreaseMemory();
    }

    private void DecreaseCapacity()
    {
        base.MaximumCapacity -= (base.MaximumCapacity * 3) / 4;
    }

    private void IncreaseMemory()
    {
        base.MaximumMemory += (base.MaximumMemory * 3) / 4;
    }
}
