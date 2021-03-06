﻿using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private const string Shutdown = "Shutdown";
    private ICommandInterpreter commandInterpreter;
    private IReader reader;
    private IWriter writer;

    public Engine(ICommandInterpreter commandInterpreter, IReader reader, IWriter writer)
    {
        this.commandInterpreter = commandInterpreter;
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        string input = string.Empty;
        while (input != Shutdown)
        {
            input = reader.ReadLine();

            var data = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var result = this.commandInterpreter.ProcessCommand(data);
            if (result == string.Empty)
            {
                continue;
            }
            writer.WriteLine(result);

        }
    }
}
