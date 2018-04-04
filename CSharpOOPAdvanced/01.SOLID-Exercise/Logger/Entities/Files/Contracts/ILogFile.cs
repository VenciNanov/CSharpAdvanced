using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Entities.Files
{
  public  interface ILogFile
    {
        void Write(string message);

        int Size { get; }
    }
}
