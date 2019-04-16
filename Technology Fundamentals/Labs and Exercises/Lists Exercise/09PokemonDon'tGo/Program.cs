using System;
using System.Linq;
using System.Collections.Generic;

namespace _09PokemonDon_tGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> distances = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> removedItems = new List<int>();

            while (distances.Count!=0)
            {
                int index = int.Parse(Console.ReadLine());
                int value;

                if (index<0)
                {
                    index = 0;
                    value = distances[0];
                    int lastElement = distances[distances.Count - 1];
                    distances.RemoveAt(0);
                    distances.Insert(0, lastElement);

                    for (int i = 0; i < distances.Count; i++)
                    {
                        
                        if (distances[i] <= value)
                        {
                            distances[i] += value;
                        }
                        else if (distances[i] > value)
                        {
                            distances[i] -= value;
                        }
                    }
                }
                else if (index>distances.Count-1)
                {
                    index = distances.Count - 1;
                    value = distances[distances.Count - 1];
                    int firstElement = distances[0];
                    distances.RemoveAt(distances.Count - 1);
                    distances.Add(firstElement);

                    for (int i = 0; i < distances.Count; i++)
                    {
                        
                        if (distances[i] <= value)
                        {
                            distances[i] += value;
                        }
                        else if (distances[i] > value)
                        {
                            distances[i] -= value;
                        }
                    }
                }
                else
                {
                    value = distances[index];

                    for (int i = 0; i < distances.Count; i++)
                    {
                        if (i == index)
                        {
                            continue;
                        }

                        if (distances[i] <= value)
                        {
                            distances[i] += value;
                        }
                        else if (distances[i] > value)
                        {
                            distances[i] -= value;
                        }
                    }
                    distances.RemoveAt(index);
                }

                removedItems.Add(value);     
            }

            int sum = removedItems.Sum();
            Console.WriteLine(sum);
        }
    }
}
