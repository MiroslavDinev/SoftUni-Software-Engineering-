using System;

namespace _01ChristmasSpirit
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            int totalCost = 0;
            int totalSpirit = 0;

            for (int currDay = 1; currDay <= days; currDay++)
            {
                if (currDay%11==0)
                {
                    quantity += 2;
                }
                if (currDay%2==0)
                {
                    totalCost += quantity * 2;
                    totalSpirit += 5;
                }
                if (currDay%3==0)
                {
                    totalCost += (quantity * 5) + (quantity * 3);
                    totalSpirit += 13;
                }
                if (currDay%5==0)
                {
                    totalCost += quantity * 15;
                    totalSpirit += 17;

                    if (currDay%3==0)
                    {
                        totalSpirit += 30;
                    }
                }
                if (currDay % 10==0)
                {
                    totalSpirit -= 20;
                    totalCost += 5 + 3 + 15;

                    if (currDay == days)
                    {
                        totalSpirit -= 30;
                    }
                }
            }

            Console.WriteLine($"Total cost: {totalCost}");
            Console.WriteLine($"Total spirit: {totalSpirit}");
        }
    }
}
