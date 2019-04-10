using System;

namespace _08GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            if (type=="int")
            {
                int num1 = int.Parse(Console.ReadLine());
                int num2 = int.Parse(Console.ReadLine());
                int result = GetMax(num1, num2);
                Console.WriteLine(result);
            }
            else if (type=="char")
            {
                char symbol1 = char.Parse(Console.ReadLine());
                char symbol2 = char.Parse(Console.ReadLine());
                char result = GetMax(symbol1, symbol2);
                Console.WriteLine(result);
            }
            else if (type == "string")
            {
                string text1 = Console.ReadLine();
                string text2 = Console.ReadLine();
                string result = GetMax(text1, text2);
                Console.WriteLine(result);
            }
            
        }

        public static int GetMax(int num1, int num2)
        {
            return Math.Max(num1, num2);
        }

        public static char GetMax (char symbol1, char symbol2)
        {
            return (char)Math.Max(symbol1, symbol2);
        }

        public static string GetMax (string text1, string text2)
        {
            int comparison = text1.CompareTo(text2);

            if (comparison==1)
            {
                return text1;
            }
            else if (comparison==-1)
            {
                return text2;
            }
            else
            {
                return text1;
            }
        }
    }
}
