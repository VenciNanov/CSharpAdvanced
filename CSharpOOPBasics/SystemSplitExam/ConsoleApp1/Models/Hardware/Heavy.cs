using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Heavy : Hardware
{
    public Heavy(string name, int maximumCapacity, int maximumMemory) : base(name, maximumCapacity, maximumMemory)
    {
        DecreaseMemory();
        IncreaseCapacity();
    }

    private void DecreaseMemory()
    {
        base.MaximumMemory -= (base.MaximumMemory / 4);
    }

    private void IncreaseCapacity()
    {
        base.MaximumCapacity *= 2;
    }
}
