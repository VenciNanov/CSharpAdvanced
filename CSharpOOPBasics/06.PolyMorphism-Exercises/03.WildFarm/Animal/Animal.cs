using System;
using System.Collections.Generic;

public abstract class Animal : IAnimal
{
    private string name;
    private double weight;
    private int foodEaten;
    private string animalType;

    public string AnimalType
    {
        get { return animalType; }
        set { animalType = value; }
    }

    public int FoodEaten
    {
        get { return foodEaten; }
        set { foodEaten = value; }
    }

    public double Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Animal(string animalType, string name,double weight)
    {
        this.AnimalType = animalType;
        this.Name = name;
        this.Weight = weight;
        this.FoodEaten = foodEaten;
    }

    public abstract void MakeSound();
    public abstract void Eat(Food food);
}
