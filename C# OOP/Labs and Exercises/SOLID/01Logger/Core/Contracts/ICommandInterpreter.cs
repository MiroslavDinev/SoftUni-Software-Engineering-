namespace _01Logger.Core.Contracts
{
    public interface ICommandInterpreter
    {
        void AddAppender(string[] appenderArgs);

        void AddReport(string[] reportArgs);

        void PrintInfo();
    }
}
