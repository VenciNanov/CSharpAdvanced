using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engine
{
    private bool isRunning;
    private DraftManager manager;

    public Engine()
    {
        this.isRunning = true;
        this.manager = new DraftManager();
    }

    public void Run()
    {
        while (this.isRunning)
        {
            var input = this.ReadInput();
            var commandParams = this.ParseInput(input);
            this.Execute(commandParams);
        }

    }

    private void Execute(List<string> args)
    {
        string command = args[0];

        args = args.Skip(1).ToList();

        switch (command)
        {
            case "RegisterHarvester":
                OutputWriter(this.manager.RegisterHarvester(args));
                break;

            case "RegisterProvider":
                OutputWriter(this.manager.RegisterProvider(args));
                break;

            case "Day":
                OutputWriter(this.manager.Day());
                break;

            case "Mode":
                OutputWriter(this.manager.Mode(args));
                break;

            case "Check":
                OutputWriter(this.manager.Check(args));
                break;

            case "Shutdown":
                OutputWriter(this.manager.ShutDown());
                this.isRunning = false;
                break;
        }
    }

    private void OutputWriter(string status) => Console.WriteLine(status);

    private List<string> ParseInput(string input)
    {
        return input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    private string ReadInput()
    {
        return Console.ReadLine();
    }
}
