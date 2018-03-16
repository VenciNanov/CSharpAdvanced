using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Engine
{
    private List<Hardware> hardwares;
    private List<Software> softwares;
    private List<Hardware> dump;

    public Engine()
    {
        this.hardwares = new List<Hardware>();
        this.softwares = new List<Software>();
        this.dump = new List<Hardware>();
    }
    public void Execute()
    {
        while (true)
        {
            var commandArgs = GetCommand();

            string command = commandArgs[0];
            var args = commandArgs.Skip(1).ToList();
            switch (command)
            {
                case "RegisterPowerHardware":
                    Hardware hardware = HardwareFactory.Create("Power", args);

                    this.hardwares.Add(hardware);
                    break;

                case "RegisterHeavyHardware":
                    hardware = HardwareFactory.Create("Heavy", args);
                    this.hardwares.Add(hardware);
                    break;

                case "RegisterExpressSoftware":
                    var hardwareComponent = commandArgs[1];

                    try
                    {
                        hardware = hardwares.FirstOrDefault(h => h.Name == hardwareComponent);

                        Software software = SoftwareFactory.Create("Express", args);
                        hardware.AddSoftwareComponent(software);
                        this.softwares.Add(software);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                    break;

                case "RegisterLightSoftware":
                    hardwareComponent = commandArgs[1];

                    try
                    {
                        hardware = hardwares.FirstOrDefault(h => h.Name == hardwareComponent);

                        Software software = SoftwareFactory.Create("Light", args);
                        hardware.AddSoftwareComponent(software);
                        this.softwares.Add(software);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                    break;

                case "ReleaseSoftwareComponent":
                    hardwareComponent = commandArgs[1];

                    var softwareComponent = commandArgs[2];

                    try
                    {
                        hardware = hardwares.FirstOrDefault(x => x.Name == hardwareComponent);
                        Software software = hardware.RealeaseSoftwareComponent(softwareComponent);
                        softwares.Remove(software);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                    break;

               
                case "Dump":
                    hardwareComponent = commandArgs[1];
                    if (!hardwares.Exists(x=>x.Name==hardwareComponent))
                    {
                        continue;
                    }

                    try
                    {
                        hardware = hardwares.FirstOrDefault(x => x.Name == hardwareComponent);

                        hardwares.Remove(hardware);

                        dump.Add(hardware);

                    }
                    catch (Exception)
                    {
                        continue;
                    }
                    break;

                case "Restore":
                    hardwareComponent = commandArgs[1];

                    if (!dump.Exists(x=>x.Name==hardwareComponent))
                    {
                        continue;
                    }

                    try
                    {
                        hardware = dump.FirstOrDefault(x => x.Name == hardwareComponent);

                        dump.Remove(hardware);
                        hardwares.Add(hardware);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                    break;

                case "Destroy":
                    hardwareComponent = commandArgs[1];

                    if (!dump.Exists(x=>x.Name==hardwareComponent))
                    {
                        continue;
                    }

                    try
                    {
                        hardware = dump.FirstOrDefault(x => x.Name == hardwareComponent);

                        dump.Remove(hardware);

                    }
                    catch (Exception)
                    {
                        continue;
                    }
                    break;

                case "DumpAnalyze":
                   StringBuilder sb = new StringBuilder();

                    sb.AppendLine($"Dump Analysis");

                    int countOfPowerHardwareComponents = dump.Where(c => c.GetType().Name == "Power").Count();
                    int countOfHeavyHardwareComponents = dump.Where(c => c.GetType().Name == "Heavy").Count();
                    int countOfExpressSoftwareComponents = dump.Sum(c => c.Softwares.Where(s => s.GetType().Name == "Express").Count());
                    int countOfLightSoftwareComponents = dump.Sum(c => c.Softwares.Where(s => s.GetType().Name == "Light").Count()); ;
                    int totalDumpedMemory = dump.Sum(c => c.TotalOperationMemoryInUse);
                    int totalDumpedCapacity = dump.Sum(c => c.TotalCapacityTaken);

                    sb.AppendLine($"Power Hardware Components: {countOfPowerHardwareComponents}");
                    sb.AppendLine($"Heavy Hardware Components: {countOfHeavyHardwareComponents}");
                    sb.AppendLine($"Express Software Components: {countOfExpressSoftwareComponents}");
                    sb.AppendLine($"Light Software Components: {countOfLightSoftwareComponents}");

                    sb.AppendLine($"Total Dumped Memory: {totalDumpedMemory}");
                    sb.AppendLine($"Total Dumped Capacity: {totalDumpedCapacity}");

                    Console.WriteLine(sb.ToString().Trim());

                    break;

                case "Analyze":
                    sb = new StringBuilder();

                    sb.AppendLine($"System Analysis");
                    sb.AppendLine($"Hardware Components: {hardwares.Count()}");
                    sb.AppendLine($"Software Components: {hardwares.Sum(x => x.Softwares.Count())}");

                    var totalOperationalMemory = hardwares.Sum(x => x.TotalOperationMemoryInUse);
                    int TotalMemory = hardwares.Sum(x => x.MaximumMemory);

                    sb.AppendLine($"Total Operational Memory: {totalOperationalMemory} / {TotalMemory}");


                    int TotalCapacityTaken = hardwares.Sum(h => h.TotalCapacityTaken);
                    int TotalCapacity = hardwares.Sum(h => h.MaximumCapacity);

                    sb.AppendLine($"Total Capacity Taken: {TotalCapacityTaken} / {TotalCapacity}");

                    Console.WriteLine(sb.ToString().Trim());

                    break;

                case "System":
                    Console.Write(SystemInformation());
                    return ;
            }
        }
    }

    private string SystemInformation()
    {
        var sb = new StringBuilder();

        foreach (var component in hardwares.OrderByDescending(h => h.GetType().Name))
        {
            sb.AppendLine($"Hardware Component - {component.Name}");

            var softwareComponents = component.Softwares;
            var countOfExpressSoftwareComponents = softwareComponents.Where(s => s.GetType().Name == "Express").Count();
            sb.AppendLine($"Express Software Components - {countOfExpressSoftwareComponents}");

            var countOfLightSoftwareComponents = softwareComponents.Where(s => s.GetType().Name == "Light").Count();
            sb.AppendLine($"Light Software Components - {countOfLightSoftwareComponents}");

            sb.AppendLine($"Memory Usage: {component.TotalOperationMemoryInUse} / {component.MaximumMemory}");

            sb.AppendLine($"Capacity Usage: {component.TotalCapacityTaken} / {component.MaximumCapacity}");

            sb.AppendLine($"Type: {component.GetType().Name}");

            var allSoftwares = softwareComponents.Count == 0 ? "None" : string.Join(", ", softwareComponents);
            sb.AppendLine($"Software Components: {allSoftwares}");

        }
        return sb.ToString().Trim();
    }

    private string[] GetCommand()
    {
        string input = System.Console.ReadLine();
        string[] commandArgs = input.Split(new char[] { '(', ' ', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);

        return commandArgs;
    }

}
