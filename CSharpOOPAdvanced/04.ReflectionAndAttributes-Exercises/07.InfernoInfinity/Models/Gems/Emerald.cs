using System;
using System.Collections.Generic;
using System.Text;

public class Emerald : Gem
{
    private const int baseStrength = 1;
    private const int baseAgility = 4;
    private const int baseVitality = 9;

    public Emerald(GemQualityLevel gemQualityLevel) : base(gemQualityLevel, baseStrength,baseAgility,baseVitality)
    {
    }
}
