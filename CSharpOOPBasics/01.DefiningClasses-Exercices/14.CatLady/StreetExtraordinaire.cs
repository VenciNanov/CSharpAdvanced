using System;
using System.Collections.Generic;
using System.Text;

public class StreetExtraordinaire : Cat
{
    private double decibelOfMeows;

    public StreetExtraordinaire(string breed, string name,double decibelOfMeows) : base(breed, name)
    {
        DecibelOfMeows = decibelOfMeows;
    }

    public double DecibelOfMeows
    {
        get { return decibelOfMeows; }
        set {
            if (value<0)
            {
                return;
            }
            decibelOfMeows = value; }
    }

    public override string ToString()
    {
        return $"{base.ToString()} {DecibelOfMeows}";
    }
}
