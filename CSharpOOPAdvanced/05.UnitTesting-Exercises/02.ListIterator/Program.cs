using System;
using System.Linq;
using System.Reflection;

public class Program
{
    public static void Main()
    {
        Execute();
    }

    private static void Execute()
    {
        var InitializationArgs = Console.ReadLine().Split();
        var iterator = new ListIterator(InitializationArgs.Skip(1));

        var iteratorMethods = iterator.GetType().GetMethods();

        var command = Console.ReadLine();

        while (command != "END")
        {
            try
            {
                var parsedMethod = iteratorMethods
                    .FirstOrDefault(m => m.Name == command);

                if (parsedMethod == null)
                {
                    Console.WriteLine($"This option {command} does not exists");
                }

                Console.WriteLine(parsedMethod.Invoke(iterator, new object[] { }));
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.InnerException.Message);

            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine(ane.Message);
            }

            command = Console.ReadLine();
        }
    }
}
