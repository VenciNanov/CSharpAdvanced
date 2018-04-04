using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        var box = new Box<double>();

        for (int i = 0; i < n; i++)
        {
            var input = double.Parse(Console.ReadLine());

            box.Elements.Add(input);
        }

        var elem = double.Parse(Console.ReadLine());
        
        Console.WriteLine(Compare(box,elem));

    }

    public static int Compare<T>(Box<T> box ,T elem)
        where T : IComparable<T>
    {
        var counter = 0;

        foreach (var element in box.Elements)
        {
            if (element.CompareTo(elem) > 0)
            {
                counter++;
            }
        }
        return counter;
    }
}
