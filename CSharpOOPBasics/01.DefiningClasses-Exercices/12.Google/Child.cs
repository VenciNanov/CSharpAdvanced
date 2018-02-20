using System;
using System.Collections.Generic;
using System.Text;


public class Child
{
    private string name;
    private string birthday;

    private string Name
    {
        set
        {
            this.name = value;
        }
    }

    public Child(string name,string birthday)
    {
        this.Name = name;
        this.birthday = birthday;
    }

    public override string ToString()
    {
        return $"{this.name} {this.birthday}";
    }

}
