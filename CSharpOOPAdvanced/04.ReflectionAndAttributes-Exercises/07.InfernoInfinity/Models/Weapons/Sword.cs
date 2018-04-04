using System;
using System.Collections.Generic;
using System.Text;

public class Sword : Weapon
{
    private const int minDmg = 4;
    private const int maxDmg = 6;
    private const int NumberOfSockets = 3;

    public Sword(string name, WeaponRarityLevel weaponRarity) : base(name, minDmg, maxDmg, NumberOfSockets, weaponRarity)
    {
    }
}
