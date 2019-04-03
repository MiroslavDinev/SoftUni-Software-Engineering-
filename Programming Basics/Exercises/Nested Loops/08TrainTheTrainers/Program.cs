using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int jury = int.Parse(Console.ReadLine());

            double sum = 0;
            double totalSum = 0;

            int counterPresentations = 0;

            while (true)
            {
                string presentationName = Console.ReadLine();

                if (presentationName == "Finish")
                {
                    break;
                }

                counterPresentations++;
                sum = 0;
                for (int i = 1; i <= jury; i++)
                {
                    
                    double grade = double.Parse(Console.ReadLine());
                    sum += grade;
                }

                Console.WriteLine($"{presentationName} - {sum/jury:f2}.");

                totalSum += sum/jury;
            }
            Console.WriteLine($"Student's final assessment is {totalSum/counterPresentations:f2}.");
        }
    }
}
