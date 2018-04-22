using System;
using System.Collections.Generic;
using System.Text;

public class PrintCommand : ICommand
{
    public PrintCommand()
    {
    }

    public void Execute(ref ListIterator list)
    {
        string result = list.Print();

        Console.WriteLine(result);
    }
}
