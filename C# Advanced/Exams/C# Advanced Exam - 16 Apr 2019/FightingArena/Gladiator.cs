namespace FightingArena
{
    using System.Text;
    public class Gladiator
    {
        public string Name { get; set; }

        public Stat Stat { get; set; }

        public Weapon Weapon { get; set; }

        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            this.Name = name;
            this.Stat = stat;
            this.Weapon = weapon;
        }

        public int GetTotalPower()
        {
            int statsSum = this.Stat.Strength + this.Stat.Skills + this.Stat.Intelligence + this.Stat.Flexibility + this.Stat.Agility;
            int weaponSum = this.Weapon.Sharpness + this.Weapon.Size + this.Weapon.Solidity;
            int totalSum = statsSum + weaponSum;
            return totalSum;
        }

        public int GetWeaponPower()
        {
            int weaponSum = this.Weapon.Sharpness + this.Weapon.Size + this.Weapon.Solidity;
            return weaponSum;
        }

        public int GetStatPower()
        {
            int statsSum = this.Stat.Strength + this.Stat.Skills + this.Stat.Intelligence + this.Stat.Flexibility + this.Stat.Agility;
            return statsSum;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"[{this.Name}] - [{this.GetTotalPower()}]");
            result.AppendLine($"  Weapon Power: [{this.GetWeaponPower()}]");
            result.AppendLine($"  Stat Power: [{this.GetStatPower()}]");

            return result.ToString().TrimEnd();
        }
    }
}
