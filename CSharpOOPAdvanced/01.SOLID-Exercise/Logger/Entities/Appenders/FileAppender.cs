using System;
using System.Collections.Generic;
using System.Text;
using Logger.Entities.Files;
using Logger.Entities.Layouts;

namespace Logger.Entities.Appenders
{
    public class FileAppender : IAppender
    {
        public FileAppender(ILayout layout)
        {
            this.Layout = layout;
            this.File = new LogFile();
        }

        public ILogFile File { get; set; }

        public int MessageCount { get; private set; }

        public ReportLevel ReportLevel { get; set; } = ReportLevel.Info;

        public ILayout Layout { get; set; }

        public void AppendLine(string time, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                this.File.Write(string.Format(this.Layout.Format, time, reportLevel.ToString().ToUpper(), message));
                this.MessageCount++;
            }
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel.ToString().ToUpper()}, Messages appended: {this.MessageCount}, File size {this.File.Size}";
        }
    }
}
