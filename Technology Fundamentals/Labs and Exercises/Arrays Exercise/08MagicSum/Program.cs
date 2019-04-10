using System;
using System.Linq;

namespace _08MagicSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sumNeeded = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbers.Length; i++)
            {
                int firstNum = numbers[i];

                for (int j = i+1; j < numbers.Length; j++)
                {
                    int sum = firstNum + numbers[j];

                    if (sum == sumNeeded)
                    {
                        int[] neededNums = new int[2];
                        neededNums[0] = firstNum;
                        neededNums[1] = numbers[j];
                        Console.WriteLine(string.Join(" ", neededNums));
                        break;
                    }
                }                
            }
        }
    }
}
