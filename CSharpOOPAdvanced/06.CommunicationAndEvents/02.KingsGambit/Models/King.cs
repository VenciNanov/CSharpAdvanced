using System;
using System.Collections.Generic;
using System.Text;

public class King
{
    public event EventHandler UnderAttack;

    public King(string name)
    {
        Name = name;
    }

    public string Name { get; set; }

    public void OnAttack()
    {
        Console.WriteLine($"King {this.Name} is under attack!");
        UnderAttack?.Invoke(this, null);
    }
}
