using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Trainer
{
    private string name;
    private int badges;
    private Stack<Pokemon> pokemons;

    public Trainer(string name)
    {
        this.Name = name;
        this.badges = 0;
        this.pokemons = new Stack<Pokemon>();
    }

    public Stack<Pokemon> Pokemons
    {
        get { return this.pokemons; }
    }

    public string Name
    {
        get { return this.name; }
        private set { this.name = value; }
    }
    public int Badges
    {
        get { return this.badges; }
    }

    public void AddBadges()
    {
        this.badges++;
    }

    internal void ClearPokemons()
    {
        if (this.pokemons.Count > 0 && this.pokemons.Where(x => x.Health <= 0).FirstOrDefault() != null)
        {
            this.pokemons = new Stack<Pokemon>(this.pokemons.Where(p => p.Health > 0));
        }
    }
}
