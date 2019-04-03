using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupStage
{
    class Program
    {
        static void Main(string[] args)
        {
            string team = Console.ReadLine();
            int playedGames = int.Parse(Console.ReadLine());

            int totalPoints = 0;
            int allGoalsScored = 0;
            int allGoalsreceived = 0;

            for (int i = 1; i <= playedGames; i++)
            {
                int scoredGoals = int.Parse(Console.ReadLine());
                int receivedGoals = int.Parse(Console.ReadLine());

                if (scoredGoals > receivedGoals)
                {
                    totalPoints += 3;
                    allGoalsScored += scoredGoals;
                    allGoalsreceived += receivedGoals;

                }
                else if (scoredGoals == receivedGoals)
                {
                    totalPoints += 1;
                    allGoalsScored += scoredGoals;
                    allGoalsreceived += receivedGoals;
                }
                else if (scoredGoals < receivedGoals)
                {
                    allGoalsScored += scoredGoals;
                    allGoalsreceived += receivedGoals;
                }
            }
            if (allGoalsScored >= allGoalsreceived)
            {
                int goalDifference = allGoalsScored - allGoalsreceived;
                Console.WriteLine("{0} has finished the group phase with {1} points.", team, totalPoints);
                Console.WriteLine("Goal difference: {0}.", goalDifference);
            }
            else
            {
                int goalDifference = allGoalsScored - allGoalsreceived;
                Console.WriteLine("{0} has been eliminated from the group phase.", team);
                Console.WriteLine("Goal difference: {0}.", goalDifference);
            }
        }
    }
}
