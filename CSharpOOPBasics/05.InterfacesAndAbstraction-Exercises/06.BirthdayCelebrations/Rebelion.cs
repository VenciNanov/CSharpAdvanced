using System;
using System.Collections.Generic;
using System.Text;

public abstract class Rebelion:IBirthable
{
    private string name;
    private string birthdate;

    public Rebelion(string name)
    {
        this.Name = name;
    }

    public virtual string Birthdate
    {
        get { return this.birthdate; }
        set { this.birthdate = value; }
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }



}

