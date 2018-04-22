using System;
using System.Linq;
using System.Reflection;

public class Program
{
    public static void Main(string[] args)
    {
        IInterpreter interpreter = new CommandInterpreter();
        IEngine engine = new Engine(interpreter);
        engine.Run();
    }
}