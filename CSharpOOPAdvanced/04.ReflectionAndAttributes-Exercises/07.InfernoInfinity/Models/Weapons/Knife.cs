using System;
using System.Collections.Generic;
using System.Text;

public class Knife : Weapon
{
    private const int minDmg = 3;
    private const int maxDmg = 4;
    private const int NumberOfSockets = 2;

    public Knife(string name, WeaponRarityLevel weaponRarity) : base(name, minDmg, maxDmg, NumberOfSockets, weaponRarity)
    {
    }
}
