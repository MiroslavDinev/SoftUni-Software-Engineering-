using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double timePerM = double.Parse(Console.ReadLine());

            double swimTime = distance * timePerM;
            double slowTime = Math.Floor(distance / 15.0) * 12.5;
            double totalTime = swimTime + slowTime;

            if (totalTime < record)
            {
                Console.WriteLine("Yes, he succeeded! The new world record is {0:f2} seconds.",totalTime);
            }
            else

            {
                double remain = totalTime - record;
                Console.WriteLine("No, he failed! He was {0:f2} seconds slower.",remain);
            }
        }
    }
}
