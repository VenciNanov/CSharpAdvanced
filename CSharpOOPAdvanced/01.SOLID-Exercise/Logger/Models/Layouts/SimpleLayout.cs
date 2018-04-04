using Logger.Models.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Layouts
{
    public class SimpleLayout : ILayout
    {
        public SimpleLayout()
        {
            this.Format = "{0} - {1} - {2}"; ;
        }

        public string Format { get; private set; }
    }
}
