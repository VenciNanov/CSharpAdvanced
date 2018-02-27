using System;
using System.Collections.Generic;
using System.Text;


public class Toppings
{
    private string type;
    private int weight;
    private double calories;

    public double Calories
    {
        get
        {
            return this.calories;
        }
    }


    public int Weight
    {
        set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{type} weight should be in the range [1..50].");
            }
            this.weight = value;
        }
    }


    public string Type
    {
        set
        {
            if (string.IsNullOrEmpty(value) ||
                (value.ToLower() != "Meat".ToLower() &&
                value.ToLower() != "Veggies".ToLower() &&
                value.ToLower() != "Cheese".ToLower() &&
                value.ToLower() != "Sauce".ToLower()))
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            this.type = value;
        }
    }

    public Toppings(string type, int weight)
    {

        Type = type;
        Weight = weight;
        CalculateCalories();
    }

    private void CalculateCalories()
    {
        GetToppingType(out double toppingMod);
        this.calories=(2.0 * this.weight) * toppingMod;
    }

    private void GetToppingType(out double toppingMod)
    {
        toppingMod = 0;
        switch (this.type.ToLower())
        {
            case "meat":
                toppingMod = ToppingType.Meat;
                break;
            case "veggies":
                toppingMod = ToppingType.Veggies;
                break;
            case "cheese":
                toppingMod = ToppingType.Cheese;
                break;
            case "sauce":
                toppingMod = ToppingType.Sauce;
                break;
        }
    }
}
