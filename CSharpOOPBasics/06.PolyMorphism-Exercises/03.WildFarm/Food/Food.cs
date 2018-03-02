using System;
using System.Collections.Generic;
using System.Text;

public abstract class Food : IFood
{
    private int quantity;

    public int Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }
    
    public Food(int quantity)
    {
        Quantity = quantity;
    }
}