using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    private string name;
    private decimal money;
    private List<Product> bagOfProducts;

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            };
            this.name = value;
        }
    }

    public decimal Money
    {
        get
        {
            return this.money;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            };
            this.money = value; ;
        }
    }
    public Person()
    {
        this.bagOfProducts = new List<Product>();
    }

    public Person(string name,decimal money):this()
    {
        Name = name;
        Money = money;
    }

    public bool TryAddProduct(Product product)
    {
        if (product.Cost <= this.money)
        {
            bagOfProducts.Add(product);
            this.money -= product.Cost;
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        var result = bagOfProducts.Count == 0 
            ? "Nothing bought" 
            : $"{string.Join(", ", bagOfProducts)}";
        return $"{this.name} - {result}";
    }
}
