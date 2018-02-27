using System;


public class StartUp
{
    static void Main(string[] args)
    {
        Pizza pizza = null;

        try
        {
            GetPizza(out pizza);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        Dough dough = null;

        try
        {
            GetDought(out dough);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        PrintPizza(pizza, dough);

    }

    private static void PrintPizza(Pizza pizza, Dough dough)
    {
        pizza.Dough = dough;

        var input = string.Empty;

        while ((input = Console.ReadLine()) != "END")
        {
            var toppingData = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var toppingType = toppingData[1];
            var toppingWeight = int.Parse(toppingData[2]);

            Toppings toppings = null;

            try
            {
                toppings = new Toppings(toppingType, toppingWeight);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            pizza.AddTopping(toppings);

            if (pizza.Toppings > 10)
            {
                Console.WriteLine("Number of toppings should be in range [0..10].");
                return;
            }
        }
        Console.WriteLine(pizza);
    }

    private static void GetDought(out Dough dough)
    {
        var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var ingridient = input[0];
        var flour = input[1];
        var bakingTechnique = input[2];
        var weight = int.Parse(input[3]);
        dough = new Dough(flour, bakingTechnique, weight);
    }

    private static void GetPizza(out Pizza pizza)
    {
        pizza = null;
        var name = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];
        pizza = new Pizza(name);
    }
}

