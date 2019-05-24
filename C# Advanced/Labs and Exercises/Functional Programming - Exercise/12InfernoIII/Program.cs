using System;
using System.Linq;
using System.Collections.Generic;

namespace _12InfernoIII
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> gems = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            List<string> filters = new List<string>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Forge")
                {
                    break;
                }

                command = command.Replace(" ", "");

                string[] tokens = command.Split(";");

                string action = tokens[0];

                if (action == "Exclude")
                {
                    filters.Add(tokens[1] + " " + tokens[2]);
                }
                else if (action == "Reverse")
                {
                    filters.Remove(tokens[1] + " " + tokens[2]);
                }
            }

            filters.Reverse();  // without it 80/100

            for (int i = 0; i < filters.Count; i++)
            {
                string currFilter = filters[i];

                string[] tokens = currFilter.Split();

                string criteria = tokens[0];

                if (criteria== "SumLeft")
                {
                    int num = int.Parse(tokens[1]);

                    for (int k = 0; k < gems.Count; k++)
                    {
                        int currGem = gems[k];

                        int prevGem = 0;

                        if (k-1>=0 && k-1<gems.Count)
                        {
                            prevGem = gems[k - 1];
                        }

                        int sum = prevGem + currGem;

                        if (sum == num)
                        {
                            gems.Remove(currGem);
                            k--;
                        }
                    }
                }
                else if (criteria == "SumRight")
                {
                    int num = int.Parse(tokens[1]);

                    for (int k = 0; k < gems.Count; k++)
                    {
                        int currGem = gems[k];

                        int nextGem = 0;

                        if (k +1>= 0 && k+1 < gems.Count)
                        {
                            nextGem = gems[k + 1];
                        }

                        int sum = nextGem + currGem;

                        if (sum == num)
                        {
                            gems.Remove(currGem);
                            k--;
                        }
                    }
                }
                else
                {
                    int num = int.Parse(tokens[1]);

                    for (int k = 0; k < gems.Count; k++)
                    {
                        int currGem = gems[k];

                        int nextGem = 0;

                        if (k+1 >= 0 && k +1< gems.Count)
                        {
                            nextGem = gems[k + 1];
                        }

                        int prevGem = 0;

                        if (k-1 >= 0 && k -1< gems.Count)
                        {
                            prevGem = gems[k - 1];
                        }

                        int sum = nextGem + currGem + prevGem;

                        if (sum == num)
                        {
                            gems.Remove(currGem);
                            k--;
                        }
                    }
                }
            }

            if (gems.Any())
            {
                Console.WriteLine(string.Join(" ", gems));
            }  
        }
    }
}
