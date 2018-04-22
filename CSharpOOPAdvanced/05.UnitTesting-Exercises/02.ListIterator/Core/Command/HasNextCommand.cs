using System;
using System.Collections.Generic;
using System.Text;

public class HasNextCommand : ICommand
{
    public HasNextCommand()
    {
    }

    public void Execute(ref ListIterator list)
    {
        string result = list.HasNext().ToString();

        Console.WriteLine(result);
    }
}