using System;

namespace _05Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            char[] charArray = username.ToCharArray();
            Array.Reverse(charArray);

            string reversed = new string(charArray);

            string password = string.Empty;
            int counter = 0;

            while (true)
            {
                password = Console.ReadLine();

                if (password == reversed)
                {
                    Console.WriteLine("User {0} logged in.", username);
                    break;
                }

                counter++;

                if (counter <= 3)
                {
                    Console.WriteLine("Incorrect password. Try again.");
                }
                if (counter == 4)
                {
                    Console.WriteLine("User {0} blocked!", username);
                    return;
                }
            }
        }
    }
}
