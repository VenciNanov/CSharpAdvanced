using System;
using System.Collections.Generic;
using System.Text;

public class Dog : Mammal, IMammal
{
    public Dog(string animalType, string name, double weight, string livingRegion) : base(animalType, name, weight, livingRegion)
    {

    }

    public override void Eat(Food food)
    {
        if (!(food is Meat))
        {
            throw new ArgumentException($"{base.AnimalType} does not eat {food}!");
        }
        base.FoodEaten += food.Quantity;
        base.Weight += (0.40 * food.Quantity);
    }

    public override void MakeSound()
    {
        Console.WriteLine("Woof!");
    }
}
