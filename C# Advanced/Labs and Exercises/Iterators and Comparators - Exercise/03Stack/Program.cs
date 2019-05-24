using System;

namespace _03Stack
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();

            while (true)
            {
                string command = Console.ReadLine();

                if(command == "END")
                {
                    break;
                }

                string[] tokens = command.Split(" ",2);
                string action = tokens[0];

                if(action == "Push")
                {
                    string[] itemsToAdd = tokens[1].Split(", ");

                    foreach (var item in itemsToAdd)
                    {
                        stack.Push(item);
                    }
                }
                else
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
