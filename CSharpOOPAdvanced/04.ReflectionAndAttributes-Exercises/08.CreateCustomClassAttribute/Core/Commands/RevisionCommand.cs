using System;
using System.Collections.Generic;
using System.Text;

class RevisionCommand : Command
{
    public RevisionCommand(string typeName) : base(typeName)
    {
    }

    public override string Execute()
    {
        var result = this.Attribute.Revision;

        return $"Revision: {result}";
    }
}
