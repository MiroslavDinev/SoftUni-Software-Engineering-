using System;
using System.Linq;
using System.Collections.Generic;

namespace _03QuestsJournal
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> quests = Console.ReadLine().Split(", ").ToList();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Retire!")
                {
                    break;
                }

                string[] tokens = command.Split(" - ");
                string action = tokens[0];

                if (action == "Start")
                {
                    string quest = tokens[1];
                    
                    if (!quests.Contains(quest))
                    {
                        quests.Add(quest);
                    }
                }
                else if (action == "Complete")
                {
                    string quest = tokens[1];

                    if (quests.Contains(quest))
                    {
                        quests.Remove(quest);
                    }
                }
                else if (action == "Side Quest")
                {
                    string[] splitted = tokens[1].Split(":");
                    string quest = splitted[0];
                    string sideQuest = splitted[1];
                    
                    if (quests.Contains(quest)==true && quests.Contains(sideQuest)==false)
                    {
                        int index = quests.IndexOf(quest);
                        quests.Insert(index + 1, sideQuest);
                    }
                }
                else
                {
                    string quest = tokens[1];

                    if (quests.Contains(quest))
                    {
                        int index = quests.IndexOf(quest);
                        quests.RemoveAt(index);
                        quests.Add(quest);
                    }
                }
            }

            Console.WriteLine(string.Join(", ",quests));
        }
    }
}
