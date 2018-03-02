using System;
using System.Collections.Generic;
using System.Text;

public class Mouse : Mammal, IMammal
{
    public Mouse(string animalType, string name, double weight, string livingRegion) : base(animalType, name, weight, livingRegion)
    {
    }

    public override void Eat(Food food)
    {
        if (!(food is Vegetable) && !(food is Fruit))
        {
            throw new ArgumentException($"{base.AnimalType} does not eat {food}!");
        }
        base.FoodEaten += food.Quantity;
        base.Weight += (0.10 * food.Quantity);
    }

    public override void MakeSound()
    {
        Console.WriteLine("Squeak");
    }


}
