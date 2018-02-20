using System;
using System.Collections.Generic;
using System.Text;


public class Parent
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

    public Parent(string name, string birthday)
    {
        this.Name = name;
        this.birthday = birthday;
    }

    public override string ToString()
    {
        return $"{this.name} {this.birthday}";
    }
}
