using System;
using System.Linq;

namespace _02RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string[] words = text.Split();

            Random rand = new Random();

            string[] randArr = words.OrderBy(x => rand.Next()).ToArray();

            Console.WriteLine(string.Join(Environment.NewLine,randArr));

        }
    }
}
