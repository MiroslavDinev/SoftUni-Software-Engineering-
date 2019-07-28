namespace _01Logger.Loggers
{
    using Contracts;
    using System.Linq;

    public class LogFile : ILogFile
    {
        public int Size { get; private set; }

        public void Write(string message)
        {
            this.Size += message.Where(x => char.IsLetter(x)).Sum(x => x);
        }
    }
}
