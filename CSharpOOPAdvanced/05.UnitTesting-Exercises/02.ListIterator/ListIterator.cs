﻿using System;
using System.Collections.Generic;
using System.Text;

public class ListIterator
{
    private List<string> collection;
    private int currentIndex;

    public ListIterator(IEnumerable<string> collection)
    {
        this.NullValidation(collection);
        this.collection = new List<string>(collection);
    }

    private void NullValidation(IEnumerable<string> collection)
    {
        if (collection==null)
        {
            throw new ArgumentException();
        }
    }

    public bool Move() => ++this.currentIndex < this.collection.Count;

    public bool HasNext() => this.currentIndex < this.collection.Count - 1;

    public string Print()
    {
        if (this.collection.Count==0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        return this.collection[currentIndex];
    }
}
