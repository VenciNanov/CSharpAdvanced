
using System;
public class Program
{
    static void Main(string[] args)
    {
        string name = Console.ReadLine();
        var age = int.Parse(Console.ReadLine());

        Chicken chicken = null;

        try
        {
            chicken = new Chicken(name, age);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        Console.WriteLine($"Chicken {chicken.Name} (age {chicken.Age}) can produce {chicken.ProductPerDay} eggs per day.");

    }
}

