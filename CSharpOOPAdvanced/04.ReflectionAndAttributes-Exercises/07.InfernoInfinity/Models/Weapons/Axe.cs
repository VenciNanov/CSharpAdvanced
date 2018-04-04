using System;
using System.Collections.Generic;
using System.Text;

public class Axe : Weapon
{
    private const int minDmg = 5;
    private const int maxDmg = 10;
    private const int NumberOfSockets = 4;

    public Axe(string name, WeaponRarityLevel weaponRarity) : base(name, minDmg, maxDmg, NumberOfSockets, weaponRarity)
    {
    }
}
