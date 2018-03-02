using System;
using System.Collections.Generic;
using System.Text;

public class Rebel : Person
{
    private string group;

    public string Group
    {
        get { return group; }
        set { group = value; }
    }


    public Rebel(string name, int age,string group) : base(name, age)
    {
        Group = group;
    }

    public override void BuyFood()
    {
        TotalFood += 5;
        Food += 5;
    }
}

