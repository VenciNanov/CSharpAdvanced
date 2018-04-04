using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Loggers.Contracts
{
    public interface ILogger
    {
        void Warning(string time, string message);
        void Error(string time, string message);
        void Info(string time, string message);
        void Fatal(string time, string message);
        void Critical(string time, string message);
        void PrintLoggerInfo();
    }
}
