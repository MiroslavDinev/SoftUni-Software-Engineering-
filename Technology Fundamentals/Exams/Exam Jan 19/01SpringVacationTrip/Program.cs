using System;

namespace _01SpringVacationTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int persons = int.Parse(Console.ReadLine());
            double fuelPerKm = double.Parse(Console.ReadLine());
            double foodPerPersonPerDay = double.Parse(Console.ReadLine());
            double pricePerRoomPerNightPerPerson = double.Parse(Console.ReadLine());

            double currExpenses = 0.0;

            double totalHotelExpenses = days * persons * pricePerRoomPerNightPerPerson;

            if (persons>10)
            {
                totalHotelExpenses *= 0.75;
            }

            currExpenses += totalHotelExpenses;

            if (currExpenses > budget)
            {
                Console.WriteLine($"Not enough money to continue the trip. You need {currExpenses - budget:f2}$ more.");
                return;
            }
            double totalFoodExpenses = days * persons * foodPerPersonPerDay;
            currExpenses += totalFoodExpenses;
            if (currExpenses > budget)
            {
                Console.WriteLine($"Not enough money to continue the trip. You need {currExpenses - budget:f2}$ more.");
                return;
            }


            for (int currDay = 1; currDay <= days; currDay++)
            {
                double travelledKmPerDay = double.Parse(Console.ReadLine());

                double expensesForDailyTravel = travelledKmPerDay * fuelPerKm;

                currExpenses += expensesForDailyTravel;

                if (currExpenses> budget)
                {
                    
                    Console.WriteLine($"Not enough money to continue the trip. You need {currExpenses-budget:f2}$ more.");
                    return;
                }

                if (currDay%3==0 || currDay%5==0)
                {
                    currExpenses += 0.4 * currExpenses;
                }

                if (currExpenses > budget)
                {
                    
                    Console.WriteLine($"Not enough money to continue the trip. You need {currExpenses - budget:f2}$ more.");
                    return;
                }

                if (currDay%7==0)
                {
                    if (currExpenses==0)
                    {
                        continue;
                    }
                    double moneyReceived = currExpenses / persons;
                    currExpenses -= moneyReceived;
                }
            }

            Console.WriteLine($"You have reached the destination. You have {budget-currExpenses:f2}$ budget left.");
        }
    }
}
