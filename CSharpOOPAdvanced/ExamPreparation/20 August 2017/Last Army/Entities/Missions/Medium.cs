using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Medium : Mission
{
    private const string MissionName = "Capturing dangerous criminals";
    private const double EnduranceRequiredForMission = 50;
    private const double WearLevelDecrease = 50;

    public Medium(double scoreToComplete) : base(scoreToComplete)
    {
    }

    public override string Name => MissionName;

    public override double EnduranceRequired =>EnduranceRequiredForMission;

    public override double WearLevelDecrement => WearLevelDecrease;
}
