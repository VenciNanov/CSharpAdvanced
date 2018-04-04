using System;
using System.Collections.Generic;
using System.Text;

public abstract class Gem : IGem
{
    private GemQualityLevel gemQualityLevel;

    public Gem(GemQualityLevel gemQualityLevel, int strength, int agility, int vitality)
    {
        this.gemQualityLevel = gemQualityLevel;
        this.StrengthBonus = strength + (int)gemQualityLevel;
        this.AgilityBonus = agility + (int)gemQualityLevel;
        this.VitalityBonus = vitality + (int)gemQualityLevel;
    }

    public int StrengthBonus { get; }
    public int AgilityBonus { get; }
    public int VitalityBonus { get; }

}
