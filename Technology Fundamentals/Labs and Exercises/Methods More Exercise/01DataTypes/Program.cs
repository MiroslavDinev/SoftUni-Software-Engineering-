using System;

namespace _01DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeData = Console.ReadLine();

            Result(typeData);
        }

        public static void Result (string input)
        {
            if (input == "int")
            {
                int num = int.Parse(Console.ReadLine());
                int result = num * 2;
                Console.WriteLine(result);
            }
            else if (input == "real")
            {
                double num = double.Parse(Console.ReadLine());
                double result = num * 1.5;
                Console.WriteLine("{0:f2}",result);
            }
            else
            {
                string word = Console.ReadLine();
                Console.WriteLine("${0}$",word);
            }
        }
    }
}
