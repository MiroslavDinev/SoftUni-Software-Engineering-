namespace _06FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Team
    {
        private List<Player> players;
        private string name;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public double Rating
        {
            get
            {
                double currTeamRating = 0;

                foreach (Player player in this.players)
                {
                    currTeamRating += player.AveragePlayerStats;
                }

                if(this.players.Count!=0)
                {
                    currTeamRating = currTeamRating / this.players.Count;
                }

                return currTeamRating;
            }           
        }

        public void Add(Player player)
        {
            this.players.Add(player);
        }

        public void Remove(string playerName)
        {
            if(!this.players.Any(x=>x.Name==playerName))
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }

            Player toRemove = this.players.FirstOrDefault(x => x.Name == playerName);
            this.players.Remove(toRemove);
        }
    }
}
