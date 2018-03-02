using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var soldiers = new List<Soldier>();

            var input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split();
                var soldierType = tokens[0];

                Soldier soldier;

                try
                {
                    soldier = GetSoldier(tokens, soldierType, soldiers);
                }
                catch (ArgumentException ex)
                {
                    
                    continue;
                }
                soldiers.Add(soldier);
            }

            Console.WriteLine(string.Join(Environment.NewLine,soldiers));

        }

        public static Soldier GetSoldier(string[] tokens, string soldierType, List<Soldier> soldiers)
        {
            var id = int.Parse(tokens[1]);
            var firstName = tokens[2];
            var lastName = tokens[3];

            switch (soldierType)
            {

                case "Private":
                    var privateSalary = decimal.Parse(tokens[4]);
                    return new Private(id, firstName, lastName, privateSalary);

                case "LeutenantGeneral":
                    var LeutenantSalary = decimal.Parse(tokens[4]);
                    LeutenantGeneral leutenant = new LeutenantGeneral(id, firstName, lastName, LeutenantSalary);

                    for (int i = 5; i < tokens.Length; i++)
                    {
                        var privateId = int.Parse(tokens[i]);
                        Private currentPrivate = (Private)soldiers.FirstOrDefault(x => x.Id == privateId);

                        leutenant.AddPrivate(currentPrivate);
                    }
                    return leutenant;

                case "Engineer":
                    var engineerSalary = decimal.Parse(tokens[4]);
                    var engineerCorp = tokens[5];
                    Engineer engineer = new Engineer(id, firstName, lastName, engineerSalary, engineerCorp);

                    for (int i = 6; i < tokens.Length; i+=2)
                    {
                        var part = tokens[i];
                        var hours = int.Parse(tokens[i + 1]);
                        var repair = new Repair(part, hours);

                        engineer.AddRepair(repair);
                    }
                    return engineer;

                case "Commando":
                    var commandoSalary = decimal.Parse(tokens[4]);
                    var commandoCorp = tokens[5];
                    Commando commando = new Commando(id, firstName, lastName, commandoSalary, commandoCorp);

                    for (int i = 6; i < tokens.Length; i+=2)
                    {
                        var codeName = tokens[i];
                        var state = tokens[i + 1];
                        Mission mission;
                        try
                        {
                            mission = new Mission(codeName, state);
                        }
                        catch(ArgumentException ex)
                        {
                            continue;
                        }
                        commando.AddMission(mission);

                    }

                    return commando;

                case "Spy":
                    var codeNumber = int.Parse(tokens[4]);
                    Spy spy = new Spy(id, firstName, lastName, codeNumber);

                    return spy;

                default:
                    throw new ArgumentException();

            }
        }
    }
}
