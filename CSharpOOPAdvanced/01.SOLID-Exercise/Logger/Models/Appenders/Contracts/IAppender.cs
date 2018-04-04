using Logger.Models.Appenders.Enums;
using Logger.Models.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Appenders.Contracts
{
    public interface IAppender
    {
        int MessageCount { get; }
        ReportLevel ReportLevel { get; set; }
        void AppendLine(string time, ReportLevel reportLevel, string message);

        ILayout Layout { get; set; }
    }
}
