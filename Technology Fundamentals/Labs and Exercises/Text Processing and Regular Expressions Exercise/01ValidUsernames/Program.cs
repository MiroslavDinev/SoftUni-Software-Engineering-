using System;
using System.Linq;
using System.Collections.Generic;

namespace _01ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ");

            List<string> result = new List<string>();

            for (int i = 0; i < usernames.Length; i++)
            {
                string currName = usernames[i];

                if (currName.Length<3 || currName.Length>16)
                {
                    continue;
                }

                result.Add(currName);

                for (int j = 0; j < currName.Length; j++)
                {
                    char currSymbol = currName[j];

                    if (char.IsLetterOrDigit(currSymbol)== false && currSymbol!='-' && currSymbol!='_')
                    {
                        result.Remove(currName);
                        break;
                    }
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine,result));
        }
    }
}
