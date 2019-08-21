namespace MortalEngines.Entities.Machines
{
    using MortalEngines.Entities.Contracts;
    using System.Text;
    public class Tank : BaseMachine, ITank
    {
        private const double InitialHealthPoints = 100;
        public Tank(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
            this.DefenseMode = true;
            this.ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if(this.DefenseMode==false)
            {
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
                this.DefenseMode = true;
            }
            else
            {
                this.AttackPoints -= 40;
                this.DefensePoints += 30;
                this.DefenseMode = false;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(base.ToString());

            string mode = "ON";

            if(this.DefenseMode==true)
            {
                mode = "OFF";
            }

            stringBuilder.AppendLine($" *Defense: {mode}");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
