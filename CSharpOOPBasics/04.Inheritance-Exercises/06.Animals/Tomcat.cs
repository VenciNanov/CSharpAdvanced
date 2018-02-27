using System;
using System.Collections.Generic;
using System.Text;

internal class Tomcat:Cat
{
    private string sound;

    public Tomcat(string name, int age) : base(name, age, "Male")
    {
        this.sound = "MEOW";
    }

    protected override string MakeSound()
    {
        return this.sound;
    }
}
