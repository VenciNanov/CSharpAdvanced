using System;
using System.Collections.Generic;
using System.Text;

public class Amethyst : Gem
{
    private const int baseStrength = 2;
    private const int baseAgility = 8;
    private const int baseVitality = 4;

    public Amethyst(GemQualityLevel gemQualityLevel) : base(gemQualityLevel, baseStrength, baseAgility, baseVitality)
    {
    }
}
