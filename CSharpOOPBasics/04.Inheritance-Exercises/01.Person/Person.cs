using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private string name;
    private int age;

    private const int MinAge = 0;
    private const int MinNameLength = 3;

    public Person(string name,int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public virtual string Name
    {
        get
        {
            return name;
        }
        set
        {
            if (value.Length<MinNameLength)
            {
                throw new ArgumentException($"Name's length should not be less than {MinNameLength} symbols!");
            }
            this.name = value;
        }
    }

    public virtual int Age
    {
        get
        {
            return this.age;
        }
        set
        {
            if (value<MinAge)
            {
                throw new ArgumentException("Age must be positive!");
            }
            
            this.age=value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(String.Format($"Name: {this.name}, Age: {this.age}"));
        return sb.ToString();
    }
}
