using System;

namespace _01DataTypeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                bool isInt = int.TryParse(input, out int integer);
                bool isFloat = double.TryParse(input, out double floating);
                bool isChar = char.TryParse(input, out char character);
                bool isBool = bool.TryParse(input, out bool boolean);

                if (isInt)
                {
                    Console.WriteLine("{0} is integer type",input);
                }
                else if (isFloat)
                {
                    Console.WriteLine("{0} is floating point type", input);
                }
                else if (isChar)
                {
                    Console.WriteLine("{0} is character type", input);
                }
                else if (isBool)
                {
                    Console.WriteLine("{0} is boolean type", input);
                }
                else
                {
                    Console.WriteLine("{0} is string type", input);
                }
            }
        }
    }
}
