using System;

namespace _04PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool passwordLength = PassLength(password);

            if (passwordLength == false)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            bool passwordLettersAndDigits = IsLettersAndDigitsOnly(password);

            if (passwordLettersAndDigits == false)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            bool atLeast2Digits = Contains2Digits(password);

            if (atLeast2Digits == false)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (passwordLength && passwordLettersAndDigits && atLeast2Digits)
            {
                Console.WriteLine("Password is valid");
            }


        }

        public static bool PassLength(string pass)
        {
            return pass.Length >= 6 && pass.Length <= 10 ? true : false;
        }

        public static bool IsLettersAndDigitsOnly(string pass)
        {
            for (int i = 0; i < pass.Length; i++)
            {
                char symbol = pass[i];

                if (!(char.IsLetterOrDigit(symbol)))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool Contains2Digits(string pass)
        {
            int counter = 0;

            for (int i = 0; i < pass.Length; i++)
            {
                char symbol = pass[i];

                if (char.IsDigit(symbol))
                {
                    counter++;
                }
            }

            if (counter >= 2)
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
