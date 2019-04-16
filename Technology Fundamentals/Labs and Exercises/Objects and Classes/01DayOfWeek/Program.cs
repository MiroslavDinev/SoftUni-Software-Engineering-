using System;
using System.Globalization;

namespace _01DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            string dateAsString = Console.ReadLine();
            DateTime date = DateTime.ParseExact(dateAsString, "d-MM-yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine(date.DayOfWeek);
        }
    }
}
