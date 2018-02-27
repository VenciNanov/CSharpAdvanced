using System;
using System.Collections.Generic;
using System.Text;

public class Book
{
    private const int minTitleLength = 3;


    private string author;
    private string title;
    private decimal price;

    public Book(string author,string title,decimal price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    protected virtual decimal Price
    {
        get { return this.price; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            this.price = value;
        }
    }

    public string Title
    {
        get { return this.title; }
        set
        {
            if (value.Length < minTitleLength)
            {
                throw new ArgumentException("Title not valid!");
            }
            this.title = value;
        }
    }

    public string Author
    {
        get { return this.author; }
        set
        {
            var spaceIndex = value.IndexOf(' ');
            if (spaceIndex > 0 && spaceIndex < value.Length - 1 && char.IsDigit(value[spaceIndex + 1]))
            {
                throw new ArgumentException("Author not valid!");
            }
            this.author = value;
        }
    }
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Type: {this.GetType().Name}");
        sb.AppendLine($"Title: {this.Title}");
        sb.AppendLine($"Author: {this.Author}");
        sb.Append($"Price: {this.Price:f2}");
        return sb.ToString();
    }

}
