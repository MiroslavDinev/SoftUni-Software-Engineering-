using System;
using System.Numerics;

namespace _02CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split();
            string word1 = tokens[0];
            string word2 = tokens[1];

            BigInteger sum = 0;

            if (word1.Length>word2.Length)
            {
                for (int i = 0; i < word2.Length; i++)
                {
                    sum += word1[i] * word2[i];
                }

                for (int j = word2.Length; j < word1.Length; j++)
                {
                    sum += word1[j];
                }
            }

            else if (word1.Length < word2.Length)
            {
                for (int i = 0; i < word1.Length; i++)
                {
                    sum += word1[i] * word2[i];
                }

                for (int j = word1.Length; j < word2.Length; j++)
                {
                    sum += word2[j];
                }
            }
            else
            {
                for (int i = 0; i < word1.Length; i++)
                {
                    sum += word1[i] * word2[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
