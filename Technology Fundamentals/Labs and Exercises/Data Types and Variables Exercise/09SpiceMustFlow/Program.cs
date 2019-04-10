using System;

namespace _09SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startAmount = int.Parse(Console.ReadLine());
            long totalExtracted = 0;
            int days = 0;

            while (startAmount >= 100)
            {
                days++;
                totalExtracted += startAmount - 26;
                startAmount -= 10;
            }

            totalExtracted -= 26;

            Console.WriteLine(days);
            if (days == 0)
            {
                totalExtracted = 0;
            }
            Console.WriteLine(totalExtracted);
        }
    }
}
