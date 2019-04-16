using System;
using System.Linq;
using System.Collections.Generic;

namespace _04MixedUpLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> firstNums = Console.ReadLine().Split().Select(long.Parse).ToList();
            List<long> secondNums = Console.ReadLine().Split().Select(long.Parse).ToList();

            List<long> result = new List<long>();
            List<long> constraints = new List<long>();
            List<long> final = new List<long>();

            if (firstNums.Count>secondNums.Count)
            {
                for (int i = 0; i < firstNums.Count-2; i++)
                {
                    result.Add(firstNums[i]);
                    result.Add(secondNums[secondNums.Count - i - 1]);
                }

                constraints.Add(firstNums[firstNums.Count - 2]);
                constraints.Add(firstNums[firstNums.Count-1]);

                long maxConstraint = constraints.Max();
                long minConstraint = constraints.Min();

                for (int i = 0; i < result.Count; i++)
                {
                    long currNum = result[i];

                    if (currNum> minConstraint && currNum<maxConstraint)
                    {
                        final.Add(currNum);
                    }
                }
                final.Sort();
                Console.WriteLine(string.Join(" ",final));
            }
            else
            {
                for (int i = 0; i < secondNums.Count-2; i++)
                {
                    result.Add(firstNums[i]);
                    result.Add(secondNums[secondNums.Count-i-1]);
                }

                constraints.Add(secondNums[0]);
                constraints.Add(secondNums[1]);

                long maxConstraint = constraints.Max();
                long minConstraint = constraints.Min();

                for (int i = 0; i < result.Count; i++)
                {
                    long currNum = result[i];

                    if (currNum > minConstraint && currNum < maxConstraint)
                    {
                        final.Add(currNum);
                    }
                }
                final.Sort();
                Console.WriteLine(string.Join(" ", final));
            }
        }
    }
}
