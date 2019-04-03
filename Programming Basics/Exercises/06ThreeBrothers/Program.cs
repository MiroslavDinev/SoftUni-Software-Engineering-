using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06ThreeBrothers
{
    class Program
    {
        static void Main(string[] args)
        {
            double bigBrother = double.Parse(Console.ReadLine());
            double midBrother = double.Parse(Console.ReadLine());
            double smallBrother = double.Parse(Console.ReadLine());
            double fatherTime = double.Parse(Console.ReadLine());

            double threeTime = 1 / (1 / bigBrother + 1 / midBrother + 1 / smallBrother);
            double totalTime = threeTime + (threeTime * 0.15);

            double timeLeft =fatherTime - totalTime;

            if (timeLeft >0)
            {
                Console.WriteLine("Cleaning time: {0:f2}",totalTime);
                Console.WriteLine("Yes, there is a surprise - time left -> {0} hours.",Math.Floor(timeLeft));
            }
            else
            {
                Console.WriteLine("Cleaning time: {0:f2}", totalTime);
                timeLeft = Math.Abs(timeLeft);   
                Console.WriteLine("No, there isn't a surprise - shortage of time -> {0} hours.",Math.Ceiling(timeLeft));
            }
            
        }
    }
}
