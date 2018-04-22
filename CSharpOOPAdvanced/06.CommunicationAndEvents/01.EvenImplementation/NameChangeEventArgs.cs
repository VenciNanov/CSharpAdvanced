using System;
using System.Collections.Generic;
using System.Text;

public class NameChangeEventArgs
{
    public NameChangeEventArgs(string name)
    {
        this.Name = name;
    }

    public string Name { get; }
}
