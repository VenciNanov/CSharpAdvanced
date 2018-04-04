using System;
using System.Linq;

public class Program
{
    static void Main()
    {
        var input = string.Empty;
        ListyIterator<string> listy = null;

        while ((input = Console.ReadLine()) != "END")
        {
            var args = input.Split();
            try
            {
                switch (args[0])
                {
                    case "Create":
                        listy = new ListyIterator<string>(args.Skip(1));
                        break;
                    case "Move":
                        Console.WriteLine(listy.Move());
                        break;
                    case "Print":
                        Console.WriteLine(listy.Print());
                        break;
                    case "PrintAll":
                        Console.WriteLine(listy.PrintAll());
                        break;
                    case "HasNext":
                        Console.WriteLine(listy.HasNext());
                        break;

                }
            }
            catch(InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
        }
    }
}
