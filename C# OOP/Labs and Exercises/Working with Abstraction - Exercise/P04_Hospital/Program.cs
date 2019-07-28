using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doctorPatients = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departmentsPatients = new Dictionary<string, List<List<string>>>();

            string command = Console.ReadLine();

            while (command != "Output")
            {
                string[] tokens = command.Split();

                var departament = tokens[0];
                var firstName = tokens[1];
                var lastName = tokens[2];
                var patient = tokens[3];
                var wholeName = firstName + lastName;

                if (!doctorPatients.ContainsKey(firstName + lastName))
                {
                    doctorPatients[wholeName] = new List<string>();
                }
                if (!departmentsPatients.ContainsKey(departament))
                {
                    departmentsPatients[departament] = new List<List<string>>();

                    for (int rooms = 0; rooms < 20; rooms++)
                    {
                        departmentsPatients[departament].Add(new List<string>());
                    }
                }

                bool freeRooms = departmentsPatients[departament].SelectMany(x => x).Count() < 60;

                if (freeRooms)
                {
                    int room = 0;
                    doctorPatients[wholeName].Add(patient);

                    for (int currRoom = 0; currRoom < departmentsPatients[departament].Count; currRoom++)
                    {
                        if (departmentsPatients[departament][currRoom].Count < 3)
                        {
                            room = currRoom;
                            break;
                        }
                    }
                    departmentsPatients[departament][room].Add(patient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandArgs = command.Split();

                if (commandArgs.Length == 1)
                {
                    Console.WriteLine(string.Join("\n", departmentsPatients[commandArgs[0]].Where(x => x.Count > 0).SelectMany(x => x)));
                }
                else if (commandArgs.Length == 2 && int.TryParse(commandArgs[1], out int staq))
                {
                    Console.WriteLine(string.Join("\n", departmentsPatients[commandArgs[0]][staq - 1].OrderBy(x => x)));
                }
                else
                {
                    Console.WriteLine(string.Join("\n", doctorPatients[commandArgs[0] + commandArgs[1]].OrderBy(x => x)));
                }
                command = Console.ReadLine();
            }
        }
    }
}
