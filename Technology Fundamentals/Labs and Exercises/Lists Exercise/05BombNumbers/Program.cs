using System;
using System.Linq;
using System.Collections.Generic;

namespace _05BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> bombProps = Console.ReadLine().Split().Select(int.Parse).ToList();

            int bomb = bombProps[0];
            int power = bombProps[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                int currNum = numbers[i];

                if (currNum==bomb)
                {
                    int startIndex = i - power;
                    int endIndex = i + power;

                    if (startIndex<0)
                    {
                        startIndex = 0;
                    }
                    if (endIndex>numbers.Count-1)
                    {
                        endIndex = numbers.Count - 1;
                    }
                    if (startIndex>numbers.Count-1 || endIndex<0)
                    {
                        continue;
                    }

                    numbers.RemoveRange(startIndex, endIndex-startIndex+1);
                    i = startIndex - 1;
                }
            }

            int sum = numbers.Sum();

            Console.WriteLine(sum);
        }
    }
}
