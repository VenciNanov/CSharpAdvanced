using System;
using System.Collections.Generic;
using System.Text;

public interface IInterpreter
{
    ICommand ParseCommand(List<string> list);
}
