using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04MetricConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            string output = Console.ReadLine();

            double m = 1.0;
            double mm = 1000.0;
            double cm = 100.0;
            double mi = 0.000621371192;
            double inch = 39.3700787;
            double km = 0.001;
            double ft = 3.2808399;
            double yd = 1.0936133;

            switch (input)
            {
                case "m": num = num / m; break;
                case "mm": num = num / mm; break;
                case "cm": num = num / cm; break;
                case "mi": num = num / mi; break;
                case "inch": num = num / inch; break;
                case "km": num = num / km; break;
                case "ft": num = num / ft; break;
                case "yd": num = num / yd; break;
                default: break;


            }
            switch (output)
            {
                case "m": break;
                case "mm": num =num * mm; break;
                case "cm": num = num * cm; break;
                case "mi": num = num * mi; break;
                case "inch": num = num * inch; break;
                case "km": num = num * km; break;
                case "ft": num = num * ft; break;
                case "yd": num = num * yd; break;
                default: break;


            }
            Console.WriteLine($"{num:f8}");               // https://pastebin.com/qajJV9N9
                                                          // https://pastebin.com/F6xQ7QXV
        }
    }
}
