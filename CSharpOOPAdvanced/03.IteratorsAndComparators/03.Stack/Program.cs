using System;
using System.Linq;

public class Program
{
    static void Main()
    {
        var input = string.Empty;

        CustomStack<int> customStack = new CustomStack<int>();

        while ((input = Console.ReadLine()) != "END")
        {
            var args = input.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var numbers = args.Skip(1).Select(int.Parse).ToArray();
            try
            {
                switch (args[0])
                {
                    case "Push":
                        foreach (var num in numbers)
                        {
                            customStack.Push(num);
                        }
                        break;

                    case "Pop":
                        customStack.Pop();
                        break;
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        if (customStack.Any())
        {
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(string.Join(Environment.NewLine, customStack));
            }
        }
    }
}
