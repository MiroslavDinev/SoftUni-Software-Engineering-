namespace _06FootballTeamGenerator
{
    using System;
    public class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get => this.endurance;

            private set
            {
                ValidateStat(value, nameof(this.Endurance));

                this.endurance = value;
            }
        }
        public int Sprint
        {
            get => this.sprint;

            private set
            {
                ValidateStat(value, nameof(this.Sprint));
                this.sprint = value;
            }
        }
        public int Dribble
        {
            get => this.dribble;

            private set
            {
                ValidateStat(value, nameof(this.Dribble));
                this.dribble = value;
            }
        }
        public int Passing
        {
            get => this.passing;

            private set
            {
                ValidateStat(value, nameof(this.Passing));
                this.passing = value;
            }
        }
        public int Shooting
        {
            get => this.shooting;

            private set
            {
                ValidateStat(value, nameof(this.Shooting));
                this.shooting = value;
            }
        }

        private void ValidateStat(int value,string statName)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{statName} should be between 0 and 100.");
            }
        }

    }
}
