using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HardwareFactory
{
    public static Hardware Create(string type, List<string> args)
    {
        var name = args[0];
        var capacity = int.Parse(args[1]);
        var memory = int.Parse(args[2]);

        switch (type)
        {
            case "Power":
                return new Power(name, capacity, memory);

            case "Heavy":
                return new Heavy(name, capacity, memory);


            default:
                throw new ArgumentOutOfRangeException(nameof(type), "Hardware type must be a Power or Heavy");
        }
    }
}
