using System;

namespace _10RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int times = int.Parse(Console.ReadLine());
            string answer = RepeatedInput(input, times);
            Console.WriteLine(answer);
        }

        public static string RepeatedInput (string line, int times)
        {
            string result = line;

            for (int i = 1; i < times; i++)
            {
                result += line;
            }

            return result;
        }
    }
}
