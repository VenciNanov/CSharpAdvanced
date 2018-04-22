using System;
using System.Collections.Generic;
using System.Text;

public class Footman : Soldiers
{
    public Footman(string name) : base(name)
    {
    }

    public override void KingUnderAttack(object sender, EventArgs e)
    {
        Console.WriteLine($"Footman {this.Name} is panicking!");
    }
}
