using System;
using System.Linq;

namespace _01ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string text = Console.ReadLine();

                if (text == "end")
                {
                    break;
                }

                char[] arr = text.ToCharArray();
                Array.Reverse(arr);
                Console.Write(text + " = ");
                Console.Write(arr);
                Console.WriteLine();
            }
        }
    }
}
