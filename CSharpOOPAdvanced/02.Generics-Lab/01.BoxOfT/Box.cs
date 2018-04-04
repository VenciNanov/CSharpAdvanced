using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Box<T>
{
    private Stack<T> items;

    public Box()
    {
        this.items = new Stack<T>();
    }

    public int Count
    {
        get { return this.items.Count; }
    }

    public void Add(T element)
    {
        items.Push(element);
    }

    public T Remove()
    {
        return this.items.Pop();
    }



}
