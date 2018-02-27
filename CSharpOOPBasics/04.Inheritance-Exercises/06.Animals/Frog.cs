using System;
using System.Collections.Generic;
using System.Text;

internal class Frog:Animal
{
    private string sound;

    public Frog(string name, int age, string gender) : base(name, age, gender)
    {
        this.sound = "Ribbit";
    }

    protected override string MakeSound()
    {
        return this.sound;
    }
}

