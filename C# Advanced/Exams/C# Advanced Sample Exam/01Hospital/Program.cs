using System;
using System.Linq;
using System.Collections.Generic;

namespace _01Hospital
{
    public class Program
    {
        static void Main(string[] args)
        {
            int maxBedDept = 60;

            Dictionary<string, List<string>> deptPatients = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> doctorPatients = new Dictionary<string, List<string>>();

            while (true)
            {
                string command = Console.ReadLine();

                if(command == "Output")
                {
                    break;
                }

                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string deptName = tokens[0];
                string doctorNames = $"{tokens[1]} {tokens[2]}";
                string patient = tokens[3];

                if(!deptPatients.ContainsKey(deptName))
                {
                    deptPatients.Add(deptName, new List<string>());
                }
                
                if(!doctorPatients.ContainsKey(doctorNames))
                {
                    doctorPatients.Add(doctorNames, new List<string>());
                }

                if(deptPatients[deptName].Count>=maxBedDept)
                {
                    continue;
                }

                deptPatients[deptName].Add(patient);
                doctorPatients[doctorNames].Add(patient);
            }

            while (true)
            {
                string input = Console.ReadLine();

                if(input == "End")
                {
                    break;
                }

                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if(tokens.Length == 1)
                {
                    string deptName = tokens[0];

                    if(deptPatients.ContainsKey(deptName))
                    {
                        foreach (var kvp in deptPatients)
                        {
                            string name = kvp.Key;
                            List<string> patients = kvp.Value;

                            if(name == deptName)
                            {
                                foreach (var patient in patients)
                                {
                                    Console.WriteLine(patient);
                                }
                            }                           
                        }
                    }
                }
                else
                {
                    string secondWord = tokens[1];

                    if(char.IsDigit(secondWord[0]))
                    {
                        string deptName = tokens[0];
                        int roomNum = int.Parse(tokens[1]);

                        if(deptPatients.ContainsKey(deptName))
                        {
                            var filtered = deptPatients[deptName].Skip((roomNum * 3) - 3).Take(3).ToList();

                            foreach (var patient in filtered.OrderBy(x=>x))
                            {
                                Console.WriteLine(patient);
                            }
                        }
                    }
                    else
                    {
                        string docNames = $"{tokens[0]} {tokens[1]}";

                        if(doctorPatients.ContainsKey(docNames))
                        {
                            foreach (var kvp in doctorPatients)
                            {
                                string names = kvp.Key;
                                List<string> patients = kvp.Value;

                                if(names == docNames)
                                {
                                    foreach (var patient in patients.OrderBy(x=>x))
                                    {
                                        Console.WriteLine(patient);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
