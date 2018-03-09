using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Engine
{
    private bool isRunning;
    private NationBuilder nationBuilder;

    public Engine()
    {
        this.isRunning = true;
        this.nationBuilder = new NationBuilder();
    }

    public void Rund()
    {
        while (this.isRunning)
        {
            var inputCommand = this.ReadInput();
            List<string> commandParameters = this.ParseInput(inputCommand);
            this.DistributeCommand(commandParameters);
        }
    }

    private void DistributeCommand(List<string> commandParameters)
    {
        string command = commandParameters[0];
        commandParameters.Remove(command);

        switch (command)
        {
            case "Bender":
                this.nationBuilder.AssaignBender(commandParameters);
                break;
            case "Monument":
                this.nationBuilder.AssaignMonument(commandParameters);
                break;
            case "Status":
                string status = this.nationBuilder.GetSatatus(commandParameters[0]);
                break;
            case "War":
                this.nationBuilder.IssueWar(commandParameters[0]);
                break;
            case "Quit":
                var record = this.nationBuilder.GetWarsRecord();
                this.OutputWriter(record);
                this.isRunning = false;
                break;

            default:
                break;
        }
    }

    private List<string> ParseInput(string inputCommand)
    {
        return inputCommand.Split(' ').ToList();
    }

    private string ReadInput()
    {
        return Console.ReadLine();
    }
}
