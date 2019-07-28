namespace _01Logger.Appenders.Contracts
{
    using _01Logger.Layouts.Contracts;
    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout);
    }
}
