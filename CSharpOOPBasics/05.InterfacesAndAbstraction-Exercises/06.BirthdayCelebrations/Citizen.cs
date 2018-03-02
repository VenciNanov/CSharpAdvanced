using System;
using System.Collections.Generic;
using System.Text;


public class Citizen:Rebelion,ICitizen
{
    private int age;
    private string id;

    public string Id
    {
        get { return id; }
        set { id = value; }
    }


    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public override string Birthdate { get => base.Birthdate; set => base.Birthdate = value; }

    public Citizen(string name,int age,string id, string birthdate):base(name)
    {
        Age = age;
        this.Birthdate = birthdate;
    }

    public override string ToString()
    {
        return Birthdate;
    }

}

