﻿using System;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine().Split(',').Select(int.Parse).ToArray();


        Lake lake = new Lake(input);

        Console.WriteLine(string.Join(", ", lake));
    }
}

