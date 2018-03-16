using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Software
{
    private string name;
    private int capacityConsumption;
    private int memoryConsumption;
    public Software(string name, int capacityConsumption, int memoryConsumption)
    {
        this.Name = name;
        this.CapacityConsumption = capacityConsumption;
        this.MemoryConsumption = memoryConsumption;
    }
    public int MemoryConsumption
    {
        get { return memoryConsumption; }
        protected set { memoryConsumption = value; }
    }

    public int CapacityConsumption
    {
        get { return capacityConsumption; }
        protected set { capacityConsumption = value; }
    }

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    public override string ToString()
    {
        return $"{Name}";
    }

}
