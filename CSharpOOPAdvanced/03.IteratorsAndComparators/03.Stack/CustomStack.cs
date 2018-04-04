using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CustomStack<T> : IEnumerable<T>
{
    public List<T> Items { get; set; }
    public CustomStack()
    {
        this.Items = new List<T>();
    }

    public void Push(T item)
    {
        this.Items.Add(item);
    }

    public T Pop()
    {
        if (Items.Count > 0)
        {
            T itemToRemove = this.Items.Last();
            this.Items.Remove(itemToRemove);
            return itemToRemove;
        }
        else
        {
            throw new ArgumentException("No elements");
        }
    }


    public IEnumerator<T> GetEnumerator()
    {
        var lastIndex = this.Items.Count - 1;
        for (int index = lastIndex; index >= 0; index--)
        {
            yield return this.Items[index];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
