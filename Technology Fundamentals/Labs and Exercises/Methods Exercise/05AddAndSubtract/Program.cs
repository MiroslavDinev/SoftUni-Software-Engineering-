using System;

namespace _05AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            int firstResult = Sum(firstNum, secondNum);
            int result = Subtract(firstResult, thirdNum);

            Console.WriteLine(result);
        }

        public static int Sum(int num1, int num2)
        {
            return num1 + num2;
        }

        public static int Subtract(int sum1, int num3)
        {
            return sum1 - num3;
        }
    }
}
