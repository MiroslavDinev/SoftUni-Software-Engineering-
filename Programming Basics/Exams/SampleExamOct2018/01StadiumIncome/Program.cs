using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadiumIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            int sectors = int.Parse(Console.ReadLine());
            int capacityStadium = int.Parse(Console.ReadLine());
            double ticketPrice = double.Parse(Console.ReadLine());

            double totalIncome = 0.00;
            double moneyForCharity = 0.00;

            totalIncome = capacityStadium * ticketPrice;
            double totalMoneyForSector = totalIncome / sectors;
            moneyForCharity = (totalIncome - (totalMoneyForSector * 0.75)) / 8;

            Console.WriteLine("Total income - {0:f2} BGN", totalIncome);
            Console.WriteLine("Money for charity - {0:f2} BGN", moneyForCharity);
        }
    }
}
