using System;
using System.Collections.Generic;
using System.Text;

public class Writer : IWriter
{
    public Writer()
    {

    }
    public void WriteLine(string line)
    {
        Console.WriteLine(line);
    }
}
