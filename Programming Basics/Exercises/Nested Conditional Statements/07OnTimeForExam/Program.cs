using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTimeForExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMin = int.Parse(Console.ReadLine());
            int arrHour = int.Parse(Console.ReadLine());
            int arrMin = int.Parse(Console.ReadLine());

            int examTimeInMin = (examHour * 60) + examMin;
            int arrTimeInMin = (arrHour * 60) + arrMin;
            int difference = arrTimeInMin - examTimeInMin;

            int hours =Math.Abs(difference / 60);
            int min =Math.Abs(difference % 60);

            if (difference <-30) { Console.WriteLine("Early"); }
            else if (difference < 0) { Console.WriteLine("On time"); }
            else if (difference == 0) { Console.WriteLine("On time"); }
            else { Console.WriteLine("Late"); }

            if (hours >0)
            {
                if (min < 10)
                {
                    Console.WriteLine(hours + ":0" + min + "hours");
                }
                else
                {
                    Console.WriteLine(hours + ":" + min + "hours");
                }
            }
            else
            {
                Console.WriteLine(min + "minutes");
            }
            if (difference < 0)
            {
                Console.WriteLine("before the start");
            }
            else
            {
                Console.WriteLine("after the start");
            }
        }
    }
}
