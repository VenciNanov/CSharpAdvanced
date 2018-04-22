using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main()
    {
        var king = new King(Console.ReadLine());

        var soldiers = new List<Soldiers>();

        var guardNames = ParseInput(Console.ReadLine());
        var footNames = ParseInput(Console.ReadLine());

        foreach (var name in guardNames)
        {
            var royalGuard = new RoyalGuard(name);
            soldiers.Add(royalGuard);
            king.UnderAttack += royalGuard.KingUnderAttack;
        }
        foreach (var name in footNames)
        {
            var footman = new Footman(name);
            soldiers.Add(footman);
            king.UnderAttack += footman.KingUnderAttack;
        }

        string args = string.Empty;
        while ((args=Console.ReadLine())!="End")
        {
            var input = args;

            var commandArgs = ParseInput(input);
            var command = commandArgs[0];

            switch (command)
            {
                case "Kill":
                    var soldierName = commandArgs[1];
                    var soldier = soldiers.FirstOrDefault(x => x.Name == soldierName);
                    king.UnderAttack -= soldier.KingUnderAttack;
                    soldiers.Remove(soldier);
                    break;

                case "Attack":
                    king.OnAttack();
                    break;
            }
        }
    }

    private static string[] ParseInput(string args)
    {
        return args.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    }
}
