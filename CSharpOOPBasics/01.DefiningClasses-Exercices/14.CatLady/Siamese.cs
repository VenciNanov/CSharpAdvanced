using System;
using System.Collections.Generic;
using System.Text;

class Siamese : Cat
{
    private double earSize;

    public Siamese(string breed, string name, double earSize) : base(breed, name)
    {
        EarSize = earSize;
    }

    public double EarSize
    {
        get { return earSize; }
        set
        {
            if (value < 0)
            {
                return;
            }
            earSize = value;
        }
    }

    public override string ToString()
    {
        return $"{base.ToString()} {EarSize}";
    }

}
