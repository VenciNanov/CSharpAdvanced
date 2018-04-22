using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


public class GameController : IGameController
{
    private const string CommandPrefix = "Parse";
    private const string CommandSuffix = "Command";
    private const string RegenerateCommand = "Regenerate";
    private const string ResultOutput = "Results:";
    private const string SoldiersOutput = "Soldiers:";

    private readonly MissionController missionController;
    private readonly SoldierFactory soldierFactory;
    private readonly MissionFactory missionFactory;
    private IWareHouse wareHouse;
    private IArmy army;
    private readonly IWriter writer;

    public GameController(IWriter writer)
    {
        this.wareHouse = new WareHouse();
        this.writer = writer;
        this.army = new Army();
        this.missionController = new MissionController(this.army, this.wareHouse);
        this.soldierFactory = new SoldierFactory();
        this.missionFactory = new MissionFactory();
    }

    public void ProcessCommand(string input)
    {
        List<string> data = input.Split().ToList();
        string commandType = data[0];
        data.RemoveAt(0);

        string commandFullName = CommandPrefix + commandType + CommandSuffix;

        try
        {
            this.GetType().GetMethod(commandFullName, BindingFlags.NonPublic | BindingFlags.Instance).Invoke(this, new object[] { data });
        }
        catch (TargetInvocationException tie)
        {

            throw tie.InnerException;
        }
    }

    private void ParseWareHouseCommand(IList<string> data)
    {
        string name = data[0];
        var quantity = int.Parse(data[1]);
        this.wareHouse.AddAmmunitions(name, quantity);
    }

    private void ParseSoldierCommand(IList<string> data)
    {
        if (data[0] == RegenerateCommand)
        {
            this.army.RegenerateTeam(data[1]);
        }
        else
        {
            this.AddSoldierToArmy(data);
        }
    }

    private void AddSoldierToArmy(IList<string> data)
    {
        var type = data[0];
        var name = data[1];
        var age = int.Parse(data[2]);
        var expirience = double.Parse(data[3]);
        var endurance = double.Parse(data[4]);

        ISoldier soldier = this.soldierFactory.CreateSoldier(type, name, age, expirience, endurance);

        if (!this.wareHouse.TryEquipSoldier(soldier))
        {
            throw new ArgumentException(string.Format(OutputMessages.NoWeaponsForSoldierType, type, name));
        }

        this.army.AddSoldier(soldier);
    }

    private void ParseMissionCommand(IList<string> data)
    {
        var difficultyLevel = data[0];
        var scoreToComplete = double.Parse(data[1]);
        var mission = this.missionFactory.CreateMission(difficultyLevel, scoreToComplete);

        this.writer.StoreMessage(this.missionController.PerformMission(mission));
    }

    public void ProduceSummury()
    {
        IList<ISoldier> orderedOutput = this.army.Soldiers.OrderByDescending(x => x.OverallSkill).ToList();
        this.missionController.FailMissionsOnHold();

        this.writer.StoreMessage(ResultOutput);
        this.writer.StoreMessage(string.Format(OutputMessages.MissionsSummurySuccessful, this.missionController.SuccessMissionCounter));
        this.writer.StoreMessage(string.Format(OutputMessages.MissionsSummuryFailed, this.missionController.FailedMissionCounter));
        this.writer.StoreMessage(SoldiersOutput);
        foreach (var soldier in orderedOutput)
        {
            this.writer.StoreMessage(soldier.ToString());
        }

    }
}