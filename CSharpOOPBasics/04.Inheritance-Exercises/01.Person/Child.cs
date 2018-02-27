using System;
using System.Collections.Generic;
using System.Text;

public class Child : Person
{
    private const int maxAge = 15;

    public Child(string name, int age) : base(name, age)
    {
    }

    public override int Age
    {
        get
        {
            return base.Age;
        }
        set
        {
            if (value > maxAge)
            {
                throw new ArgumentException($"Child's age must be less than {maxAge}!");
            }

            base.Age = value;
        }
    }
}
