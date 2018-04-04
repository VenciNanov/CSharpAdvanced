using Logger.Entities.Appenders;
using Logger.Entities.Loggers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Entities.Loggers
{
    public class LoggerClass : ILogger
    {
        private IList<IAppender> appenders;

        public LoggerClass(params IAppender[] appenders)
        {
            this.appenders = new List<IAppender>();

            foreach (var appender in appenders)
            {
                this.appenders.Add(appender);
            }
        }
        public void Critical(string time, string message)
        {
            this.LogMessage(time,ReportLevel.Critical,message);
        }

        public void Error(string time, string message)
        {
            this.LogMessage(time, ReportLevel.Error, message);
        }

        public void Fatal(string time, string message)
        {
            this.LogMessage(time, ReportLevel.Fatal, message);
        }

        public void Info(string time, string message)
        {
            this.LogMessage(time, ReportLevel.Info, message);
        }

        public void PrintLoggerInfo()
        {
            Console.WriteLine("Logger info");
            foreach (var appender in appenders)
            {
                Console.WriteLine(appender);
            }
        }

        public void Warning(string time, string message)
        {
            throw new NotImplementedException();
        }

        private void LogMessage(string time,ReportLevel reportLevel,string message)
        {
            foreach (var appender in this.appenders)
            {
                appender.AppendLine(time, reportLevel, message);
            }
        }
    }
}
