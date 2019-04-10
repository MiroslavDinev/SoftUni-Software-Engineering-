using System;
using System.Linq;

namespace _07MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int sequence = 1;
            int longest = 0;

            int numberInSeq = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                int number = nums[i];
                for (int j = i+1; j < nums.Length; j++)
                {
                    if (number == nums[j])
                    {
                        sequence++;
                        
                    }
                    else
                    {
                        sequence = 1;
                        break;
                    }
                    if (sequence > longest)
                    {
                        longest = sequence;
                        numberInSeq = number;
                    }
                }
                
                sequence = 1;
            }

            int[] longestNums = new int[longest];

            for (int i = 0; i < longestNums.Length; i++)
            {
                longestNums[i] = numberInSeq;
            }

            Console.WriteLine(string.Join(" ",longestNums));
        }
    }
}
