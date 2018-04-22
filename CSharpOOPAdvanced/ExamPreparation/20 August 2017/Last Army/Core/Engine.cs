using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Engine : IEngine
{
    private IReader reader;
    private IWriter writer;
    private bool isRunning;
    private IGameController gameController;

    public Engine(IReader reader, IWriter writer, IGameController gameController)
    {
        this.isRunning = false;
        this.reader = reader;
        this.writer = writer;
        this.gameController = gameController;
    }

    public void Run()
    {
        this.isRunning = true;

        while (this.isRunning)
        {
            var input = this.reader.ReadLine();
            if (input == OutputMessages.InputTerminateString)
            {
                this.isRunning = false;
                continue;
            }

            try
            {
                gameController.ProcessCommand(input);
            }
            catch (ArgumentException ex)
            {
                this.writer.StoreMessage(ex.Message);
            }
        }

        this.gameController.ProduceSummury();
        this.writer.WriteLine(this.writer.StoredMessage.Trim());
    }
}

