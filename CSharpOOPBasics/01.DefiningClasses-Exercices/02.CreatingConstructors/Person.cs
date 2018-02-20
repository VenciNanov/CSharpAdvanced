using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    private string name;
    private int age;
    private List<Person> family;
    private string v1;
    private int v2;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public Person():this("No name", 1)
    {

    }

    public Person(int age):this("No name", age)
    {

    }
    public Person(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new NullReferenceException("Invalid name");
        }
        this.name = name;
    }
    public Person(string name,int age):this(name)
    {
        this.age = age;
    }
}

