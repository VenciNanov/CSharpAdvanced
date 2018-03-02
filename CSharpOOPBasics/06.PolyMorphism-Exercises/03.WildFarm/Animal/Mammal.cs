using System;
using System.Collections.Generic;

public abstract class Mammal : Animal,IMammal
{
    private string livingRegion;

    public string LivingRegion
    {
        get { return livingRegion; }
        set { livingRegion = value; }
    }
    
    public Mammal(string animalType, string name, double weight,string livingRegion) : base(animalType, name, weight)
    {
        this.LivingRegion = livingRegion;
    }

    public override string ToString()
    {
        return $"{base.AnimalType} [{base.Name}, {base.Weight}, {this.LivingRegion}, {base.FoodEaten}]";
    }
}