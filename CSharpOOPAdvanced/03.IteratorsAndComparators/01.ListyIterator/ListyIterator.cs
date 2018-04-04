using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class ListyIterator<T>:IEnumerable<T>
{
    private int currentIndex = 0;

    public ListyIterator(IEnumerable<T> items)
    {
        this.Items = new List<T>(items);
        
    }

    public List<T> Items { get; set; }


    public bool Move()
    {
        if (HasNext())
        {
            currentIndex++;
            return true;
        }
        return false;

    }

    public bool HasNext()
    {
        if ((this.currentIndex+1)<this.Items.Count)
        {
            return true;
        }
        return false;
    }

    public string Print()
    {
        if (Items.Count>0)
        {
           return Items[currentIndex].ToString();
        }
        throw new InvalidOperationException("Invalid Operation");
    }

    public string PrintAll()
    {
        if (Items.Count > 0)
        {
            return string.Join(" ", Items);
        }
        throw new InvalidOperationException("Invalid Operation");
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.Items.Count; i++)
        {
            yield return this.Items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
