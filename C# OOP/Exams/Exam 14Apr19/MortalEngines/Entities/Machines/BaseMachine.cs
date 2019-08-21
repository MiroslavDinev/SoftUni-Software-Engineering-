namespace MortalEngines.Entities.Machines
{
    using MortalEngines.Entities.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;
        private List<string> targets;

        protected BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            this.targets = new List<string>();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }
            set
            {
                if(value==null)
                {
                    throw new NullReferenceException("Pilot cannot be null.");
                }

                this.pilot = value;
            }
        }
        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets => this.targets;

        public void Attack(IMachine target)
        {
            if(target==null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

            target.HealthPoints -= this.AttackPoints - target.DefensePoints;

            if(target.HealthPoints<0)
            {
                target.HealthPoints = 0;
            }

            this.targets.Add(target.Name);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"- {this.Name}");
            stringBuilder.AppendLine($" *Type: {this.GetType().Name}");
            stringBuilder.AppendLine($" *Health: {this.HealthPoints:f2}");
            stringBuilder.AppendLine($" *Attack: {this.AttackPoints:f2}");
            stringBuilder.AppendLine($" *Defense: {this.DefensePoints:f2}");

            string targetsCount = "None";

            if(this.targets.Count!=0)
            {
                targetsCount = string.Join(",",targets);
            }

            stringBuilder.AppendLine($" *Targets: {targetsCount}");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
