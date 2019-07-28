using _01Logger.Appenders.Contracts;
namespace _01Logger.Appenders
{
    using _01Logger.Layouts.Contracts;
    using _01Logger.Loggers;
    using System;

    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout)
        {
            string loweredType = type.ToLower();

            switch (loweredType)
            {
                case "consoleappender":
                    return new ConsoleAppender(layout);
                case "fileappender":
                    return new FileAppender(layout, new LogFile());
                default:
                    throw new ArgumentException("Invalid appender type!");
            }
        }
    }
}
