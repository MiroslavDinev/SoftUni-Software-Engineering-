namespace MortalEngines.Entities.Machines
{
    using MortalEngines.Entities.Contracts;
    using System.Text;
    public class Fighter : BaseMachine, IFighter
    {
        private const double InitialHealthPoints = 200;
        public Fighter(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
            this.AggressiveMode = true;
            this.ToggleAggressiveMode();
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if(this.AggressiveMode==false)
            {
                this.AttackPoints -= 50;
                this.DefensePoints += 25;
                this.AggressiveMode = true;
            }
            else
            {
                this.AttackPoints += 50;
                this.DefensePoints -= 25;
                this.AggressiveMode = false;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(base.ToString());

            string mode = "ON";

            if(this.AggressiveMode == true)
            {
                mode = "OFF";
            }

            stringBuilder.AppendLine($" *Aggressive: {mode}");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
