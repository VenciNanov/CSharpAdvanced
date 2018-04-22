using System;
using System.Collections.Generic;
using System.Text;

public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs e);

public class Dispatcher
{
    private string name;
    public event NameChangeEventHandler NameChange;

    public string Name
    {
        get { return name; }
        set
        {
            name = value;
            OnNameChange(new NameChangeEventArgs(value));
        }
    }

    private void OnNameChange(NameChangeEventArgs args)
    {
        NameChange?.Invoke(this, args);
    }
}
