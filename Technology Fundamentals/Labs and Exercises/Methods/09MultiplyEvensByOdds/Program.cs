using System;

namespace _09MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int result = GetMultipleOfEvensAndOdds(Math.Abs(num));
            Console.WriteLine(result);

        }

        public static int GetSumOfEvenDigits (int number)
        {
            int sum = 0;
            while (number>0)
            {
                int lastNum = Math.Abs(number % 10);
                number /= 10;

                if (lastNum%2==0)
                {
                    sum += lastNum;
                }
            }
            return sum;
        }

        public static int GetSumOfOddDigits (int number)
        {
            int sum = 0;

            while (number > 0)
            {
                int lastNum =Math.Abs(number % 10);
                number /= 10;

                if (lastNum % 2 != 0)
                {
                    sum += lastNum;
                }
            }
            return sum;
        }

        public static int GetMultipleOfEvensAndOdds (int number)
        {
            return GetSumOfOddDigits(number) * GetSumOfEvenDigits(number);

        }
    }
}
