using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03EmojiSumator
{
    class Program
    {
        static void Main(string[] args)
        {
            string msg = Console.ReadLine();
            int[] codeTokens = Console.ReadLine().Split(':').Select(int.Parse).ToArray();

            List<string> emojis = new List<string>();


            string emojiCode = string.Empty;

            for (int i = 0; i < codeTokens.Length; i++)
            {
                int currNum = codeTokens[i];
                char toAdd = (char)currNum;
                emojiCode += toAdd;
            }

            if (emojiCode != string.Empty)
            {
                emojiCode = emojiCode.Insert(0, ":");
                emojiCode += ":";
            }

            string pattern = @"(?<=\s):[a-z]{4,}:(?=\s|,|\.|!|\?)";

            if (Regex.IsMatch(msg, pattern))
            {
                MatchCollection matches = Regex.Matches(msg, pattern);

                foreach (Match match in matches)
                {
                    emojis.Add(match.Value);
                }
            }

            int totalPower = 0;

            foreach (string emoji in emojis)
            {
                for (int i = 0; i < emoji.Length; i++)
                {
                    char curr = emoji[i];
                    if (char.IsLower(curr))
                    {
                        int asNum = (int)curr;
                        totalPower += asNum;
                    }
                }
            }

            foreach (string emoji in emojis)
            {
                if (emoji == emojiCode)
                {
                    totalPower *= 2;
                }
            }

            if (emojis.Count != 0)
            {
                Console.WriteLine("Emojis found: " + string.Join(", ", emojis));
            }

            Console.WriteLine("Total Emoji Power: {0}", totalPower);
        }
    }
}
