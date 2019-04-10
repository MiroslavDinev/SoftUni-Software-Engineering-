using System;

namespace _12RefactorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());



            for (int i = 1; i <= num; i++)
            {
                bool isValid = false;
                int currNum = i;
                int sum = 0;
                while (currNum > 0)
                {
                    sum += currNum % 10;
                    currNum = currNum / 10;
                }
                if (sum == 5 || sum == 7 || sum == 11)
                {
                    isValid = true;

                }
                if (isValid)
                {
                    Console.WriteLine("{0} -> {1}", i, isValid);
                }
                else
                {
                    Console.WriteLine("{0} -> {1}", i, isValid);
                }
            }
        }
    }
}
