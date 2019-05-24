using System;
using System.Linq;
using System.Collections.Generic;

namespace _04EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numCount = new Dictionary<int, int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (!numCount.ContainsKey(num))
                {
                    numCount.Add(num, 1);
                }
                else
                {
                    numCount[num]++;
                }
            }

            foreach (var kvp in numCount)
            {
                int num = kvp.Key;
                int count = kvp.Value;

                if (count%2==0)
                {
                    Console.WriteLine(num);
                }
            }
        }
    }
}
