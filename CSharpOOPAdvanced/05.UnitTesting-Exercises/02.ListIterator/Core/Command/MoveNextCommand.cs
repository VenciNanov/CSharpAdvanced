using System;
using System.Collections.Generic;
using System.Text;

public class MoveCommand : ICommand
{
    public MoveCommand()
    {
    }

    public void Execute(ref ListIterator list)
    {
        string result = list.Move().ToString();

        Console.WriteLine(result);
    }
}