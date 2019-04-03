using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double cpuPrice = double.Parse(Console.ReadLine());
            double gpuPrice = double.Parse(Console.ReadLine());
            double ramUnitPrice = double.Parse(Console.ReadLine());
            int ramUnits = int.Parse(Console.ReadLine());
            double discount = double.Parse(Console.ReadLine());

            double priceGpuAndCpu = cpuPrice + gpuPrice;
            double afterDiscount = priceGpuAndCpu - (priceGpuAndCpu * discount);
            double ramPrice = ramUnitPrice * ramUnits;
            double totalInDollars = afterDiscount + ramPrice;
            double totalInLv = 1.57 * totalInDollars;

            Console.WriteLine("Money needed - {0:f2} leva.",totalInLv);
        }
    }
}
