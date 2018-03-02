using System;
using System.Collections.Generic;
using System.Text;

public abstract class Feline : Mammal
{
    public Feline(string animalType, string name, double weight, string livingRegion) : base(animalType, name, weight, livingRegion)
    {
    }
}