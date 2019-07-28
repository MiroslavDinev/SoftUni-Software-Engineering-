namespace _01Logger.Appenders
{
    using _01Logger.Layouts.Contracts;
    using _01Logger.Loggers.Enums;
    using Contracts;

    public abstract class Appender : IAppender
    {
        public Appender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ReportLevel ReportLevel { get; set; }

        public ILayout Layout { get; }

        public int MessagesCount { get; protected set; }

        public abstract void Append(string dateTime, ReportLevel reportLevel, string message);
        
    }
}
