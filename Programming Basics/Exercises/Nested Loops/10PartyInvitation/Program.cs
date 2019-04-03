using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12PartyInvitation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            int namesCounter = 0;
            int invalidNames = 0;
            int validNames = 0;

            string correctName = string.Empty;

            while (name != "Statistic")
            {
                namesCounter++;

                for (int i = 0; i < name.Length; i++)
                {
                    if ((name[i]>= 'A' && name[i] <= 'Z') || (name[i]>='a' && name[i]<='z'))
                    {
                        correctName = name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();
                        
                    }
                    else
                    {
                        correctName="Invalid name!";
                        invalidNames++;
                        break;
                    }
                }
                Console.WriteLine(correctName);
                name = Console.ReadLine();
                validNames = namesCounter - invalidNames;
            }
            double validPercent = validNames * 100.0 / namesCounter;

            Console.WriteLine($"Valid names are {validPercent:f2}% from {namesCounter} names.");

            double invalidPercent = invalidNames * 100.0 / namesCounter;

            Console.WriteLine($"Invalid names are {invalidPercent:f2}% from {namesCounter} names.");
        }
    }
}
