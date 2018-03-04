using System;
using System.Collections.Generic;
using System.Text;

public abstract    class Cat
    {
    private string name;
    private string breed;

    public string Breed
    {
        get { return breed; }
        set { breed = value; }
    }


    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Cat(string breed,string name)
    {
        this.Breed = breed;
        this.Name = name;
    }

    public override string ToString()
    {
        return $"{Breed} {Name}";
    }
}
