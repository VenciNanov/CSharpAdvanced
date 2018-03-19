using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xam.Core
{
    public class Engine
    {
        private bool isRunning;
        private DungeonMaster dungeon;

        public Engine()
        {
            this.isRunning = true;
            this.dungeon = new DungeonMaster();
        }

        public void Run()
        {
            while (this.isRunning)
            {
                var inputCommand = this.ReadInput();
                var commandParameters = this.ParseInput(inputCommand);

                if (string.IsNullOrEmpty(inputCommand))
                {
                    isRunning = false;
                    break;
                }
                try
                {
                    this.Execute(commandParameters);
                }
                catch (ArgumentException ae)
                {
                    OutputWriter($"Parameter Error: {ae.Message}");
                }
                catch (InvalidOperationException ioe)
                {
                    OutputWriter($"Invalid Operation: {ioe.Message}");
                }
            }
        }

        private void Execute(string[] commandParameters)
        {
            var command = commandParameters[0];
            commandParameters = commandParameters.Skip(1).ToArray();

            switch (command)
            {
                case "JoinParty":
                    OutputWriter(this.dungeon.JoinParty(commandParameters));
                    break;

                case "AddItemToPool":
                    OutputWriter(this.dungeon.AddItemToPool(commandParameters));
                    break;

                case "PickUpItem":
                    OutputWriter(this.dungeon.PickUpItem(commandParameters));
                    break;

                case "UseItem":
                    OutputWriter(this.dungeon.UseItem(commandParameters));
                    break;

                case "UseItemOn":
                    OutputWriter(this.dungeon.UseItemOn(commandParameters));
                    break;

                case "GetStats":
                    OutputWriter(this.dungeon.GetStats());
                    break;

                case "GiveCharacterItem":
                    OutputWriter(this.dungeon.GiveCharacterItem(commandParameters));
                    break;

                case "Attack":
                    OutputWriter(this.dungeon.Attack(commandParameters));
                    break;

                case "Heal":
                    OutputWriter(this.dungeon.Heal(commandParameters));
                    break;

                case "EndTurn":
                    OutputWriter(this.dungeon.EndTurn(commandParameters));
                    break;

                case "IsGameOver":

                    var isOver = this.dungeon.IsGameOver();
                    isRunning = false;
                    OutputWriter(isOver);
                    break;
            }
        }

        private void OutputWriter(string status) => Console.WriteLine(status);
        private void OutputWriter(bool status) => Console.WriteLine(status);

        private string[] ParseInput(string inputCommand)
        {
            return inputCommand.Split().ToArray();
        }

        private string ReadInput()
        {
            return Console.ReadLine();
        }
    }
}
