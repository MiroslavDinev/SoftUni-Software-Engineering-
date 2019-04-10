using System;

namespace _06MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            MiddleCharacter(input);
        }

        public static void MiddleCharacter(string line)
        {
            if (line.Length % 2 != 0)
            {
                Console.WriteLine(line[line.Length / 2]);

            }
            else
            {
                Console.WriteLine(line[line.Length / 2 - 1] + "" + line[line.Length / 2]);
            }
        }
    }
}
