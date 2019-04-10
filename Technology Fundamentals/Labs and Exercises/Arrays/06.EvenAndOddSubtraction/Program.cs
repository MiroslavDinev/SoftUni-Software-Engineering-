using System;
using System.Linq;

namespace _06.EvenAndOddSubtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int oddSum = 0;
            int evenSum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                int currNum = numbers[i];

                if (currNum%2==0)
                {
                    evenSum += currNum;
                }
                else
                {
                    oddSum += currNum;
                }
            }

            int diff = evenSum - oddSum;
            Console.WriteLine(diff);
        }
    }
}
