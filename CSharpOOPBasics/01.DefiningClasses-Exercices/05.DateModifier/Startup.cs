using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Startup
{
    static void Main(string[] args)
    {
        var firstDate = Console.ReadLine();
        var secondDate = Console.ReadLine();

        Console.WriteLine(DateModifier.GetDaysBetweenTwoDates(firstDate,secondDate));
    }
}

