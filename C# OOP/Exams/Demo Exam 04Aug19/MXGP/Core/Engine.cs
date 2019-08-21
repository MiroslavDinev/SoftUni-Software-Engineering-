using MXGP.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Core
{
    public class Engine : IEngine
    {
        private ChampionshipController championshipController;

        public Engine()
        {
            this.championshipController = new ChampionshipController();
        }
        public void Run()
        {
            while (true)
            {
                string command = Console.ReadLine();

                if(command=="End")
                {
                    break;
                }

                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string commandType = commandArgs[0];

                try
                {
                    switch (commandType)
                    {
                        case "CreateRider":
                            Console.WriteLine(this.championshipController.CreateRider(commandArgs[1]));
                            break;
                        case "CreateMotorcycle":
                            Console.WriteLine(this.championshipController.CreateMotorcycle(commandArgs[1],commandArgs[2],int.Parse(commandArgs[3])));
                            break;
                        case "AddMotorcycleToRider":
                            Console.WriteLine(this.championshipController.AddMotorcycleToRider(commandArgs[1],commandArgs[2]));
                            break;
                        case "AddRiderToRace":
                            Console.WriteLine(this.championshipController.AddRiderToRace(commandArgs[1],commandArgs[2]));
                            break;
                        case "CreateRace":
                            Console.WriteLine(this.championshipController.CreateRace(commandArgs[1],int.Parse(commandArgs[2])));
                            break;
                        case "StartRace":
                            Console.WriteLine(this.championshipController.StartRace(commandArgs[1]));
                            break;
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
