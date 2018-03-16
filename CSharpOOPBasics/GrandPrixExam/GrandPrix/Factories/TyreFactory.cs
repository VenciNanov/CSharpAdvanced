using System;
using System.Collections.Generic;
using System.Text;

public class TyreFactory
{
    public static Tyre Create(List<string> args)
    {
        var type = args[0];
        var hardness = double.Parse(args[1]);

        switch (type)
        {
            case "Ultrasoft":
                return new UltrasoftTyre(hardness, double.Parse(args[2]));
            case "Hard":
                return new HardTyre(hardness);
                
            default:
                throw new ArgumentException();
        }
    }
}
