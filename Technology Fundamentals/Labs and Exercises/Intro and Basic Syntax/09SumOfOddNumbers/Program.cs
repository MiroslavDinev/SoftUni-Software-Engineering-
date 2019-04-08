using System;

namespace _09SumOfOddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int counter = 0;
            long sum = 0;

            for (int i = 1; i < int.MaxValue; i++)
            {
                if (i % 2 != 0)
                {
                    counter++;
                    if (counter > num)
                    {
                        break;
                    }
                    Console.WriteLine(i);
                    sum += i;
                }

            }
            Console.WriteLine("Sum: {0}", sum);
        }
    }
}
