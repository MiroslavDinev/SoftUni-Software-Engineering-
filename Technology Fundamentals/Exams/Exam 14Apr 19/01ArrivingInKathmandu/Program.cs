using System;

namespace Problem1Again
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Last note")
                {
                    break;
                }

                string name = string.Empty;

                for (int i = 0; i < command.Length; i++)
                {
                    char curr = command[i];

                    if (curr == '=')
                    {
                        break;
                    }
                    else if (char.IsLetterOrDigit(curr) || curr == '!' || curr == '@' || curr == '#' || curr == '$' || curr == '?')
                    {
                        name += curr;
                    }
                    else
                    {
                        name = string.Empty;
                        break;
                    }
                }

                if (name == string.Empty)
                {
                    Console.WriteLine("Nothing found!");
                    continue;
                }

                int length = 0;

                string lenAsString = string.Empty;

                string copyCommand = command;

                int indexOfEquals = copyCommand.IndexOf('=') + 1;
                int indexOfLess = copyCommand.IndexOf('<');

                if (indexOfLess>indexOfEquals)
                {
                    string sub = copyCommand.Substring(indexOfEquals);

                    for (int i = 0; i < sub.Length; i++)
                    {
                        char curr = sub[i];

                        if (char.IsDigit(curr))
                        {
                            lenAsString += curr;
                        }
                        else if (char.IsDigit(curr)==false && curr!='<')
                        {
                            lenAsString = "0";
                            break;
                        }
                        if (curr == '<')
                        {
                            break;
                        }
                    }

                    length = int.Parse(lenAsString);
                }
                else
                {
                    Console.WriteLine("Nothing found!");
                    continue;
                }
                
                if (length ==0)
                {
                    Console.WriteLine("Nothing found!");
                    continue;
                }

                string secondCopy = command;

                int indexOfLessFinal = secondCopy.LastIndexOf('<') + 1;
                string code = secondCopy.Substring(indexOfLessFinal);               

                if (indexOfLessFinal>indexOfEquals)
                {
                    if (length == code.Length)
                    {
                        string editedName = string.Empty;

                        for (int i = 0; i < name.Length; i++)
                        {
                            char curr = name[i];

                            if (char.IsLetterOrDigit(curr))
                            {
                                editedName += curr;
                            }
                        }

                        Console.WriteLine($"Coordinates found! {editedName} -> {code}");
                    }
                    else
                    {
                        Console.WriteLine("Nothing found!");
                        continue;
                    }
                }
            }
        }
    }
}
