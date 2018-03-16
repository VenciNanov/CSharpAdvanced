using System;
using System.Collections.Generic;
using System.Text;

public abstract class Miner
{
    private string id;

    public Miner(string id)
    {
        Id = id;
    }

    public string Id
    {
        get { return id; }
        private set { id = value; }
    }

}
