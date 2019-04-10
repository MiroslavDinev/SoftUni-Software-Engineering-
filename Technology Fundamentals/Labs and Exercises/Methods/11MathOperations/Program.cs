using System;

namespace _11MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            string operators = Console.ReadLine();
            double num2 = double.Parse(Console.ReadLine());
            double answer = Calculate(num1, operators, num2);
            Console.WriteLine("{0}",answer);
        }

        public static double Calculate (double number1, string input, double number2)
        {
            double result = 0;

            switch (input)
            {
                case "+": result = number1 + number2; break;
                case "-": result = number1 - number2;  break;
                case "*": result = number1 * number2; break;
                case "/": result = number1 / number2; break;
                
            }

            return result;
        }
    }
}
