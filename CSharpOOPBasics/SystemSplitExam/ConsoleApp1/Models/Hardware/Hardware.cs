using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Hardware
{
    private string name;
    private int maximumCapacity;
    private int maximumMemory;
    private List<Software> softowares;

    public Hardware(string name, int maximumCapacity, int maximumMemory)
    {
        this.Name = name;
        this.MaximumCapacity = maximumCapacity;
        this.MaximumMemory = maximumMemory;
        this.softowares = new List<Software>();
    }

    public int MaximumMemory
    {
        get { return maximumMemory; }
        protected set { maximumMemory = value; }
    }

    public int MaximumCapacity
    {
        get { return maximumCapacity; }
        protected set { maximumCapacity = value; }
    }

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    public int TotalOperationMemoryInUse => softowares.Sum(s => s.MemoryConsumption);

    public int TotalCapacityTaken => softowares.Sum(s => s.CapacityConsumption);

    public List<Software> Softwares
    {
        get { return this.softowares; }
    }

    public void AddSoftwareComponent(Software software)
    {
        var currentSoftwareCapacity = software.CapacityConsumption;
        var currentSoftwareMemory = software.MemoryConsumption;

        if (MaximumCapacity - (TotalCapacityTaken + currentSoftwareCapacity) < 0 || MaximumMemory - (TotalOperationMemoryInUse + currentSoftwareMemory) < 0)
        {
            throw new ArgumentException();
        }
        this.softowares.Add(software);
    }

    public Software RealeaseSoftwareComponent(string softwareComponent)
    {
        if (!softowares.Exists(x=>x.Name==softwareComponent))
        {
            throw new ArgumentOutOfRangeException();
        }

        Software software = softowares.FirstOrDefault(x => x.Name == softwareComponent);
        softowares.Remove(software);

        return software;
    }
}
