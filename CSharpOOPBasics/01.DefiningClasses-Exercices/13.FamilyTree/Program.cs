using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine();
        var allPeople = new List<Person>();

        var line = string.Empty;

        while ((line=Console.ReadLine())!= "End")
        {
            if (line.Contains("-"))
            {
                var tokens = line.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();

                var parentInput = tokens[0];
                var childInput = tokens[1];

                var parent = allPeople.FirstOrDefault(x => (parentInput.Contains("/")) ? x.BirthdayDate == parentInput
                : x.Name == parentInput);

                //
                if (parent==null)
                {
                    parent = (parentInput.Contains("/"))
                        ? new Person { BirthdayDate = parentInput }
                        : new Person { Name = parentInput };
                    allPeople.Add(parent);
                }

                //
                var child = (childInput.Contains("/"))
                    ? new Person { BirthdayDate = childInput }
                    : new Person { Name = childInput };

                parent.AddChild(child);
            }
            else
            {
                var tokens = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                var name = $"{tokens[0]} {tokens[1]}";
                var date = tokens[2];
                var isAdded = false;

                for (int i = 0; i < allPeople.Count; i++)
                {
                    if (allPeople[i].Name==name)
                    {
                        allPeople[i].BirthdayDate = date;
                        isAdded = true;
                    }

                    if (allPeople[i].BirthdayDate==date)
                    {
                        allPeople[i].Name = name;
                        isAdded = true;
                    }

                    allPeople[i].addChildInfo(name, date);
                }

                if (!isAdded)
                {
                    allPeople.Add(new Person(name, date));
                }
            }
        }

        var person = allPeople.FirstOrDefault(x => (input.Contains("/"))
        ? x.BirthdayDate == input
        : x.Name == input);

        var result = new StringBuilder();

        result.AppendLine($"{person.Name} {person.BirthdayDate}");

        result.AppendLine($"Parents:");

        foreach (var parent in allPeople.Where(x=>x.FindChildName(person.Name)!=null))
        {
            result.AppendLine($"{parent.Name} {parent.BirthdayDate}");
        }

        result.AppendLine("Children:");

        foreach (var child in allPeople.FirstOrDefault(x=>x.Name==person.Name).Children)
        {
            result.AppendLine($"{child.Name} {child.BirthdayDate}");
        }

        Console.WriteLine(result);
    }
}

