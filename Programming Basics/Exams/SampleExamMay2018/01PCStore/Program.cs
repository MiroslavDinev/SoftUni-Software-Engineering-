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
            double ramPerUnitPrice = double.Parse(Console.ReadLine());
            int unitsRam = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            double priceGpuAndCpu = cpuPrice + gpuPrice;
            double afterDiscount = priceGpuAndCpu - (priceGpuAndCpu * percent);
            double totalCost = afterDiscount + (ramPerUnitPrice * unitsRam);
            double costInLv = totalCost * 1.57;
            Console.WriteLine("Money needed - {0:f2} leva.",costInLv);
        }
    }
}
