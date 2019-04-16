using System;
using System.Linq;
using System.Collections.Generic;

namespace _08CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companyAndEmployeeId = new Dictionary<string, List<string>>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                string[] tokens = command.Split(" -> ");

                string company = tokens[0];
                string id = tokens[1];

                if (!companyAndEmployeeId.ContainsKey(company))
                {
                    companyAndEmployeeId.Add(company, new List<string>());
                    companyAndEmployeeId[company].Add(id);
                }
                else
                {
                    if (!companyAndEmployeeId[company].Contains(id))
                    {

                       companyAndEmployeeId[company].Add(id);
                    }
                }
            }

            foreach (var kvp in companyAndEmployeeId.OrderBy(x=>x.Key))
            {
                Console.WriteLine(kvp.Key);

                foreach (var name in kvp.Value)
                {
                    Console.WriteLine($"-- {name}");
                }
            }
        }
    }
}
