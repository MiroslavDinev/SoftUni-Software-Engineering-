using System;

namespace _10TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int limitNum = int.Parse(Console.ReadLine());

            TopNumbers(limitNum);
        }

        public static void TopNumbers(int num)
        {
            int sum = 0;
            int counter = 0;

            for (int i = 8; i <= num; i++)
            {
                int number = i;

                while (number != 0)
                {
                    int lastNum = number % 10;

                    if (lastNum % 2 != 0)
                    {
                        counter++;
                    }
                    number /= 10;

                    sum += lastNum;

                }

                if (sum % 8 == 0 && counter >= 1)
                {

                    Console.WriteLine(i);

                }
                sum = 0;
                counter = 0;
            }
        }
    }
}
