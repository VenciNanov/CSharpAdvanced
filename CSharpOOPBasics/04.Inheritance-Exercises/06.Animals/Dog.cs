using System;
using System.Collections.Generic;
using System.Text;

internal class Dog : Animal
{
    private string sound;
    public Dog(string name,int age,string gender):base(name,age,gender)
    {
        this.sound = "Woof!";
    }

    protected override string MakeSound()
    {
        return this.sound;
    }
}

