using System;
using System.Linq;
using System.Collections.Generic;

namespace _01Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string text = Console.ReadLine();

            List<int> currNums = new List<int>();
            List<string> result = new List<string>();
            

            for (int i = 0; i < numbers.Count; i++)
            {
                char toRemove;
                currNums.Add(numbers[i]);
                int index = currNums.Sum();
                int newIndex = i;

                while (index!=0)
                {
                    int lastNum = index % 10;
                    index /= 10;

                    newIndex += lastNum;
                }

                if (newIndex>text.Length-1)
                {
                    newIndex = newIndex % text.Length;
                    toRemove = text.ElementAt(newIndex);
                    result.Add(toRemove.ToString());
                    
                }
                else
                {
                    toRemove = text.ElementAt(newIndex);
                    result.Add(toRemove.ToString());
                    
                }

                currNums.Clear();
            }
            Console.WriteLine(string.Join("",result));
            
        }
    }
}
