using System;
using System.Collections.Generic;
using System.Text;

public class Hen : Bird
{
    public Hen(string animalType, string name, double weight, double wingSize) : base(animalType, name, weight, wingSize)
    {
    }

    public override void Eat(Food food)
    {
        base.FoodEaten += food.Quantity;
        base.Weight += (0.35 * food.Quantity);
    }

    public override void MakeSound()
    {
        Console.WriteLine("Cluck");
    }

    public override string ToString()
    {
        return $"{AnimalType} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
    }
}
