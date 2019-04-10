using System;

namespace _09PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                bool palindrome = IsPalindrome(command);

                if (palindrome == true)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }

        }

        public static bool IsPalindrome(string line)
        {
            char[] arr = line.ToCharArray();
            Array.Reverse(arr);

            string reversed = new String(arr);


            if (line == reversed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
