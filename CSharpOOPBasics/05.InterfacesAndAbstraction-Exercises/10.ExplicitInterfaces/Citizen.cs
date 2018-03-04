using System;
using System.Collections.Generic;
using System.Text;

public class Citizen : IPerson, IResident
    {
    private string name;
    private string country;
    private int age;

    public Citizen(string name,string country,int age)
    {
        Name = name;
        Country = country;
        Age = age;
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }
    
    public string Country
    {
        get { return country; }
        set { country = value; }
    }
    
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    string IResident.GetName()
    {
        return $"Mr/Ms/Mrs {name}";
    }

    string IPerson.GetName()
    {
        return name;
    }

}
