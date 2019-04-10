using System;

namespace _03CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());

            CharsBetween(first, second);
        }

        public static void CharsBetween(char one, char two)
        {
            if (one > two)
            {
                for (int i = (int)two + 1; i < (int)one; i++)
                {
                    Console.Write((char)i + " ");
                }
            }
            else
            {

                for (int i = (int)one + 1; i < (int)two; i++)
                {
                    Console.Write((char)i + " ");
                }
            }
        }
    }
}
