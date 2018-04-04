using Logger.Core.Contracts;
using Logger.Core.Factories.Contracts;
using Logger.Models.Appenders.Contracts;
using Logger.Models.Layouts.Contracts;
using Logger.Models.Loggers;
using Logger.Models.Loggers.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Logger.Core
{
    public class Engine : IEngine
    {
        private IFactory<IAppender> appenderFactory;
        private IFactory<ILayout> layoutFactory;
        public Engine(IFactory<IAppender> appenderFactory,IFactory<ILayout> layoutFactory)
        {
            this.appenderFactory = appenderFactory;
            this.layoutFactory = layoutFactory;
        }
        public void Run()
        {
            IList<IAppender> appenders = new List<IAppender>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                IList<string> tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                ILayout layout = this.layoutFactory.Create(tokens);
                IAppender appender = this.appenderFactory.Create(tokens);
                appender.Layout = layout;
                appenders.Add(appender);
            }
            ILogger logger = new LoggerClass(appenders.ToArray());
            string logMessage = string.Empty;
            while ((logMessage = Console.ReadLine()) != "END")
            {
                var tokens = logMessage.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                MethodInfo method = logger.GetType().GetMethod(ConvertToTitleCase(tokens[0]));
                method.Invoke(logger, new object[] { tokens[1], tokens[2] });
            }
            logger.PrintLoggerInfo();
        }

        private string ConvertToTitleCase(string text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
        }
    }
}
