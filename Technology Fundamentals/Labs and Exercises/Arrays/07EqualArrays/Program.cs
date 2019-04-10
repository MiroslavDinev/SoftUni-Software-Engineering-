using System;
using System.Linq;

namespace _07EqualArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secondNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int sum = 0;

            for (int i = 0; i < firstNumbers.Length; i++)
            {
                if (firstNumbers[i] != secondNumbers[i])
                {
                    Console.WriteLine("Arrays are not identical. Found difference at {0} index",i);
                    return;
                }
                else
                {
                    int currNum = firstNumbers[i];
                    sum += currNum;
                }
            }
            Console.WriteLine("Arrays are identical. Sum: {0}",sum);
        }
    }
}
