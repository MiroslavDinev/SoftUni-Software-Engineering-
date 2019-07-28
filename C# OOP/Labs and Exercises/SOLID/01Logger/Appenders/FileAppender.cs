namespace _01Logger.Appenders
{
    using _01Logger.Layouts.Contracts;
    using _01Logger.Loggers.Contracts;
    using _01Logger.Loggers.Enums;
    using System;
    using System.IO;
    public class FileAppender : Appender
    {
        private ILogFile logFile;
        public FileAppender(ILayout layout, ILogFile logFile) 
            : base(layout)
        {
            this.logFile = logFile;
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if(this.ReportLevel<=reportLevel)
            {
                this.MessagesCount++;
                string path = @"..\..\..\log.txt";
                string content = string.Format(this.Layout.Format, dateTime, reportLevel, message) + Environment.NewLine;
                this.logFile.Write(content);
                File.AppendAllText(path, content);
            }          
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel}, " +
                $"Messages appended: {this.MessagesCount}, File size: {this.logFile.Size}";
        }
    }
}
