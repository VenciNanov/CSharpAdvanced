using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string difficultyLevel, double neededPoints)
    {
        Type missionType = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(x => x.Name == difficultyLevel);

        return (IMission)Activator
            .CreateInstance(missionType, neededPoints);
    }
}
