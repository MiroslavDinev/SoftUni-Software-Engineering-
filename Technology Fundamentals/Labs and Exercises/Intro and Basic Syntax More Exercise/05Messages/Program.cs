using System;

namespace _05Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = string.Empty;

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int currNum = int.Parse(Console.ReadLine());
                string numAsString = currNum.ToString();
                int currNumLen = numAsString.Length;

                int mainDigit = currNum % 10;

                int offset = (mainDigit - 2) * 3;

                if (mainDigit == 8 || mainDigit == 9)
                {
                    offset += 1;
                }

                int letterIndex = (offset + currNumLen - 1);

                char symbol = (char)(letterIndex + 97);

                if (symbol < 97)
                {
                    symbol = ' ';
                }
                result += symbol;
            }

            Console.WriteLine(result);
        }
    }
}
