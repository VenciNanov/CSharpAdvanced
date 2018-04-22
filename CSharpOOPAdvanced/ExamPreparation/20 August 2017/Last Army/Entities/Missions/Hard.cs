using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Hard : Mission
{
    private const string MissionName = "Disposal of terrorists";
    private const double EnduranceRequiredForMission = 80;
    private const double WearLevelDecrease = 70;

    public Hard(double scoreToComplete) : base(scoreToComplete)
    {
    }

    public override string Name => MissionName;

    public override double EnduranceRequired => EnduranceRequiredForMission;

    public override double WearLevelDecrement => WearLevelDecrease;
}
