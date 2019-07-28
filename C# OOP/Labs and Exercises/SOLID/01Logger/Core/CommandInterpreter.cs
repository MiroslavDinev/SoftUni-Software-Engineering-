namespace _01Logger.Core
{
    using _01Logger.Appenders;
    using _01Logger.Appenders.Contracts;
    using _01Logger.Layouts.Contracts;
    using _01Logger.Layouts.Factories;
    using _01Logger.Loggers.Enums;
    using Contracts;
    using System;
    using System.Collections.Generic;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly List<IAppender> appenders;
        private readonly IAppenderFactory appenderFactory;
        private readonly ILayoutFactory layoutFactory;

        public CommandInterpreter()
        {
            this.appenders = new List<IAppender>();
            this.appenderFactory = new AppenderFactory();
            this.layoutFactory = new LayoutFactory();
        }
        public void AddAppender(string[] appenderArgs)
        {
            string appenderType = appenderArgs[0];
            string layoutType = appenderArgs[1];
            ReportLevel reportLevel = ReportLevel.INFO;
            
            if(appenderArgs.Length==3)
            {
                reportLevel = Enum.Parse<ReportLevel>(appenderArgs[2]);
            }

            ILayout layout = this.layoutFactory.CreateLayout(layoutType);
            IAppender appender = this.appenderFactory.CreateAppender(appenderType, layout);

            appender.ReportLevel = reportLevel;

            appenders.Add(appender);
        }

        public void AddReport(string[] reportArgs)
        {
            ReportLevel reportLevel = Enum.Parse<ReportLevel>(reportArgs[0]);
            string dateTime = reportArgs[1];
            string message = reportArgs[2];

            foreach (var appender in this.appenders)
            {
                appender.Append(dateTime, reportLevel, message);
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine("Logger info");

            foreach (var appender in this.appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
