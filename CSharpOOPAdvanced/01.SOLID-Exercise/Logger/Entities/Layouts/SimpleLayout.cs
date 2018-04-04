using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Entities.Layouts
{
    public class SimpleLayout : ILayout
    {
        public SimpleLayout()
        {
            this.Format = "{0} - {1} - {2}";
        }

        public string Format { get; private set; }
    }
}
