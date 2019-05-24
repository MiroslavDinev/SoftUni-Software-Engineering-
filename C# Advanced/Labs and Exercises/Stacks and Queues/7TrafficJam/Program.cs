using System;
using System.Collections.Generic;

namespace _7TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int numToPass = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            int counter = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }
                else if (command == "green")
                {
                    if (numToPass<=cars.Count)
                    {
                        for (int i = 0; i < numToPass; i++)
                        {
                            counter++;
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                        }
                    }
                    else
                    {
                        int max = cars.Count;

                        for (int i = 0; i < max; i++)
                        {
                            counter++;
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                        }
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }
            }

            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
