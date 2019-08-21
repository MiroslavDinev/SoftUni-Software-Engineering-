namespace PlayersAndMonsters.Core
{
    using PlayersAndMonsters.Core.Contracts;
    using System;
    public class Engine : IEngine
    {
        private ManagerController managerController;

        public Engine()
        {
            this.managerController = new ManagerController();
        }
        public void Run()
        {
            while (true)
            {
                string command = Console.ReadLine();

                if(command == "Exit")
                {
                    break;
                }

                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string commandName = commandArgs[0];

                try
                {
                    switch (commandName)
                    {
                        case "AddPlayer":
                            Console.WriteLine(this.managerController.AddPlayer(commandArgs[1],commandArgs[2]));
                            break;
                        case "AddCard":
                            Console.WriteLine(this.managerController.AddCard(commandArgs[1],commandArgs[2]));
                            break;
                        case "AddPlayerCard":
                            Console.WriteLine(this.managerController.AddPlayerCard(commandArgs[1],commandArgs[2]));
                            break;
                        case "Fight":
                            Console.WriteLine(this.managerController.Fight(commandArgs[1],commandArgs[2]));
                            break;
                        case "Report":
                            Console.WriteLine(this.managerController.Report());
                            break;
                    }
                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
