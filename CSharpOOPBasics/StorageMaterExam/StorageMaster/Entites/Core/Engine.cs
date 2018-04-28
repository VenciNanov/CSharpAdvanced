using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Entites.Core
{
    public class Engine
    {
        private bool isRunning;
        private StorageMaster storageMaster;

        public Engine()
        {
            this.isRunning = true;
            storageMaster = new StorageMaster();
        }

        public void Run()
        {
            while (this.isRunning)
            {
                var input = ReadInput();
                var args = ParseInput(input);
                try
                {
                    ProccessCommand(args);
                }
                catch (InvalidOperationException ex)
                {
                    OutputWriter("Error: " + ex.Message);
                }
            }
        }

        private void ProccessCommand(List<string> args)
        {
            var cmd = args[0];
            args = args.Skip(1).ToList();

            switch (cmd)
            {
                case "AddProduct":
                    OutputWriter(storageMaster.AddProduct(args[0], double.Parse(args[1])));
                    break;
                case "RegisterStorage":
                    OutputWriter(storageMaster.RegisterStorage(args[0], args[1]));
                    break;

                case "SelectVehicle":
                    OutputWriter(storageMaster.SelectVehicle(args[0], int.Parse(args[1])));
                    break;
                case "LoadVehicle":
                    OutputWriter(storageMaster.LoadVehicle(args));
                    break;
                case "SendVehicleTo":
                    OutputWriter(storageMaster.SendVehicleTo(args[0], int.Parse(args[1]), args[2]));
                    break;
                case "UnloadVehicle":
                    OutputWriter(storageMaster.UnloadVehicle(args[0], int.Parse(args[1])));
                    break;
                case "GetStorageStatus":
                    OutputWriter(storageMaster.GetStorageStatus(args[0]));
                    break;
                case "END":
                    OutputWriter(storageMaster.GetSummary());
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
}
