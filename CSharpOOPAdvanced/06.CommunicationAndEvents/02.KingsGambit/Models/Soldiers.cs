using System;
using System.Collections.Generic;
using System.Text;

public abstract class Soldiers
{
    public Soldiers(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public abstract void KingUnderAttack(object sender, EventArgs e);
}
