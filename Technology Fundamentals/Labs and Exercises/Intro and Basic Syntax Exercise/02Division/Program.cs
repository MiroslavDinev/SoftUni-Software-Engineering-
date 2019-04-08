using System;

namespace _02Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            if (num % 10 == 0)
            {
                Console.WriteLine("The number is divisible by {0}", 10);
                return;
            }
            else if (num % 7 == 0)
            {
                Console.WriteLine("The number is divisible by {0}", 7);
                return;
            }
            else if (num % 6 == 0)
            {
                Console.WriteLine("The number is divisible by {0}", 6);
                return;
            }
            else if (num % 3 == 0)
            {
                Console.WriteLine("The number is divisible by {0}", 3);
                return;
            }
            else if (num % 2 == 0)
            {
                Console.WriteLine("The number is divisible by {0}", 2);
                return;
            }
            else
            {
                Console.WriteLine("Not divisible");
            }
        }
    }
}
