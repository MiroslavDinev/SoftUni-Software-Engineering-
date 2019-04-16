using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _03TakeSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            string initialMsg = Console.ReadLine();
            List<string> textOnly = new List<string>();
            List<int> numsOnly = new List<int>();

            for (int i = 0; i < initialMsg.Length; i++)
            {
                char currSymbol = initialMsg[i];

                if (char.IsDigit(currSymbol))
                {
                    int currNum = currSymbol-48;
                    numsOnly.Add(currNum);
                }
                else
                {
                    textOnly.Add(currSymbol.ToString());
                }
            }

            List<int> take = new List<int>();
            List<int> skip = new List<int>();

            

            for (int i = 0; i < numsOnly.Count; i++)
            {
                if (i%2==0)
                {
                    take.Add(numsOnly[i]);
                }
                else
                {
                    skip.Add(numsOnly[i]);
                }
            }

            var result = new StringBuilder();
            int skippedCount = 0;

            for (int i = 0; i < take.Count; i++)
            {
                int currSkip = skip[i];
                int currTake = take[i];

                result.Append(string.Concat(textOnly.Skip(skippedCount).Take(currTake)));

                skippedCount += currSkip + currTake;
            }

            Console.WriteLine(result.ToString());
        }
    }
}
