using System;

namespace _01DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            int dayNum = int.Parse(Console.ReadLine());

            int num = dayNum - 1;

            string[] days = new string[7];

            days[0] = "Monday";
            days[1] = "Tuesday";
            days[2] = "Wednesday";
            days[3] = "Thursday";
            days[4] = "Friday";
            days[5] = "Saturday";
            days[6] = "Sunday";

            if (num <0 || num>6)
            {
                Console.WriteLine("Invalid day!");
            }
            else
            {
                Console.WriteLine(days[num]);
            }
        }
    }
}
