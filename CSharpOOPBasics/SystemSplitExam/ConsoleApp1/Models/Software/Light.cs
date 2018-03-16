using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Light : Software
{
    public Light(string name, int capacityConsumption, int memoryConsumption) : base(name, capacityConsumption, memoryConsumption)
    {
        IncreaseCapacityConsumption();
        DecreaseMemoryConsumption();
    }

    private void DecreaseMemoryConsumption()
    {
        base.MemoryConsumption /= 2;
    }

    private void IncreaseCapacityConsumption()
    {
        base.CapacityConsumption += base.CapacityConsumption / 2;
    }
}
