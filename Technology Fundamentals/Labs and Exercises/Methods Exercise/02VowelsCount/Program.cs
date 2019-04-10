using System;

namespace _02VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int result = VowelsCount(input);

            Console.WriteLine(result);

        }

        public static int VowelsCount(string line)
        {
            int counter = 0;

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == 'A' || line[i] == 'a' || line[i] == 'O' || line[i] == 'o' || line[i] == 'U' || line[i] == 'u' || line[i] == 'I' || line[i] == 'i' || line[i] == 'E' || line[i] == 'e')
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
