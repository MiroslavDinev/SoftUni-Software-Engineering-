using System;

namespace _08Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine().Split();

            string names = $"{firstInput[0]} {firstInput[1]}";
            string address = firstInput[2];
            string town = firstInput[3];

            Threeuple<string, string, string> firstThreeuple = new Threeuple<string, string, string>(names,address,town);

            string[] secondInput = Console.ReadLine().Split();

            string name = secondInput[0];
            int num = int.Parse(secondInput[1]);
            bool isDrunk = secondInput[2] == "drunk" ? true : false;

            Threeuple<string, int, bool> secondThreeuple = new Threeuple<string, int, bool>(name, num, isDrunk);

            string[] thirdInput = Console.ReadLine().Split();

            string lastName = thirdInput[0];
            double balance = double.Parse(thirdInput[1]);
            string bank = thirdInput[2];

            Threeuple<string, double, string> lastThreeuple = new Threeuple<string, double, string>(lastName, balance, bank);

            Console.WriteLine(firstThreeuple);
            Console.WriteLine(secondThreeuple);
            Console.WriteLine(lastThreeuple);
        }
    }
}
