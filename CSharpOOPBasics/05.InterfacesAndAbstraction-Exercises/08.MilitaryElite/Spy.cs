using System;
using System.Collections.Generic;
using System.Text;

public class Spy : Soldier
{
    private int codeNumber;

    public Spy(int id, string firstName, string lastName, int codeNumber) : base(id, firstName, lastName)
    {
        this.CodeNumber = codeNumber;
    }

    public int CodeNumber
    {
        get { return codeNumber; }
        private set { codeNumber = value; }
    }

    public override string ToString()
    {
        return $"{base.ToString()}{Environment.NewLine}" +
            $"Code Number: {CodeNumber}";
    }
}
