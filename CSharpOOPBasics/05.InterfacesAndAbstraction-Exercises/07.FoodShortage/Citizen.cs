using System;
using System.Collections.Generic;
using System.Text;

public class Citizen : Person
{
    private string id;
    private string birthdate;

    public string Birthdate
    {
        get { return birthdate; }
        private set { birthdate = value; }
    }


    public string Id
    {
        get { return id; }
        private set { id = value; }
    }



    public Citizen(string name, int age,string id,string birthdate) : base(name, age)
    {
        Id = id;
        Birthdate = birthdate;
    }

    public override void BuyFood()
    {
        totalFood += 10;
        Food += 10;
    }
}
