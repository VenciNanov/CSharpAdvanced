﻿using System;
using System.Collections.Generic;
using System.Text;

public class Scale<T> where T:IComparable<T>
{
    private T left;
    private T right;

    public Scale(T left,T right)
    {
        this.left = left;
        this.right = right;
    }

    public T GetHeavier()
    {
        if (left.CompareTo(right)>0)
        {
            return left;
        }
        else if (right.CompareTo(left)>0)
        {
            return right;
        }
        else
        {
            return default(T);
        }
    }
}
