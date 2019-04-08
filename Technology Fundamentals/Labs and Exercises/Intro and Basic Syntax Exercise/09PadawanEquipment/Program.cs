using System;

namespace _09PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            decimal pricePerSabre = decimal.Parse(Console.ReadLine());
            decimal pricePerRobe = decimal.Parse(Console.ReadLine());
            decimal pricePerBelt = decimal.Parse(Console.ReadLine());

            decimal lightSabersNeeded = Math.Ceiling(studentsCount + studentsCount * 0.1m);
            decimal totalSabersPrice = lightSabersNeeded * pricePerSabre;

            decimal totalRobesPrice = pricePerRobe * studentsCount;

            int freeBelts = studentsCount / 6;
            int totalBeltsToPay = studentsCount - freeBelts;
            decimal totalBeltsPrice = totalBeltsToPay * pricePerBelt;

            decimal totalPrice = totalSabersPrice + totalRobesPrice + totalBeltsPrice;

            if (budget >= totalPrice)
            {
                Console.WriteLine("The money is enough - it would cost {0:f2}lv.", totalPrice);
            }
            else
            {
                Console.WriteLine("Ivan Cho will need {0:f2}lv more.", totalPrice - budget);
            }
        }
    }
}
