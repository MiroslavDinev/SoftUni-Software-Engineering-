using _08MilitaryElite.Models;
using _08MilitaryElite.Models.Privates;
using _08MilitaryElite.Models.Privates.SpecialisedSoldiers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _08MilitaryElite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Soldier> soldiers = new List<Soldier>();

            while (true)
            {
                string command = Console.ReadLine();

                if(command == "End")
                {
                    break;
                }

                string[] tokens = command.Split();

                string soldierType = tokens[0];

                if(soldierType == "Private")
                {
                    string id = tokens[1];
                    string firstName = tokens[2];
                    string lastName = tokens[3];
                    decimal salary = decimal.Parse(tokens[4]);

                    Private @private = new Private(id, firstName, lastName, salary);

                    soldiers.Add(@private);
                }
                else if (soldierType== "LieutenantGeneral")
                {
                    string id = tokens[1];
                    string firstName = tokens[2];
                    string lastName = tokens[3];
                    decimal salary = decimal.Parse(tokens[4]);
                    List<string> privateIds = tokens.Skip(5).ToList();
                    List<Private> privates = GetPrivates(privateIds, soldiers);

                    LieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary, privates);

                    soldiers.Add(lieutenantGeneral);
                }
                else if (soldierType== "Engineer")
                {
                    string id = tokens[1];
                    string firstName = tokens[2];
                    string lastName = tokens[3];
                    decimal salary = decimal.Parse(tokens[4]);
                    string corps = tokens[5];
                    List<string> repairsList = tokens.Skip(6).ToList();
                    List<Repair> repairs = new List<Repair>();

                    for (int i = 0; i < repairsList.Count; i+=2)
                    {
                        string partName = repairsList[i];
                        int hoursNeeded = int.Parse(repairsList[i + 1]);

                        Repair repair = new Repair(partName, hoursNeeded);

                        repairs.Add(repair);
                    }

                    try
                    {
                        Engineer engineer = new Engineer(id, firstName, lastName, salary, corps, repairs);
                        soldiers.Add(engineer);
                    }
                    catch (Exception)
                    {
                    }

                }
                else if (soldierType == "Commando")
                {
                    string id = tokens[1];
                    string firstName = tokens[2];
                    string lastName = tokens[3];
                    decimal salary = decimal.Parse(tokens[4]);
                    string corps = tokens[5];
                    List<string> missionsList = tokens.Skip(6).ToList();
                    List<Mission> missions = new List<Mission>();

                    for (int i = 0; i < missionsList.Count; i+=2)
                    {
                        string codeName = missionsList[i];
                        string state = missionsList[i + 1];

                        try
                        {
                            Mission mission = new Mission(codeName, state);
                            missions.Add(mission);
                        }
                        catch (Exception)
                        {
                        }
                    }

                    try
                    {
                        Commando commando = new Commando(id, firstName, lastName, salary, corps, missions);
                        soldiers.Add(commando);
                    }
                    catch (Exception)
                    {
                    }
                }
                else if (soldierType == "Spy")
                {
                    string id = tokens[1];
                    string firstName = tokens[2];
                    string lastName = tokens[3];
                    int codeNumber = int.Parse(tokens[4]);

                    Spy spy = new Spy(id, firstName, lastName, codeNumber);
                    soldiers.Add(spy);
                }
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }

        private static List<Private> GetPrivates(List<string> privateIds, List<Soldier> soldiers)
        {
            List<Private> privates = new List<Private>();           

            foreach (var privateSoldier in privateIds)
            {
                if(soldiers.Select(x=>x.Id).Contains(privateSoldier))
                {
                    Private @private = (Private)soldiers.FirstOrDefault(x => x.Id == privateSoldier);
                    privates.Add(@private);
                }
            }

            return privates;
        }
    }
}
