using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Layouts.Contracts
{
    public interface ILayout
    {
        string Format { get; }
    }
}
