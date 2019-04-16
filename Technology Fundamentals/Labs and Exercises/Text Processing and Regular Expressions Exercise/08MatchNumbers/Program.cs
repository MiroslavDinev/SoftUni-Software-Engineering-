using System;
using System.Text.RegularExpressions;

namespace _08MatchNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"(^|(?<=\s))-?\d+(\.\d+)?($|(?=\s))";

            string numbersString = Console.ReadLine();

            MatchCollection matchNums = Regex.Matches(numbersString, regex);

            foreach (Match num in matchNums)
            {
                Console.Write(num.Value + " ");
            }
            Console.WriteLine();
        }
    }
}
