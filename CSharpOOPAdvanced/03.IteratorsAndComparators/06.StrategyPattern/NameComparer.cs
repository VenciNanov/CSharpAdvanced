using System;
using System.Collections.Generic;
using System.Text;

public class NameComparer : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        var xLenght = x.Name.Length;
        var yLenght = y.Name.Length;

        var result = xLenght.CompareTo(yLenght);


        if (result == 0)
        {
            char xFirstLetter = x.Name.ToLower()[0];
            char yFirstLetter = y.Name.ToLower()[0];

            result = xFirstLetter.CompareTo(yFirstLetter);
        }

        return result;
    }
}
