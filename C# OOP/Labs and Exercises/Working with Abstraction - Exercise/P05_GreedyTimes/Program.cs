using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{
    public class GreedyTimes
    {
        public static void Main(string[] args)
        {
            long bagCapacity = long.Parse(Console.ReadLine());
            string[] quantityPairs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bagItemQuantity = new Dictionary<string, Dictionary<string, long>>();

            long goldAmount = 0;
            long gemAmount = 0;
            long cashAmount = 0;

            for (int currPair = 0; currPair < quantityPairs.Length; currPair += 2)
            {
                string itemName = quantityPairs[currPair];
                long itemCount = long.Parse(quantityPairs[currPair + 1]);

                string itemType = string.Empty;

                if (itemName.Length == 3)
                {
                    itemType = "Cash";
                }
                else if (itemName.ToLower().EndsWith("gem"))
                {
                    itemType = "Gem";
                }
                else if (itemName.ToLower() == "gold")
                {
                    itemType = "Gold";
                }

                if (itemType == "")
                {
                    continue;
                }
                else if (bagCapacity < bagItemQuantity.Values.Select(x => x.Values.Sum()).Sum() + itemCount)
                {
                    continue;
                }

                switch (itemType)
                {
                    case "Gem":
                        if (!bagItemQuantity.ContainsKey(itemType))
                        {
                            if (bagItemQuantity.ContainsKey("Gold"))
                            {
                                if (itemCount > bagItemQuantity["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bagItemQuantity[itemType].Values.Sum() + itemCount > bagItemQuantity["Gold"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                    case "Cash":
                        if (!bagItemQuantity.ContainsKey(itemType))
                        {
                            if (bagItemQuantity.ContainsKey("Gem"))
                            {
                                if (itemCount > bagItemQuantity["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bagItemQuantity[itemType].Values.Sum() + itemCount > bagItemQuantity["Gem"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                }

                if (!bagItemQuantity.ContainsKey(itemType))
                {
                    bagItemQuantity[itemType] = new Dictionary<string, long>();
                }

                if (!bagItemQuantity[itemType].ContainsKey(itemName))
                {
                    bagItemQuantity[itemType][itemName] = 0;
                }

                bagItemQuantity[itemType][itemName] += itemCount;

                if (itemType == "Gold")
                {
                    goldAmount += itemCount;
                }
                else if (itemType == "Gem")
                {
                    gemAmount += itemCount;
                }
                else if (itemType == "Cash")
                {
                    cashAmount += itemCount;
                }
            }

            foreach (var kvp in bagItemQuantity)
            {
                Console.WriteLine($"<{kvp.Key}> ${kvp.Value.Values.Sum()}");

                foreach (var inner in kvp.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{inner.Key} - {inner.Value}");
                }
            }
        }
    }
}