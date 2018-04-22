using System;
using System.Collections.Generic;
using System.Text;

public class RoyalGuard:Soldiers
{
    public RoyalGuard(string name) : base(name)
    {
    }
    
    public override void KingUnderAttack(object sender, EventArgs e)
    {
        Console.WriteLine($"Royal Guard {this.Name} is defending!");
    }
}
