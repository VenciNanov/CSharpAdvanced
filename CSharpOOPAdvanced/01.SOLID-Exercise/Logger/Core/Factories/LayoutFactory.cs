using Logger.Core.Factories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Core.Factories
{
    public class LayoutFactory<T> : IFactory<T>
    {
        private const string LayoutNameSpace = "Logger.Models.Layouts.";
        public T Create(IList<string> data)
        {
            string layoutType = data[1];
            Type layoutClassType = Type.GetType(LayoutNameSpace + layoutType);

            T layout = (T)Activator.CreateInstance(layoutClassType);
            return layout;
        }
    }
}
