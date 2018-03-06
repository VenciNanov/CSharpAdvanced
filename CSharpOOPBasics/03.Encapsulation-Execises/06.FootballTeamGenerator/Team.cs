using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Team
{
    private string name;
    private HashSet<Player> players;

    public Team(string name)
    {
        this.Name = name;
        this.players = new HashSet<Player>();
    }

    public string Name
    {
        get { return name; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value) || value == string.Empty)
            {
                throw new ArgumentException("A name should not be empty.");
            }
            name = value;
        }
    }

    public double GetRating()
    {
        if (this.players.Count>0)
        {
            return this.players.Select(x => x.SkillLevel).Average();
        }
        else
        {
            return 0;
        }
    }

    internal void AddPlayer(Player player)
    {
        this.players.Add(player);
    }

    internal bool IsPlayerFound(string playerName)
    {
        return this.players.FirstOrDefault(x => x.Name == playerName) != null;
    }

    internal void RemovePlayer(string playerName)
    {
        if (this==null)
        {
            throw new NullReferenceException($"Team {this.Name} does not exist.");
        }

        if (players.Any(x=>x.Name==playerName))
        {
            this.players.RemoveWhere(x => x.Name == playerName);
        }

        else
        {
            throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
        }
    }


}

