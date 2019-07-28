namespace _01Logger.Core
{
    using Contracts;
    using System;

    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        public void Run()
        {
            int appendersCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < appendersCount; i++)
            {
                string[] appenderArgs = Console.ReadLine().Split();

                this.commandInterpreter.AddAppender(appenderArgs);
            }

            while (true)
            {
                string command = Console.ReadLine();

                if(command == "END")
                {
                    break;
                }

                string[] reportArgs = command.Split("|");

                this.commandInterpreter.AddReport(reportArgs);
            }

            this.commandInterpreter.PrintInfo();
        }
    }
}
