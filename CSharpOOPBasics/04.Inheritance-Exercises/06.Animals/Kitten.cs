using System;
using System.Collections.Generic;
using System.Text;

internal class Kitten:Cat
{
    private string sound;

    public Kitten(string name, int age) : base(name, age, "Female")
    {
        this.sound = "Meow";
    }

    protected override string MakeSound()
    {
        return this.sound;
    }
}
