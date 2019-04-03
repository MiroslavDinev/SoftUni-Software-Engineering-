using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double change = double.Parse(Console.ReadLine());

            double coins = change * 100;
            int counter = 0;

            while (coins >=200)
            {
                coins -= 200;
                counter++;
            }
            while (coins >= 100)
            {
                coins -= 100;
                counter++;
            }
            while (coins >= 50)
            {
                coins -= 50;
                counter++;
            }
            while (coins >= 20)
            {
                coins -= 20;
                counter++;
            }
            while (coins >= 10)
            {
                coins -= 10;
                counter++;
            }
            while (coins >= 5)
            {
                coins -= 5;
                counter++;
            }
            while (coins >= 2)
            {
                coins -= 2;
                counter++;
            }
            while (coins >= 1)
            {
                coins -= 1;
                counter++;
            }
            Console.WriteLine(counter);

        }
    }
}
