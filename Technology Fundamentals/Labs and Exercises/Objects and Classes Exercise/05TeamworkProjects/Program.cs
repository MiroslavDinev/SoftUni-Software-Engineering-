using System;
using System.Linq;
using System.Collections.Generic;

namespace _05TeamworkProjects
{
    public class Team
    {
        public Team(string name, string creator)
        {
            Name = name;
            Creator = creator;
            Members = new List<string>();
        }

        public string Name { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int teamsToReg = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();
            

            for (int i = 0; i < teamsToReg; i++)
            {
                string[] input = Console.ReadLine().Split("-");
                string creator = input[0];
                string teamName = input[1];

                bool isTeamNameExist = teams.Any(x => x.Name == teamName);
                bool isCreatorOfTeam = teams.Any(x => x.Creator == creator);

                if (isCreatorOfTeam == false && isTeamNameExist==false)
                {
                    Team team = new Team(teamName, creator);
                    teams.Add(team);
                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                }
                else if (isCreatorOfTeam)
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }
                else if (isTeamNameExist)
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end of assignment")
                {
                    break;
                }

                string[] tokens = command.Split("->");
                string member = tokens[0];
                string teamName = tokens[1];

                bool isTeamExisting = teams.Any(x => x.Name == teamName);
                bool isMember = teams.Any(x => x.Members.Contains(member) || x.Creator == member);
    
                if (isTeamExisting==false)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }
                if (isMember)
                {
                    Console.WriteLine($"Member {member} cannot join team {teamName}!");
                    continue;
                }
                if (isTeamExisting == true && isMember == false)
                {
                    int indexOfTeam = teams.FindIndex(x => x.Name == teamName);
                    teams[indexOfTeam].Members.Add(member);
                }
            }

            List<Team> teamsWithMembers = teams
                .Where(x => x.Members.Count > 0)
                .OrderByDescending(x=>x.Members.Count)
                .ThenBy(x=>x.Name).ToList();
            List<Team> teamsWithoutMembers = teams
                .Where(x => x.Members.Count == 0)
                .OrderBy(x=>x.Name).ToList();

            foreach (var currTeam in teamsWithMembers)
            {
                Console.WriteLine(currTeam.Name);
                Console.WriteLine($"- {currTeam.Creator}");
                Console.WriteLine(string.Join(Environment.NewLine,currTeam.Members.Select(x=>$"-- {x}")));
            }

            Console.WriteLine("Teams to disband:");

            foreach (var currTeam in teamsWithoutMembers)
            {
                Console.WriteLine(currTeam.Name);
            }

            // gornoto 83 tova 100 https://pastebin.com/Lq72ymKc
        }
    }
}
