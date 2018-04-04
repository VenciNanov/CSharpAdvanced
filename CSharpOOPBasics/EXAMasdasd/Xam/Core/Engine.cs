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
                var commandParameters = this.ReadInput();
               // var commandParameters = this.ParseInput(inputCommand);

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
                if (this.dungeon.IsGameOver() || this.isRunning == false)
                {
                    OutputWriter("Final stats:");
                    OutputWriter(this.dungeon.GetStats());
                    this.isRunning = false;
                }
            }
        }

        private void Execute(string command)
        {
            if (string.IsNullOrEmpty(command))
            {
                this.isRunning = false;
                return;
            }

            var commandArgs = command.Split(' ');
            var commandName = commandArgs[0];
            var args = commandArgs.Skip(1).ToArray();
                        
            switch (commandName)
            {
                case "JoinParty":
                    OutputWriter(this.dungeon.JoinParty(args));
                    break;

                case "AddItemToPool":
                    OutputWriter(this.dungeon.AddItemToPool(args));
                    break;

                case "PickUpItem":
                    OutputWriter(this.dungeon.PickUpItem(args));
                    break;

                case "UseItem":
                    OutputWriter(this.dungeon.UseItem(args));
                    break;

                case "UseItemOn":
                    OutputWriter(this.dungeon.UseItemOn(args));
                    break;

                case "GetStats":
                    OutputWriter(this.dungeon.GetStats());
                    break;

                case "GiveCharacterItem":
                    OutputWriter(this.dungeon.GiveCharacterItem(args));
                    break;

                case "Attack":
                    OutputWriter(this.dungeon.Attack(args));
                    break;

                case "Heal":
                    OutputWriter(this.dungeon.Heal(args));
                    break;

                case "EndTurn":
                    OutputWriter(this.dungeon.EndTurn(args));
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
