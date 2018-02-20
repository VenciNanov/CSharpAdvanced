using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        var numberOfRectangles = input[0];
        var intersectionChecks = input[1];

        var rectangles = new List<Rectangle>();

        for (int i = 0; i < numberOfRectangles; i++)
        {
            var line = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            rectangles.Add(new Rectangle(line[0], double.Parse(line[1]), double.Parse(line[2]), double.Parse(line[3]), double.Parse(line[4])));
        }

        for (int i = 0; i < intersectionChecks; i++)
        {
            var pair = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var firstRectangle = rectangles.Where(x => x.Id == pair[0]).FirstOrDefault();
            var secondRectangle = rectangles.Where(x => x.Id == pair[1]).FirstOrDefault();

            Console.WriteLine(firstRectangle.IsIntersected(secondRectangle).ToString().ToLower());
        }
    }
}

