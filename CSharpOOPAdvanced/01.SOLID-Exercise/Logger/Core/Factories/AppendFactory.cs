using Logger.Core.Factories.Contracts;
using Logger.Entities.Appenders;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Logger.Core.Factories
{
    public class AppendFactory<T> : IFactory<T>
    {
        private const string AppenderNameSpace = "Logger.Models.Appenders.";

        public T Create(IList<string> data)
        {
            string appendType = data[0];
            ReportLevel reportLevel = 0;
            if (data.Count>2)
            {
                string rLevel = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(data[2].ToLower());

                reportLevel = (ReportLevel)Enum.Parse(typeof(ReportLevel), rLevel);
            }

            Type appenderClassType = Type.GetType(AppenderNameSpace + appendType);

            T appender = (T)Activator.CreateInstance(appenderClassType, new object[] { null, reportLevel });

            return appender;
        }
    }
}
