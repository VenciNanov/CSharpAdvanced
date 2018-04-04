using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Core.Factories.Contracts
{
    public interface IFactory<T>
    {
        T Create(IList<string> data);
    }
}
