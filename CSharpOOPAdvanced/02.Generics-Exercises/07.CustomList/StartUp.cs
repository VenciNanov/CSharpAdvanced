using System;

public class StartUp
{
    static void Main(string[] args)
    {
        CommandInterpreter commandInterpreter = new CommandInterpreter(new CustomList<string>());
        commandInterpreter.Execute();
    }
}
