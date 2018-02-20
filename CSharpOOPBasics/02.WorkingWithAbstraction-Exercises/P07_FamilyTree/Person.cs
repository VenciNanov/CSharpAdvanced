using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Person
{
    private List<Person> children;

    public Person()
    {
        this.children = new List<Person>();
    }

    public Person(string name, string date) : this()
    {
        this.Name = name;
        this.BirthdayDate = date;
    }

    public string Name { get; set; }

    public string BirthdayDate { get; set; }

    public IReadOnlyList<Person> Children
    {
        get { return this.children.AsReadOnly(); }
    }

    public void AddChild(Person child)
    {
        this.children.Add(child);
    }
    public void addChildInfo(string name, string date)
    {
        if (this.children.FirstOrDefault(x => x.Name == name) != null)
        {
            this.children.FirstOrDefault(x => x.Name == name).BirthdayDate = date;
            return;
        }

        if (this.children.FirstOrDefault(d => d.BirthdayDate == date) != null)
        {
            this.children.FirstOrDefault(d => d.BirthdayDate == date).Name = name;
        }
    }

    public Person FindChildName(string childName)
    {
        return this.children.FirstOrDefault(c => c.Name == childName);
    }

    public override string ToString()
    {
        return $"{this.Name} {this.BirthdayDate}";
    }
}
