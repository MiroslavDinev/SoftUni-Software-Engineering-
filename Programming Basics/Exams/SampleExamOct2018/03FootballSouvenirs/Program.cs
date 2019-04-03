using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSouvenirs
{
    class Program
    {
        static void Main(string[] args)
        {
            string team = Console.ReadLine();
            string souvenirs = Console.ReadLine();
            int numSouvenirs = int.Parse(Console.ReadLine());

            double totalSum = 0.00;

            if (team == "Argentina")
            {
                if (souvenirs == "flags")
                {
                    totalSum = 3.25 * numSouvenirs;
                }
                else if (souvenirs == "caps")
                {
                    totalSum = numSouvenirs * 7.20;
                }
                else if (souvenirs == "posters")
                {
                    totalSum = numSouvenirs * 5.10;
                }
                else if (souvenirs == "stickers")
                {
                    totalSum = numSouvenirs * 1.25;
                }
                else
                {
                    Console.WriteLine("Invalid stock!");
                }
            }
            else if (team == "Brazil")
            {
                if (souvenirs == "flags")
                {
                    totalSum = 4.20 * numSouvenirs;
                }
                else if (souvenirs == "caps")
                {
                    totalSum = numSouvenirs * 8.50;
                }
                else if (souvenirs == "posters")
                {
                    totalSum = numSouvenirs * 5.35;
                }
                else if (souvenirs == "stickers")
                {
                    totalSum = numSouvenirs * 1.20;
                }
                else
                {
                    Console.WriteLine("Invalid stock!");
                }
            }
            else if (team == "Croatia")
            {
                if (souvenirs == "flags")
                {
                    totalSum = 2.75 * numSouvenirs;
                }
                else if (souvenirs == "caps")
                {
                    totalSum = numSouvenirs * 6.90;
                }
                else if (souvenirs == "posters")
                {
                    totalSum = numSouvenirs * 4.95;
                }
                else if (souvenirs == "stickers")
                {
                    totalSum = numSouvenirs * 1.10;
                }
                else
                {
                    Console.WriteLine("Invalid stock!");
                }
            }
            else if (team == "Denmark")
            {
                if (souvenirs == "flags")
                {
                    totalSum = 3.10 * numSouvenirs;
                }
                else if (souvenirs == "caps")
                {
                    totalSum = numSouvenirs * 6.50;
                }
                else if (souvenirs == "posters")
                {
                    totalSum = numSouvenirs * 4.80;
                }
                else if (souvenirs == "stickers")
                {
                    totalSum = numSouvenirs * 0.90;
                }
                else
                {
                    Console.WriteLine("Invalid stock!");
                }
            }
            else

            {
                Console.WriteLine("Invalid country!");
            }
            Console.WriteLine("Pepi bought {0} {1} of {2} for {3:f2} lv.", numSouvenirs, souvenirs, team, totalSum);

        }
    }
}
