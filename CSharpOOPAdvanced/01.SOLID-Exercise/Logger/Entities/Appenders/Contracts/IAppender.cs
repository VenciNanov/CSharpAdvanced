using Logger.Entities.Appenders;
using Logger.Entities.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Entities
{
   public interface IAppender
    {
        int MessageCount { get; }

        ReportLevel ReportLevel { get; set; }

        void AppendLine(string time, ReportLevel reportLevel, string message);

        ILayout Layout { get; set; }
    }
}
