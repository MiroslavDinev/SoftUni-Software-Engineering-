namespace _01Logger.Appenders.Contracts
{
    using _01Logger.Loggers.Enums;
    public interface IAppender
    {
        void Append(string dateTime, ReportLevel reportLevel, string message);

        ReportLevel ReportLevel { get; set; }
    }
}
