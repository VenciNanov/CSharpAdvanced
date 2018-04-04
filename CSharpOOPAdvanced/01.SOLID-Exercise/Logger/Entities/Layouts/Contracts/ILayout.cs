using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Entities.Layouts
{
   public interface ILayout
    {
        string Format { get; }
    }
}
