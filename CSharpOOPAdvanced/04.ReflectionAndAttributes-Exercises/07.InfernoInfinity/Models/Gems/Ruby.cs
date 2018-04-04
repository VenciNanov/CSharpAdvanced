using System;
using System.Collections.Generic;
using System.Text;

public class Ruby : Gem
{
    private const int baseStrength = 7;
    private const int baseAgility = 2;
    private const int baseVitality = 5;

    public Ruby(GemQualityLevel gemQualityLevel) : base(gemQualityLevel, baseStrength, baseAgility, baseVitality)
    {
    }
}
