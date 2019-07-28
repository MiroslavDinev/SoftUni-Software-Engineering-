using System;

namespace _4HotelReservation
{
    public class Program
    {
        static void Main(string[] args)
        {

            string[] input = Console.ReadLine().Split();

            decimal pricePerDay = decimal.Parse(input[0]);
            int days = int.Parse(input[1]);
            var season = Enum.Parse<Season>(input[2]);
            var discount = DiscountType.None;

            if(input.Length==4)
            {
                discount = Enum.Parse<DiscountType>(input[3]);
            }
            

            PriceCalculator priceCalculator = new PriceCalculator(pricePerDay, days,season,discount);
            decimal finalResult = priceCalculator.CalculatePrice();
            Console.WriteLine($"{finalResult:f2}");
        }
    }
}
