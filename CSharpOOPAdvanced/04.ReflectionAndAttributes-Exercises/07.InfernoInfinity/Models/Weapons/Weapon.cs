using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Weapon : IWeapon
{
    private string name;
    private int minDmg;
    private int maxDmg;
    private IGem[] sockets;

    protected Weapon(string name, int minDmg, int maxDmg, int numberOfSockets, WeaponRarityLevel weaponRarity)
    {
        this.Name = name;
        this.MinDmg = minDmg * (int)weaponRarity;
        this.MaxDmg = maxDmg * (int)weaponRarity;

        this.sockets = new IGem[numberOfSockets];
    }

    public int MaxDmg
    {
        get { return maxDmg; }
        set { maxDmg = value; }
    }

    public int MinDmg
    {
        get { return minDmg; }
        set { minDmg = value; }
    }


    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int StrengthBonus => this.sockets.Where(s => s != null).Sum(x => x.StrengthBonus);
    public int AgilityBonus => this.sockets.Where(x => x != null).Sum(x => x.AgilityBonus);
    public int VitalityBonus => this.sockets.Where(x => x != null).Sum(x => x.VitalityBonus);

    public void AddGem(int socket,IGem gem)
    {
        if (CheckSocket(socket))
        {
            return;
        }
        this.sockets[socket] = gem;
    }
    public void Remove(int socket)
    {
        if (CheckSocket(socket))
        {
            return;
        }
        this.sockets[socket] = null;
    }

    private bool CheckSocket(int socket)
    {
        if (socket<0||socket>=this.sockets.Length)
        {
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        //TO DO
        return $"{this.Name}: {this.MinDmg + this.StrengthBonus * 2 + this.AgilityBonus}-{this.MaxDmg + this.StrengthBonus * 3 + this.AgilityBonus * 4} Damage, +{this.StrengthBonus} Strength, +{this.AgilityBonus} Agility, +{this.VitalityBonus} Vitality";
    }
}
