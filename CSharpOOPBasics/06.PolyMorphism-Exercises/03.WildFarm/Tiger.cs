using System;
using System.Collections.Generic;
using System.Text;

public class Tiger : Feline
{
    private string breed;

    public string Breed
    {
        get { return breed; }
        set { breed = value; }
    }


    public Tiger(string animalType, string name, double weight, string livingRegion, string breed) : base(animalType, name, weight, livingRegion)
    {
        this.Breed = breed;
    }

    public override void Eat(Food food)
    {
        if (!(food is Meat))
        {
            throw new ArgumentException($"{base.AnimalType} does not eat {food}!");
        }
        base.FoodEaten += food.Quantity;
        base.Weight += (1.00 * food.Quantity);
    }

    public override void MakeSound()
    {
        Console.WriteLine("ROAR!!!");
    }

    public override string ToString()
    {
        return $"{base.AnimalType} [{base.Name}, {this.Breed}, {base.Weight}, {this.LivingRegion}, {base.FoodEaten}]";
    }
}