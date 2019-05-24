using System;
using System.Linq;
using System.Collections.Generic;

namespace _06AutoRepairAndService
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Queue<string> vehicles = new Queue<string>(input);

            Stack<string> served = new Stack<string>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }
                else if (command == "Service")
                {
                    if (vehicles.Count>0)
                    {
                        string currVehicle = vehicles.Dequeue();
                        served.Push(currVehicle);
                        Console.WriteLine($"Vehicle {currVehicle} got served.");
                    }
                    
                }
                else if (command == "History")
                {
                    if (served.Count>0)
                    {
                        Console.WriteLine(string.Join(", ",served));
                    }
                }
                else
                {
                    string[] tokens = command.Split("-");
                    string carName = tokens[1];

                    if (vehicles.Contains(carName))
                    {
                        Console.WriteLine("Still waiting for service.");
                    }
                    else
                    {
                        Console.WriteLine("Served.");
                    }
                }              
            }

            if (vehicles.Count>0)
            {
                Console.WriteLine("Vehicles for service: " + string.Join(", ", vehicles));
            }
            
            Console.WriteLine("Served vehicles: " + string.Join(", ",served));
        }
    }
}
