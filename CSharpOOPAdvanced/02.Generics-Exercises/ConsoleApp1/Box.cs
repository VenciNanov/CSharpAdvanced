using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Box<T>
    where T : IComparable<T>
{
    public Box()
    {
        Elements = new List<T>();
    }

    public List<T> Elements { get; set; }

    public void Swap(int firstElement, int secondElemet)
    {
        var temp = Elements[firstElement];
        Elements[firstElement] = Elements[secondElemet];
        Elements[secondElemet] = temp;
    }
    public int CompareTo(object obj)
    {
        var item = obj is T ? (T)obj : default(T);

        int result = 0;

        for (int i = 0; i < Elements.Count; i++)
        {
            result = this.Elements[i].CompareTo(item);
        }

        return result;
    }


    public override string ToString()
    {
        Type t = typeof(T);
        var sb = new StringBuilder();

        foreach (var item in Elements)
        {
            sb.AppendLine(t.ToString() + $": {item}");
        }
        return sb.ToString().Trim();
    }
}
