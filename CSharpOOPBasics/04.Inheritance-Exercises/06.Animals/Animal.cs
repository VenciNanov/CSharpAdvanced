using System;
using System.Collections.Generic;
using System.Text;

public abstract class Animal
{
    private string name;
    private int age;
    private string gender;

    public Animal(string name, int age, string gender)
    {
        Name = name;
        Age = age;
        Gender = gender;
    }

    public string Gender
    {
        get { return this.gender; }
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }

            if (value != "Male" && value != "Female")
            {
                throw new ArgumentException("Invalid input!");
            }

            this.gender = value;
        }
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            if (value < 0 || value > int.MaxValue)
            {
                throw new ArgumentException("Invalid input!");
            }

            this.age = value;
        }
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }
            this.name = value;
        }
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}{Environment.NewLine}" +
            $"{this.name} {this.age} {this.gender}{Environment.NewLine}" +
            $"{MakeSound()}";
    }

    protected abstract string MakeSound();

}

