using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05FanShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int itemsCount = int.Parse(Console.ReadLine());

            double spentMoney = 0;
            int counter = 0;

            for (int i = 1; i <= itemsCount; i++)
            {
                string product = Console.ReadLine();

                counter++;

                if (product == "hoodie")
                {
                    spentMoney += 30.0;
                    
                }
                else if (product == "keychain")
                {
                    spentMoney += 4.00;
                    
                }
                else if (product == "T-shirt")
                {
                    spentMoney += 20.0;
                    
                }
                else if (product == "flag")
                {
                    spentMoney += 15.0;
                    
                }
                else if (product == "sticker")
                {
                    spentMoney += 1.0;
                    
                }

                
            }

            if (budget < spentMoney)
            {
                Console.WriteLine($"Not enough money, you need {Math.Abs(spentMoney - budget)} more lv.");
                
            }

            else
            {

              Console.WriteLine($"You bought {counter} items and left with {Math.Abs(budget - spentMoney)} lv.");
            }

        }
    }
}
