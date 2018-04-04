using System;
using System.Collections.Generic;
using System.Text;

public class ReviewersCommand : Command
{
    public ReviewersCommand(string typeName) : base(typeName)
    {
    }

    public override string Execute()
    {
        var result = this.Attribute.Reviewers;

        return $"Reviewers: {string.Join(", ", result)}";
    }
}