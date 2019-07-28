using System;
using System.Collections.Generic;
using System.Linq;

namespace _06FootballTeamGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            while (true)
            {
                try
                {

                    string command = Console.ReadLine();

                    if (command == "END")
                    {
                        break;
                    }

                    string[] tokens = command.Split(";");

                    string action = tokens[0];

                    if (action == "Team")
                    {
                        string name = tokens[1];

                        Team team = new Team(name);
                        teams.Add(team);
                    }
                    else if (action == "Add")
                    {
                        string teamName = tokens[1];
                        string playerName = tokens[2];
                        int endurance = int.Parse(tokens[3]);
                        int sprint = int.Parse(tokens[4]);
                        int dribble = int.Parse(tokens[5]);
                        int passing = int.Parse(tokens[6]);
                        int shooting = int.Parse(tokens[7]);

                        Stats stats = new Stats(endurance, sprint, dribble, passing, shooting);
                        Player player = new Player(playerName, stats);                      
                        
                        Team teamToAdd = teams.FirstOrDefault(x => x.Name == teamName);

                        if (teamToAdd != null)
                        {
                            teamToAdd.Add(player);
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                    }
                    else if (action == "Remove")
                    {
                        string teamName = tokens[1];
                        string playerName = tokens[2];

                        Team teamToRemoveFrom = teams.FirstOrDefault(x => x.Name == teamName);

                        if (teamToRemoveFrom != null)
                        {
                            teamToRemoveFrom.Remove(playerName);
                        }
                    }
                    else if (action == "Rating")
                    {
                        string teamName = tokens[1];

                        Team teamToShowRating = teams.FirstOrDefault(x => x.Name == teamName);

                        if (teamToShowRating != null)
                        {
                            Console.WriteLine($"{teamName} - {teamToShowRating.Rating}");
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                    }
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
