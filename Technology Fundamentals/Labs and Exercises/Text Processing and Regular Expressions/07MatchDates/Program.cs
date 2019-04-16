using System;
using System.Text.RegularExpressions;

namespace _07MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"\b(?<Day>\d{2})([\/.-])(?<Month>[A-Z][a-z]{2})\1(?<Year>\d{4})\b";

            string datesStrings = Console.ReadLine();

            MatchCollection dates = Regex.Matches(datesStrings, regex);

            foreach (Match date in dates)
            {
                string day = date.Groups["Day"].Value;
                string month = date.Groups["Month"].Value;
                string year = date.Groups["Year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
