using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Corporal : Soldier
{
    private const double OverallSkillMiltiplier = 2.5;
    private const int RegenerateValue = 10;

    private readonly List<string> weaponsAllowed = new List<string>
        {
            nameof(Gun),
            nameof(AutomaticMachine),
            nameof(MachineGun),
            nameof(Helmet),
            nameof(Knife),
        };

    public Corporal(string name, int age, double expirience, double endurance) : base(name, age, expirience, endurance)
    {
    }

    protected override IReadOnlyList<string> WeaponsAllowed => this.weaponsAllowed;

    public override double OverallSkill => base.OverallSkill * OverallSkillMiltiplier;

    public override void Regenerate()
    {
        this.Endurance += this.Age + RegenerateValue;
    }
}
