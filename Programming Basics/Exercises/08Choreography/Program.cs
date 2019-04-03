using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08Choreography
{
    class Program
    {
        static void Main(string[] args)
        {
            double steps = double.Parse(Console.ReadLine());
            int dancers = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            double stepsPerDay =(steps / days) / steps;
            double percentDay = Math.Ceiling(stepsPerDay * 100);
            double stepsPerDancer = percentDay / dancers;

            if (percentDay <=13.0)
            {
                Console.WriteLine("Yes, they will succeed in that goal! {0:f2}%.",stepsPerDancer);
            }
            else
            {
                Console.WriteLine("No, They will not succeed in that goal! Required {0:f2}% steps to be learned per day.",stepsPerDancer);
            }
        }
    }
}
