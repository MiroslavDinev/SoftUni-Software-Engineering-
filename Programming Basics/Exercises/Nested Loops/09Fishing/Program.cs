using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09Fishing
{
    class Program
    {
        static void Main(string[] args)
        {
            int limit = int.Parse(Console.ReadLine());

            double moneyToPay = 0;
            double moneyToGet = 0;

            double totalMoneyToGet = 0;
            double totalMoneyToPay = 0;

            int fishCounter = 0;
            

            for (int currFish = 1; currFish <= limit; currFish++)
            {
                string fishName = Console.ReadLine();

                

                if (fishName == "Stop")
                {
                    break;
                }
                fishCounter++;
                double kilos = double.Parse(Console.ReadLine());

                if (currFish %3==0)
                {
                    for (int i = 0; i < fishName.Length; i++)
                    {
                        moneyToGet += fishName[i];
                    }
                    moneyToGet = moneyToGet / kilos;
                    totalMoneyToGet += moneyToGet;
                    moneyToGet = 0;
                }
                else
                {
                    for (int i = 0; i < fishName.Length; i++)
                    {
                        moneyToPay += fishName[i];
                    }
                    moneyToPay = moneyToPay / kilos;
                    totalMoneyToPay += moneyToPay;
                    moneyToPay = 0;
                }

                
            }

            if (fishCounter==limit)
            {
                Console.WriteLine("Lyubo fulfilled the quota!");
            }

            if (totalMoneyToGet>=totalMoneyToPay)
            {
                Console.WriteLine($"Lyubo's profit from {fishCounter} fishes is {totalMoneyToGet-totalMoneyToPay:f2} leva.");
            }
            else
            {
                Console.WriteLine($"Lyubo lost {totalMoneyToPay-totalMoneyToGet:f2} leva today.");
            }
        }
    }
}
