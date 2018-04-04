using Logger.Core;
using Logger.Core.Contracts;
using Logger.Core.Factories;
using Logger.Core.Factories.Contracts;
using Logger.Models.Appenders.Contracts;
using Logger.Models.Layouts.Contracts;
using System;

namespace Logger
{
    class StartUp
    {
        private static void Main(string[] args)
        {
            IFactory<IAppender> appenderFactory = new AppenderFactory<IAppender>();
            IFactory<ILayout> layoutFactory = new LayoutFactory<ILayout>();
            IEngine engine = new Engine(appenderFactory, layoutFactory);
            engine.Run();
        }
    }
}
