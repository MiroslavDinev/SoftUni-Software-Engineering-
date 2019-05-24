using System;

namespace _07Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine().Split();

            string names = $"{firstInput[0]} {firstInput[1]}";
            string address = firstInput[2];

            Tuple<string, string> firstTuple = new Tuple<string, string>(names, address);

            string[] secondInput = Console.ReadLine().Split();
            string name = secondInput[0];
            int liters = int.Parse(secondInput[1]);

            Tuple<string, int> secondTuple = new Tuple<string, int>(name, liters);

            string[] lastInput = Console.ReadLine().Split();

            int firstNum = int.Parse(lastInput[0]);
            double secondNum = double.Parse(lastInput[1]);

            Tuple<int, double> thirdTuple = new Tuple<int, double>(firstNum, secondNum);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
