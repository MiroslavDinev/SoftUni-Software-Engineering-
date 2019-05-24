using System;
using System.Linq;
using System.Collections.Generic;

namespace _01ListyIterator
{
    public class Program
    {
        static void Main(string[] args)
        {
            ListyIterator<string> listyIterator = null;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                string[] tokens = command.Split();

                string action = tokens[0];

                if(action == "Create")
                {
                    
                    listyIterator = new ListyIterator<string>(tokens.Skip(1).ToList());
                }

                else if (action == "Move")
                {
                    Console.WriteLine(listyIterator.Move());
                }
                else if(action == "HasNext")
                {
                    Console.WriteLine(listyIterator.HasNext());
                }
                else if (action == "Print")
                {
                    try
                    {
                        listyIterator.Print();
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
