using System;
using System.Collections.Generic;
using System.Text;

public class Reader : IReader
{
    public Reader()
    {

    }

    public string ReadLine()
    {
        string line = Console.ReadLine();
        return line;
    }
}
