public class MachineGun : Ammunition
{
    public const double WeightPoints = 10.6;

    public MachineGun(string name)
        : base(name, WeightPoints)
    {
    }
}