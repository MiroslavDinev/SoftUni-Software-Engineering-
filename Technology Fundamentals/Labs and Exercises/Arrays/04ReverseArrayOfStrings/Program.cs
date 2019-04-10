using System;

namespace _04ReverseArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            //    string[] texts = Console.ReadLine().Split();

            //    Array.Reverse(texts);

            //    Console.WriteLine("{0}", string.Join(" ", texts));

            string[] texts = Console.ReadLine().Split();

            for (int i = 0; i < texts.Length/2; i++)
            {
                string firstText = texts[i];

                int reversedTexts = texts.Length - 1 -i;
                texts[i] = texts[reversedTexts];
                texts[reversedTexts] = firstText;
            }
            Console.WriteLine(string.Join(" ",texts));
        }
    }
}
