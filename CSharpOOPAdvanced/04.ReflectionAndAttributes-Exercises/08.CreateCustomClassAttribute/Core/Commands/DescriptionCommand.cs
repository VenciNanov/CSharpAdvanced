using System;
using System.Collections.Generic;
using System.Text;

public class DescriptionCommand : Command
{
    public DescriptionCommand(string typeName) : base(typeName)
    {
    }

    public override string Execute()
    {
        var result = this.Attribute.Description;
        return $"Class descripton:{result}";
    }
}
