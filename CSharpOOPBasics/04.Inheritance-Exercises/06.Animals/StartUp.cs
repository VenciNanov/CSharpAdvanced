using System;

public class StartUp
{
    static void Main(string[] args)
    {
        
        string input = string.Empty;

        while ((input= Console.ReadLine())!= "Beast!")
        {
            try
            {
                GetAnimal(out Animal animal, input);
                Console.WriteLine(animal);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                continue;
            }
        }
    }

    private static void GetAnimal(out Animal animal,string input)
    {
        animal = null;
        var type = input;
        var tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var name = tokens[0];
        var age = int.Parse(tokens[1]);
        var gender = tokens[2];

        switch (type)
        {
            case "Dog":
                animal = new Dog(name, age, gender);
                break;

            case "Frog":
                animal = new Frog(name, age, gender);
                break;

            case "Cat":
                animal = new Cat(name, age, gender);
                break;

            case "Kitten":
                animal = new Kitten(name, age);
                break;

            case "Tomcat":
                animal = new Tomcat(name, age);
                break;

            default:
                throw new ArgumentException("Invalid input!");
        }
    }
}

