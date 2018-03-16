using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Express : Software
{
    public Express(string name, int capacityConsumption, int memoryConsumption) : base(name, capacityConsumption, memoryConsumption)
    {
        DoubleConsumption();
    }

    private void DoubleConsumption()
    {
        base.MemoryConsumption *= 2;
    }
}
