using System;

namespace _10RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int headsetsCounter = 0;
            int mousesCounter = 0;
            int keyboardsCounter = 0;
            int dispaysCounter = 0;

            for (int i = 1; i <= lostGames; i++)
            {
                if (i % 2 == 0)
                {
                    headsetsCounter++;
                }
                if (i % 3 == 0)
                {
                    mousesCounter++;
                }
                if (i % 6 == 0)
                {
                    keyboardsCounter++;
                }
                if (i % 12 == 0)
                {
                    dispaysCounter++;
                }
            }
            double headsetsCost = headsetsCounter * headsetPrice;
            double mousesCost = mousesCounter * mousePrice;
            double keyboardsCost = keyboardsCounter * keyboardPrice;
            double displaysCost = dispaysCounter * displayPrice;
            double totalCost = headsetsCost + mousesCost + keyboardsCost + displaysCost;

            Console.WriteLine("Rage expenses: {0:f2} lv.", totalCost);
        }
    
    }
}
