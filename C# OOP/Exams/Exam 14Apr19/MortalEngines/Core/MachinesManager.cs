namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using MortalEngines.Entities.Machines;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private List<IPilot> pilots;
        private List<IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }
        public string HirePilot(string name)
        {
            if(this.pilots.Any(x=>x.Name==name))
            {
                return $"Pilot {name} is hired already";
            }

            var pilot = new Pilot(name);

            this.pilots.Add(pilot);

            return $"Pilot {name} hired";
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if(this.machines.Any(x=>x.Name == name))
            {
                return $"Machine {name} is manufactured already";
            }

            var tank = new Tank(name, attackPoints, defensePoints);

            this.machines.Add(tank);

            return $"Tank {name} manufactured - attack: {tank.AttackPoints:f2}; defense: {tank.DefensePoints:f2}";
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if(this.machines.Any(x=>x.Name == name))
            {
                return $"Machine {name} is manufactured already";
            }

            var fighter = new Fighter(name, attackPoints, defensePoints);

            this.machines.Add(fighter);

            return $"Fighter {name} manufactured - attack: {fighter.AttackPoints:f2}; defense: {fighter.DefensePoints:f2}; aggressive: ON";
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            var pilot = this.pilots.FirstOrDefault(x => x.Name == selectedPilotName);

            if(pilot==null)
            {
                return $"Pilot {selectedPilotName} could not be found";
            }

            var machine = this.machines.FirstOrDefault(x => x.Name == selectedMachineName);

            if(machine == null)
            {
                return $"Machine {selectedMachineName} could not be found";
            }

            if(machine.Pilot!=null)
            {
                return $"Machine {selectedMachineName} is already occupied";
            }

            pilot.AddMachine(machine);
            machine.Pilot = pilot;

            return $"Pilot {selectedPilotName} engaged machine {selectedMachineName}";
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            var attacker = this.machines.FirstOrDefault(x => x.Name == attackingMachineName);

            if(attacker==null)
            {
                return $"Machine {attackingMachineName} could not be found";
            }

            var defender = this.machines.FirstOrDefault(x => x.Name == defendingMachineName);

            if(defender == null)
            {
                return $"Machine {defendingMachineName} could not be found";
            }

            if(attacker.HealthPoints==0)
            {
                return $"Dead machine {attackingMachineName} cannot attack or be attacked";
            }

            if(defender.HealthPoints==0)
            {
                return $"Dead machine {defendingMachineName} cannot attack or be attacked";
            }

            attacker.Attack(defender);

            return $"Machine {defendingMachineName} was attacked by machine {attackingMachineName} - current health: {defender.HealthPoints:f2}";
        }

        public string PilotReport(string pilotReporting)
        {
            var pilot = this.pilots.FirstOrDefault(x => x.Name == pilotReporting);

            return pilot.Report();
        }

        public string MachineReport(string machineName)
        {
            var machine = this.machines.FirstOrDefault(x => x.Name == machineName);

            return machine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            Fighter fighter = (Fighter)this.machines.FirstOrDefault(x => x.Name == fighterName);

            if(fighter == null)
            {
                return $"Machine {fighterName} could not be found";
            }

            fighter.ToggleAggressiveMode();

            return $"Fighter {fighterName} toggled aggressive mode";
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            Tank tank = (Tank)this.machines.FirstOrDefault(x => x.Name == tankName);

            if(tank==null)
            {
                return $"Machine {tankName} could not be found";
            }

            tank.ToggleDefenseMode();

            return $"Tank {tankName} toggled defense mode";
        }
    }
}