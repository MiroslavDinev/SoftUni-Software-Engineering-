using MortalEngines.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Core
{
    public class Engine : IEngine
    {
        private MachinesManager machinesManager;

        public Engine()
        {
            this.machinesManager = new MachinesManager();
        }
        public void Run()
        {
            while (true)
            {
                string command = Console.ReadLine();

                if(command == "Quit")
                {
                    break;
                }

                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string commandType = commandArgs[0];

                try
                {
                    switch (commandType)
                    {
                        case "HirePilot":
                            Console.WriteLine(this.machinesManager.HirePilot(commandArgs[1]));
                            break;
                        case "PilotReport":
                            Console.WriteLine(this.machinesManager.PilotReport(commandArgs[1]));
                            break;
                        case "ManufactureTank":
                            Console.WriteLine(this.machinesManager.ManufactureTank(commandArgs[1],double.Parse(commandArgs[2]),double.Parse(commandArgs[3])));
                            break;
                        case "ManufactureFighter":
                            Console.WriteLine(this.machinesManager.ManufactureFighter(commandArgs[1], double.Parse(commandArgs[2]), double.Parse(commandArgs[3])));
                            break;
                        case "MachineReport":
                            Console.WriteLine(this.machinesManager.MachineReport(commandArgs[1]));
                            break;
                        case "AggressiveMode":
                            Console.WriteLine(this.machinesManager.ToggleFighterAggressiveMode(commandArgs[1]));
                            break;
                        case "DefenseMode":
                            Console.WriteLine(this.machinesManager.ToggleTankDefenseMode(commandArgs[1]));
                            break;
                        case "Engage":
                            Console.WriteLine(this.machinesManager.EngageMachine(commandArgs[1],commandArgs[2]));
                            break;
                        case "Attack":
                            Console.WriteLine(this.machinesManager.AttackMachines(commandArgs[1],commandArgs[2]));
                            break;
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
