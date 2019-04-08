using System;

namespace _06StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int numberCopy = number;
            int sum = 0;

            while (number != 0)
            {
                int lastDigit = number % 10;
                number = number / 10;

                int factoriel = 1;

                for (int i = 1; i <= lastDigit; i++)
                {
                    factoriel *= i;
                }
                sum += factoriel;
            }
            if (sum == numberCopy)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    
    }
}
