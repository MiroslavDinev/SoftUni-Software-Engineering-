using System;
using System.Linq;
using System.Collections.Generic;

namespace _07AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<string> result = new List<string>();

            string[] initalArr = input.Split(new char[] { '|'});

            for (int i = initalArr.Length - 1; i >= 0; i--)
            {
                string currPart = initalArr[i];
                
                result.Add(currPart);
            }

            string final = string.Join(" ", result.ToArray());

            string[] answer = final.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(string.Join(" ", answer));
        }
    }
}
