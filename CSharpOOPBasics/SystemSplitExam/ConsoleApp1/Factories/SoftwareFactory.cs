using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SoftwareFactory
{
    public static Software Create(string type, List<string> args)
    {
        var name = args[1];
        var capacity = int.Parse(args[2]);
        var memory = int.Parse(args[3]);

        switch (type)
        {
            case "Express":
                return new Express(name, capacity, memory);

            case "Light":
                return new Light(name, capacity, memory);

            default:
            throw new ArgumentOutOfRangeException(nameof(type), "Software type must be Express or Light");
        }
    }
}