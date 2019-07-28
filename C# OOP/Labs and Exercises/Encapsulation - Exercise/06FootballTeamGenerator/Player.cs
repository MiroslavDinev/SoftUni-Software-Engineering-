namespace _06FootballTeamGenerator
{
    using System;
    using System.Linq;
    public class Player
    {
        private string name;
        private Stats stats;

        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.stats = stats;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public double AveragePlayerStats
        {
            get
            {
                double currAvg = 0;

                currAvg = this.stats.Endurance + this.stats.Dribble + this.stats.Passing + this.stats.Shooting + this.stats.Sprint;

                currAvg = Math.Round(currAvg / 5.0);
                return (int)currAvg;
            }
            
        }
    }
}
