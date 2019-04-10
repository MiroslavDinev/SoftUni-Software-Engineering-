using System;

namespace _08FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            double result = Factoriel(firstNumber) / Factoriel(secondNumber);

            Console.WriteLine("{0:f2}", result);
        }

        public static double Factoriel(int num1)
        {
            long factoriel = 1;

            for (long i = 2; i <= num1; i++)
            {
                factoriel *= i;
            }
            return factoriel;
        }
    }
}
