using System;

namespace _02Deciphering
{
    class Program
    {
        static void Main(string[] args)
        {
            string encrypted = Console.ReadLine();
            string subs = Console.ReadLine();

            foreach (char symbol in encrypted)
            {
                if (symbol !='#' && symbol<'d' || symbol>'}')
                {
                    Console.WriteLine("This is not the book you are looking for.");
                    return;
                }
            }

            string decoded = string.Empty;

            for (int i = 0; i < encrypted.Length; i++)
            {
                char curr = encrypted[i];
                int currAsNum = (int)curr;
                currAsNum -= 3;
                char toAdd = (char)currAsNum;
                decoded += toAdd;
            }

            string[] tokens = subs.Split();
            string first = tokens[0];
            string second = tokens[1];

            string result = decoded.Replace(first, second);
            Console.WriteLine(result);
        }
    }
}
