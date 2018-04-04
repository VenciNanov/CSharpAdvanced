using System;
using System.Collections.Generic;
using System.Text;

public class CommandInterpreter
{
    private ICustomList<string> list;

    public CommandInterpreter(ICustomList<string> list)
    {
        this.list = list;
    }

    public void Execute()
    {
        while (true)
        {
            var inputArgs = Console.ReadLine().Split();
            var command = inputArgs[0].ToString();

            var result = string.Empty;

            switch (command)
            {
                case "Add":
                    var element = inputArgs[1];
                    this.list.Add(element);
                    break;

                case "Remove":
                    var index = int.Parse(inputArgs[1]);
                    result = this.list.Remove(index);
                    result = string.Empty;
                    break;

                case "Contains":
                    element = inputArgs[1];
                    result = this.list.Contains(element).ToString();
                    break;

                case "Swap":
                    int first = int.Parse(inputArgs[1]);
                    int second = int.Parse(inputArgs[2]);
                    this.list.Swap(first, second);
                    break;

                case "Greater":
                    element = inputArgs[1];
                    result = this.list.CountGreaterThan(element).ToString();
                    break;

                case "Max":
                    result = this.list.Max();
                    break;

                case "Min":
                    result = this.list.Min();
                    break;

                case "Sort":
                    this.list.Sort();
                    break;

                case "Print":
                    result = string.Join($"{Environment.NewLine}", this.list);
                    break;

                case "END":
                    return;
            }
            if (result!=string.Empty)
            {
                Console.WriteLine(result);
            }
        }
    }
}
