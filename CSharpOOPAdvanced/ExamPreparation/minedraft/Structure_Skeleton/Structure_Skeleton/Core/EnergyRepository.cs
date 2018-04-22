public class EnergyRepository : IEnergyRepository
{
    public EnergyRepository()
    {
        this.EnergyStored = 0;
    }

    public double EnergyStored { get; private set; }

    public void StoreEnergy(double energy)
    {
        this.EnergyStored += energy;
    }

    public bool TakeEnergy(double energyNeeded)
    {
        if (EnergyStored - energyNeeded >= 0)
        {
            EnergyStored -= energyNeeded;
            return true;
        }
        return false;
    }
}

