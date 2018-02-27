using System;

public class StartUp
{
    static void Main(string[] args)
    {
        var foods = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        Gandalf gandalf = new Gandalf();

        foreach (var food in foods)
        {
            gandalf.EatFood(food);
        }

        Console.WriteLine(gandalf);
    }
}