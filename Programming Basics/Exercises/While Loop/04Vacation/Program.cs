using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyNeeded = double.Parse(Console.ReadLine());
            double currMoney = double.Parse(Console.ReadLine());

            int spentDaysCounter = 0;
            int daysCounter = 0;

            while (currMoney < moneyNeeded)
            {
                string command = Console.ReadLine();
                double sum = double.Parse(Console.ReadLine());
                daysCounter++;

                if (command == "spend")
                {
                    spentDaysCounter++;
                    if (sum >= currMoney)
                    {
                        currMoney = 0;
                    }
                    else
                    {
                        currMoney -= sum;
                    }
                }
                else if (command == "save")
                {
                    spentDaysCounter = 0;
                    currMoney += sum;
                }
                if (spentDaysCounter==5)
                {
                    Console.WriteLine("You can't save the money.");
                    Console.WriteLine("{0}",daysCounter);
                    return;
                }
            }
            Console.WriteLine("You saved the money for {0} days.",daysCounter);
        }
    }
}
