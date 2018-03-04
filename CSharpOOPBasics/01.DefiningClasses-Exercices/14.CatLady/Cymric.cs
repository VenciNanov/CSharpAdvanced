using System;
using System.Collections.Generic;
using System.Text;

public class Cymric : Cat
{
    private decimal furLength;

    public Cymric(string breed, string name, decimal furLength) : base(breed, name)
    {
        FurLength = furLength;
    }

    public decimal FurLength
    {
        get { return furLength; }
        set { furLength = value; }
    }

    public override string ToString()
    {
        return $"{base.ToString()} {FurLength:f2}";
    }


}
