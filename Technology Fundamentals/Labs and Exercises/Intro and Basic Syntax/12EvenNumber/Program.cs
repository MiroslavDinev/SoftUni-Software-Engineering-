using System;

namespace _12EvenNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            while (Math.Abs(num) % 2 != 0)
            {
                Console.WriteLine("Please write an even number.");
                num = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("The number is: {0}", Math.Abs(num));
        }
    }
}
