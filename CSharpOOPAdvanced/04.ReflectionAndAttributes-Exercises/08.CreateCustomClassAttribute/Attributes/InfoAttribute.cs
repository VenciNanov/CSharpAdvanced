using System;
using System.Collections.Generic;
using System.Text;


[AttributeUsage(AttributeTargets.Class)]
public class InfoAttribute : Attribute
{
    public InfoAttribute(string author, int revision, string description, params string[] reviewers)
    {
        this.Author = author;
        this.Revision = revision;
        this.Description = description;
        this.Reviewers = new List<string>(reviewers);
    }

    public string Author { get; set; }
    public int Revision { get; set; }
    public string Description { get; set; }
    public List<string> Reviewers { get; set; }
}
