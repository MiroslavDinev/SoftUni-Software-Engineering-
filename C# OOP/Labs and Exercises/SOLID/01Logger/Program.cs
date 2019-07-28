namespace _01Logger
{
    using _01Logger.Core;
    using _01Logger.Core.Contracts;
    public class Program
    {
        public static void Main(string[] args)
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IEngine engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
