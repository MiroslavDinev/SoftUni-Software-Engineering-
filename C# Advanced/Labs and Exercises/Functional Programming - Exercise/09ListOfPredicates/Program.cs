using System;
using System.Linq;
using System.Collections.Generic;

namespace _09ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            List<int> result = new List<int>();

            for (int i = 1; i <= end; i++)
            {
                bool isBroken = false;

                foreach (var num in dividers)
                {
                    if (i%num!=0)
                    {
                        isBroken = true;
                        break;
                    }
                }

                if (isBroken)
                {
                    continue;
                }

                result.Add(i);
            }

            Console.WriteLine(string.Join(" ",result));
        }
    }
}
