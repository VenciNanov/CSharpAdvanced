using System;
using System.Collections.Generic;
using System.Text;

    public class HarvesterFactory
    {

        public static Harvester Create(List<string> arguments)
        {
            var type = arguments[0];
            var id = arguments[1];
            var oreOutput = double.Parse(arguments[2]);
            var energyRequirements = double.Parse(arguments[3]);

            switch (type)
            {
                case "Hammer":
                    return new HammerHarvester(id, oreOutput, energyRequirements);
                case "Sonic":
                    return new SonicHarvester(id, oreOutput, energyRequirements, int.Parse(arguments[4]));
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), "Harvester type must be Hammer or Sonic!");

            }
        }
    }
