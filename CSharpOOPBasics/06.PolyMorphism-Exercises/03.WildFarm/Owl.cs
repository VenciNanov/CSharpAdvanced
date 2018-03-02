using System;
using System.Collections.Generic;
using System.Text;

public class Owl : Bird
{
    public Owl(string animalType, string name, double weight, double wingSize) : base(animalType, name, weight, wingSize)
    {
    }

    public override void Eat(Food food)
    {
        if (!(food is Meat))
        {
            throw new ArgumentException($"{base.AnimalType} does not eat {food}!");
        }
        base.FoodEaten += food.Quantity;
        base.Weight += (0.25 * food.Quantity);
    }

    public override void MakeSound()
    {
        Console.WriteLine("Hoot Hoot");
    }

    public override string ToString()
    {
        return $"{AnimalType} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
    }
}