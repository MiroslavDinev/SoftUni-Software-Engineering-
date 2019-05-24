using System;
using System.Linq;
using System.Collections.Generic;

namespace _02SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sets = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int firstLen = sets[0];
            int secondLen = sets[1];

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < firstLen; i++)
            {
                int num = int.Parse(Console.ReadLine());

                firstSet.Add(num);
            }

            for (int i = 0; i < secondLen; i++)
            {
                int num = int.Parse(Console.ReadLine());

                secondSet.Add(num);
            }

            HashSet<int> result = new HashSet<int>();

            foreach (var item in firstSet)
            {
                if (secondSet.Contains(item))
                {
                    result.Add(item);
                }
            }

            Console.WriteLine(string.Join(" ",result));
        }
    }
}
