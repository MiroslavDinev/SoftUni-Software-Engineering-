using System;
using System.Collections.Generic;

namespace _02ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToUpper();

            string[] keys = input.Split("&");

            List<string> validKeys = new List<string>();

            for (int i = 0; i < keys.Length; i++)
            {
                string currKey = keys[i];

                if (currKey.Length!=16 && currKey.Length!=25)
                {
                    continue;
                }

                string validKey = string.Empty;

                for (int j = 0; j < currKey.Length; j++)
                {
                    char curr = currKey[j];

                    if (char.IsLetterOrDigit(curr))
                    {
                        validKey += curr;
                    }
                    else
                    {
                        validKey = string.Empty;
                        break;
                    }
                }

                if (validKey!=string.Empty)
                {
                    string keyToAdd = string.Empty;

                    if (validKey.Length==16)
                    {
                        for (int k = 0; k < validKey.Length; k++)
                        {
                            char symbol = validKey[k];

                            if (k%4==0 && k!=0)
                            {
                                keyToAdd += '-';
                            }

                            if (char.IsDigit(symbol))
                            {
                                int symbolAsNum = int.Parse(symbol.ToString());
                                int numToAdd = 9 - symbolAsNum;
                                keyToAdd += numToAdd;
                                continue;
                            }

                            keyToAdd += symbol;
                        }
                    }
                    else
                    {
                        for (int k = 0; k < validKey.Length; k++)
                        {
                            char symbol = validKey[k];

                            if (k % 5 == 0 && k != 0)
                            {
                                keyToAdd += '-';
                            }

                            if (char.IsDigit(symbol))
                            {
                                int symbolAsNum = int.Parse(symbol.ToString());
                                int numToAdd = 9 - symbolAsNum;
                                keyToAdd += numToAdd;
                                continue;
                            }

                            keyToAdd += symbol;
                        }
                    }

                    validKeys.Add(keyToAdd);
                }
            }
            Console.WriteLine(string.Join(", ",validKeys));
        }
    }
}
