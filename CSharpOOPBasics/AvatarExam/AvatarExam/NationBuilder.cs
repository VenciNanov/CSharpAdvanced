using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class NationBuilder
{
    private Dictionary<string, Nation> nations;
    public NationBuilder()
    {
        this.nations = new Dictionary<string, Nation>()
        {
            {"Air",new Nation() },
            {"Fire",new Nation() },
            {"Earth",new Nation() },
            {"Water",new Nation() }
        };
    }

    public void AssaignBender(List<string> benderArgs)
    {
        var benderType = benderArgs[0];
        Bender currentBender = this.GetBender(benderArgs);
        this.nations[benderType].AddBender(currentBender);
    }

    private Bender GetBender(List<string> benderArgs)
    {
        var benderType = benderArgs[0];
        var benderName = benderArgs[1];
        var benderPower = int.Parse(benderArgs[2]);
        var benderAuxParam = double.Parse(benderArgs[3]);

        switch (benderType)
        {
            case "Air":
                return new AirBender(benderName, benderPower, benderAuxParam);
            case "Water":
                return new WaterBender(benderName, benderPower, benderAuxParam);
            case "Fire":
                return new FireBender(benderName, benderPower, benderAuxParam);
            case "Earth":
                return new EarthBender(benderName, benderPower, benderAuxParam);
            default:
                throw new ArgumentException();
        }
    }
}
