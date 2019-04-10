using System;

namespace _01SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            int firstSmallerNum = SmallerNumber(firstNum, secondNum);
            int result = SmallerNumber(firstSmallerNum, thirdNum);
            Console.WriteLine(result);

        }

        public static int SmallerNumber(int num1, int num2)
        {
            return num1 <= num2 ? num1 : num2;

        }
    
    }
}
