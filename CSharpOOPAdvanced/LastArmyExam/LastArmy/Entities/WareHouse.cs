using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class WareHouse:IWareHouse
{
    private readonly IAmmunitionFactory ammunitionFactory;

    public WareHouse(IAmmunitionFactory ammunitionFactory)
    {
        this.ammunitionFactory = ammunitionFactory;
        this.Ammunitions = new List<IAmmunition>();
    }

    public IList<IAmmunition> Ammunitions { get; set; }

    public void AddAmmunitions(string name, int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            this.Ammunitions.Add(this.ammunitionFactory.CreateAmmunition(name));
        }
    }

    public void EquipArmy(IArmy army)
    {
        foreach (var soldier in army.Soldiers)
        {
            this.TryEquipSoldier(soldier);
        }
    }

    public bool TryEquipSoldier(ISoldier soldier)
    {
        bool isEquiped = true;

        List<string> missingAmmo = soldier.Weapons.Where(x => x.Value == null).Select(x => x.Key).ToList();

        foreach (var missingWeapon in missingAmmo)
        {
            foreach (var ammunition in this.Ammunitions)
            {
                if (missingWeapon == ammunition.Name)
                {
                    var weapon = this.Ammunitions.FirstOrDefault(x => x.Name == missingWeapon);
                    soldier.Weapons[missingWeapon] = weapon;
                    this.Ammunitions.Remove(weapon);
                    break;
                }
                else
                {
                    isEquiped = false;
                }
            }
        }
        return isEquiped;

    }
}

