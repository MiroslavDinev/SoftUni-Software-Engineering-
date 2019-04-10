using System;
using System.Linq;

namespace _03RoundingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                double originalNum = numbers[i];
                double roundedNum = Math.Round(originalNum, MidpointRounding.AwayFromZero);
                Console.WriteLine($"{originalNum} => {roundedNum}");
            }
        }
    }
}
