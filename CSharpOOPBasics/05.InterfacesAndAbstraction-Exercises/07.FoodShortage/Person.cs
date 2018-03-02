using System;
using System.Collections.Generic;
using System.Text;

public abstract class Person : IBuyer
{
    protected static int totalFood;
    private int food;

    public static int TotalFood
    {
        get
        {
            return totalFood;
        }
        protected set
        {
            totalFood = value;
        }
    }

    public int Food
    {
        get { return food; }
        set { food = value; }
    }

    public string Name { get; }
    protected int Age { get; }

    public Person(string name,int age)
    {
        Name = name;
        Age = age;
        Food = 0;
    }

    public abstract void BuyFood();
}