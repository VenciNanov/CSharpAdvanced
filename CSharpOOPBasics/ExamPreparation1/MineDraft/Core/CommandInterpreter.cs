using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class CommandInterpreter
{
    private InputReader reader;
    private OutputWriter writer;
    private DraftManager manager;

    public CommandInterpreter()
    {
        this.reader = new InputReader();
        this.writer = new OutputWriter();
        this.manager = new DraftManager();
    }

    public void Start()
    {

        while (true)
        {
            var commandArgs = this.reader.ReadLine().Split();
            var command = commandArgs[0];

            var result = string.Empty;

            switch (command)
            {
                case "RegisterHarvester":
                    result = this.manager.RegisterHarvester(commandArgs.Skip(1).ToList());
                    break;

                case "RegisterProvider":
                    result = this.manager.RegisterProvider(commandArgs.Skip(1).ToList());
                    break;

                case "Day":
                    result = this.manager.Day();
                    break;

                case "Check":
                    result = this.manager.Check(commandArgs.Skip(1).ToList());
                    break;

                case "Mode":
                    result = this.manager.Mode(commandArgs.Skip(1).ToList());
                    break;

                case "Shutdown":
                    result = this.manager.ShutDown();
                    break;
            }

            if (result!=string.Empty)
            {
                this.writer.WriteLine(result);
            }
            if (command == "Shutdown") break;
            {

            }
        }
    }
}