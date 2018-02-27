using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Pizza
{
    private string name;
    private List<Toppings> toppings;
    private Dough dough;
    private double totalCalories;

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            this.name = value;
        }
    }
    public int Toppings
    {
        get
        {
            return toppings.Count;
        }
    }

    public Dough Dough
    {
        set
        {
            this.dough = value;
        }
    }

    public double TotalCalories
    {
        get
        {
            CalculateCalories();
            return this.totalCalories;
        }
    }
    
    public Pizza(string name)
    {
        this.toppings = new List<Toppings>();
        Name = name;

    }

    public void AddTopping(Toppings topping)
    {
        this.toppings.Add(topping);
    }
    private void CalculateCalories()
    {
        double calories = dough.Calories;
        calories += toppings.Sum(t => t.Calories);
        this.totalCalories = calories;
    }

    public override string ToString()
    {
        return $"{Name} - {TotalCalories:f2} Calories.";
    }
}

