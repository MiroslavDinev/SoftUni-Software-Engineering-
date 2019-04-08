using System;

namespace _04BackIn30Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int mins = int.Parse(Console.ReadLine());

            int after30 = mins + 30;

            if (after30 >= 60)
            {
                hours++;
                after30 = after30 - 60;
                if (hours > 23)
                {
                    hours = 0;
                }
            }

            Console.WriteLine("{0}:{1:d2}", hours, after30);
        }
    }
}
