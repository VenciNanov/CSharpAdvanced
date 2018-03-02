using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>();

        var input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            Animal animal;
            Food food;

            try
            {
                animal = GetAnimals(input.Split());
                food = GetFood(Console.ReadLine().Split());
            }
            catch (ArgumentException)
            {
                continue;
            }

            animal.MakeSound();

            try
            {
                animal.Eat(food);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            animals.Add(animal);
        }

        foreach (var animal in animals)
        {
            Console.WriteLine(animal.ToString());
        }
    }

    private static Food GetFood(string[] data)
    {
        var type = data[0];
        var quantity = int.Parse(data[1]);

        switch (type)
        {
            case "Vegetable":
                return new Vegetable(quantity);

            case "Meat":
                return new Meat(quantity);

            case "Fruit":
                return new Fruit(quantity);

            case "Seeds":
                return new Seeds(quantity);

            default:
                throw new ArgumentException("Shit");
        }
    }

    private static Animal GetAnimals(string[] data)
    {
        var type = data[0];
        var name = data[1];
        var weight = double.Parse(data[2]);
        var paramOne = data[3];

        switch (type)
        {
            case "Owl":
                return new Owl(type, name, weight, double.Parse(paramOne));
            case "Hen":
                return new Hen(type, name, weight, double.Parse(paramOne));
            case "Mouse":
                return new Mouse(type, name, weight, paramOne);
            case "Cat":
                return new Cat(type, name, weight, paramOne, data[4]);
            case "Dog":
                return new Dog(type, name, weight, paramOne);
            case "Tiger":
                return new Tiger(type, name, weight, paramOne, data[4]);
            default:
                throw new ArgumentException("Ako");
        }
    }
}