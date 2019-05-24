using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _09SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder text = new StringBuilder();

            Stack<string> log = new Stack<string>();
           
            for (int i = 0; i < n; i++)
            {
                string command = Console.ReadLine();

                if (command.Contains(" "))
                {
                    string[] tokens = command.Split(" ");

                    string action = tokens[0];

                    if (action == "1")
                    {
                        string toAdd = tokens[1];
                        log.Push(text.ToString());
                        text.Append(toAdd);
                    }
                    else if (action == "2")
                    {
                        int count = int.Parse(tokens[1]);
                        log.Push(text.ToString());

                        for (int k = 0; k < count; k++)
                        {
                            text = text.Remove(text.Length - 1, 1);
                        }
                    }
                    else if (action == "3")
                    {
                        int index = int.Parse(tokens[1]) -1;

                        if (index>=0 && index<text.Length)
                        {
                            Console.WriteLine(text[index]);
                        }
                    }
                }
                else
                {
                    if (log.Count>0)
                    {
                        string state = log.Pop();
                        text.Clear();
                        text.Append(state);
                    }                  
                }
            }
        }
    }
}
