using System;


public class StartUp
{
    static void Main(string[] args)
    {
        var driver = Console.ReadLine();

        ICar car = new Ferrari("488-Spider", driver);

        Console.WriteLine(car.ToString());
    }
}

