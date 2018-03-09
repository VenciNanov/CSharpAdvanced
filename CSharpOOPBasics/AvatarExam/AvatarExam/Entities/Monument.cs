using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Monument
{
    private string name;

    public Monument(string name)
    {
        this.name = name;
    }

    public abstract int GetAffinity();
}
