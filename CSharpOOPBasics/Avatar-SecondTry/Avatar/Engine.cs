using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Engine
{
    private bool isRunning;
    private NationsBuilder nationsBuilder;

    public Engine()
    {
        this.isRunning = true;
        this.nationsBuilder = new NationsBuilder();
    }

    public void Run()
    {
        while (this.isRunning)
        {
            string inputCommand = this.ReadInput();
            var commandParams = this.ParseInput(inputCommand);
            this.Execute(commandParams);
        }
    }

    private void Execute(List<string> args)
    {
        var command = args[0];
        args = args.Skip(1).ToList();

        switch (command)
        {
            case "Bender":
                nationsBuilder.AssignBender(args);
                break;

            case "Monument":
                nationsBuilder.AssignMonument(args);
                break;

            case "Status":
                var status = this.nationsBuilder.GetStatus(args[0]);
                this.OutputWriter(status);
                break;

            case "War":
                this.nationsBuilder.IssueWar(args[0]);
                break;

            case "Quit":
                var record = this.nationsBuilder.GetWarsRecord();
                this.OutputWriter(record);
                this.isRunning = false;
                break;
            default:
                break;
        }

    }

    private void OutputWriter(string status) => Console.WriteLine(status);

    private List<string> ParseInput(string inputCommand)
    {
        return inputCommand.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    private string ReadInput()
    {
        return Console.ReadLine();
    }
}
