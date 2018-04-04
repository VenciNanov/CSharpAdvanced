using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CustomList<T> : ICustomList<T>
    where T : IComparable<T>
{
    private IList<T> data;

    public CustomList()
    {
        this.data = new List<T>();
    }

    public void Add(T element)
    {
        this.data.Add(element);
    }

    public bool Contains(T element)
    {
        bool ifContaints = this.data.Contains(element);

        return ifContaints;
    }

    public int CountGreaterThan(T element)
    {
        int counter = 0;

        for (int i = 0; i < data.Count; i++)
        {
            if (this.Compare(this.data[i], element) > 0)
            {
                counter++;
            }
        }
        return counter;
    }
        
    public T Max()
    {
        T max = this.data[0];
        for (int i = 0; i < this.data.Count; i++)
        {
            if (this.Compare(this.data[i], max) > 0)
            {
                max = this.data[i];
            }
        }
        return max;
    }

    public T Min()
    {
        T min = this.data[0];

        for (int i = 0; i < this.data.Count; i++)
        {
            if (this.Compare(this.data[i], min) < 0)
            {
                min = this.data[i];
            }
        }
        return min;
    }

    public T Remove(int index)
    {
        if (IndexOutOfRange(index))
        {
            throw new IndexOutOfRangeException();
        }

        T element = this.data[index];

        this.data.RemoveAt(index);
        return element;
    }

    public void Sort()
    {
        this.data = this.data.OrderBy(x => x).ToList();
    }

    public void Swap(int index1, int index2)
    {
        if (IndexOutOfRange(index1) && IndexOutOfRange(index2))
        {
            throw new IndexOutOfRangeException();
        }

        T temp = this.data[index1];
        this.data[index1] = this.data[index2];
        this.data[index2] = temp;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.data.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private bool IndexOutOfRange(int index)
    {
        return index < 0 || index >= this.data.Count;
    }

    private int Compare(T first, T second)
    {
        return first.CompareTo(second);
    }
}
