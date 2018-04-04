using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Engine
{
    public readonly List<IWeapon> weapons;
    private readonly IReader reader;
    private readonly IWriter writer;

    public Engine(IReader reader,IWriter writer)
    {
        this.weapons = new List<IWeapon>();

        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        while (true)
        {
            var commandArgs = reader.ReadLine();
            var args = commandArgs.Split(";");
            var command = args[0];
            if (command == "END")
            {
                break;
            }

            ExecuteCommand(command, args.Skip(1).ToArray());
        }
    }

    private void ExecuteCommand(string command, string[] args)
    {
        switch (command)
        {
            case "Create":
                CreateCommand(args);
                break;

            case "Add":
                AddCommand(args);
                break;

            case "Remove":
                RemoveCommand(args);
                break;

            case "Print":
               PrintCommand(args);
                break;
        }

    }

    private void RemoveCommand(string[] args)
    {
        var weaponName = args[0];
        var socketIndex = int.Parse(args[1]);

        weapons.FirstOrDefault(x => x.Name == weaponName)?.Remove(socketIndex);
    }

    private void PrintCommand(string[] args)
    {
        var weaponName = args[0];

        IWeapon weapon = weapons.FirstOrDefault(x => x.Name == weaponName);

        if (weapon!=null)
        {
            writer.WriteLine(weapon.ToString());
        }
    }

    private void AddCommand(string[] args)
    {
        var weaponName = args[0];

        var socketIndex = int.Parse(args[1]);
        var gemArgs = args[2].Split(" ");

        var gemQuality = gemArgs[0];
        var gemTypeName = gemArgs[1];

        if (!Enum.TryParse(gemQuality, out GemQualityLevel gemQualityLevel))
        {
            return;
        }

        Type gemType = Assembly.GetExecutingAssembly().GetTypes().First(x => x.Name.ToLower().Contains(gemTypeName.ToLower()));


        IGem gem = (IGem)Activator.CreateInstance(gemType, new object[] { gemQualityLevel });

        IWeapon weapon = weapons.FirstOrDefault(x => x.Name == weaponName);

        if (gem != null)
        {
            weapon.AddGem(socketIndex, gem);
        }
    }

    private void CreateCommand(string[] args)
    {
        string[] weaponTypeArgs = args[0].Split(' ');

        var rareTypeName = weaponTypeArgs[0];
        var weapongTypeName = weaponTypeArgs[1];
        var weaponName = args[1];

        if (!Enum.TryParse(rareTypeName, out WeaponRarityLevel weaponRarity))
        {
            return;
        }

        object[] parameter =
        {
            weaponName,
            weaponRarity
        };

        Type weaponType = Assembly.GetExecutingAssembly().GetTypes().First(x => x.Name.ToLower().Contains(weapongTypeName.ToLower()));

        IWeapon weapon = (IWeapon)Activator.CreateInstance(weaponType, parameter);

        if (weapon != null)
        {
            weapons.Add(weapon);
        }
    }
}
