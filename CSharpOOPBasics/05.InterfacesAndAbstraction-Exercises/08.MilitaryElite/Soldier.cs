using System;
using System.Collections.Generic;
using System.Text;

public class Soldier : ISoldier
{
    private int id;
    private string firstName;
    private string lastName;

    public string LastName
    {
        get { return lastName; }
        private set { lastName = value; }
    }

    public string FirstName
    {
        get { return firstName; }
        private set { firstName = value; }
    }

    public int Id
    {
        get { return id; }
        private set { id = value; }
    }

    public Soldier(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }
    public override string ToString()
    {
        return $"Name: {FirstName} {LastName} Id: {Id}";
    }
}
