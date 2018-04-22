using System;
using NUnit.Framework;

[TestFixture]
public class LastArmyTests
{
    private IMissionController missionController;

    public void MissionControllerDisplaysFailMessage()
    {
        var army = new Army();
        var wareHouse = new WareHouse();
        var missionController = new MissionController(army, wareHouse);

        var mission = new Easy(1);
        string result = "";
        for (int i = 0; i < 4; i++)
        {
            result = missionController.PerformMission(mission);
        }
        Assert.IsTrue(result.StartsWith("Mission declined - Suppression of civil rebelion"));
    }

    public void MissionControllerDisplaysSuccessMessage()
    {
        var army = new Army();
        var wareHouse = new WareHouse();
        var missionController = new MissionController(army, wareHouse);

        var mission = new Easy(0);
        var result = missionController.PerformMission(mission);

        Assert.IsTrue(result.StartsWith("Mission completed - Suppression of civil rebellion"));
    }

}
