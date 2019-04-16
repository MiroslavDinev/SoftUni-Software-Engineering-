using System;

namespace _05DigitsLettersAndOther
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string digits = string.Empty;
            string letters = string.Empty;
            string others = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                char currSymbol = text[i];

                if (char.IsDigit(currSymbol))
                {
                    digits += currSymbol;
                }
                else if (char.IsLetter(currSymbol))
                {
                    letters += currSymbol;
                }
                else
                {
                    others += currSymbol;
                }
            }
            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(others);
        }
    }
}
