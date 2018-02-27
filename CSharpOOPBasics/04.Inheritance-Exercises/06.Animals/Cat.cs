using System;
using System.Collections.Generic;
using System.Text;

internal class Cat:Animal
{
    private string sound;

    public Cat(string name,int age,string gender):base(name,age,gender)
    {
        this.sound = "Meow meow";
    }

    protected override string MakeSound()
    {
        return this.sound;
    }
}

