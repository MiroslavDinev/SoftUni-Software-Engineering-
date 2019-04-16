using System;
using System.Collections.Generic;
using System.Linq;

namespace _03LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();
            SortedDictionary<string, int> junkMaterials = new SortedDictionary<string, int>();

            keyMaterials.Add("shards", 0);
            keyMaterials.Add("fragments", 0);
            keyMaterials.Add("motes", 0);

            while (true)
            {
                string[] input = Console.ReadLine().Split();
                bool hasToBreak = false;

                for (int i = 0; i < input.Length; i += 2)
                {
                    int quantity = int.Parse(input[i]);
                    string material = input[i + 1].ToLower();

                    if (material == "fragments" || material == "shards" || material == "motes")
                    {
                        keyMaterials[material] += quantity;

                        if (keyMaterials[material] >= 250)
                        {
                            keyMaterials[material] -= 250;

                            if (material == "fragments")
                            {
                                Console.WriteLine("Valanyr obtained!");
                                hasToBreak = true;
                                break;
                            }
                            else if (material == "shards")
                            {
                                Console.WriteLine("Shadowmourne obtained!");
                                hasToBreak = true;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Dragonwrath obtained!");
                                hasToBreak = true;
                                break;
                            }

                        }

                    }
                    else
                    {
                        if (!junkMaterials.ContainsKey(material))
                        {
                            junkMaterials[material] = 0;
                        }
                        junkMaterials[material] += quantity;
                    }
                }
                if (hasToBreak)
                {
                    break;
                }

            }
            foreach (var kvp in keyMaterials.OrderByDescending(kvp => kvp.Value).ThenBy(kvp => kvp.Key))
            {
                Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
            }
            foreach (var kvp in junkMaterials)
            {
                Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
            }
        }
    }
}
