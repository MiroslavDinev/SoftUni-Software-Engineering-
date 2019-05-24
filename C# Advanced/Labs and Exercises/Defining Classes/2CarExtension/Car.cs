
using System;
using System.Text;

namespace _2CarExtension
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public void Drive (double distance)
        {
            bool isEnoughFuel = this.FuelQuantity - distance * this.FuelConsumption >= 0;

            if (isEnoughFuel)
            {
                this.FuelQuantity -= distance * this.FuelConsumption;
            }
            else
            {
                throw new InvalidOperationException("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Make: {this.Make}");
            result.AppendLine($"Model: {this.Model}");
            result.AppendLine($"Year: {this.Year}");
            result.AppendLine($"Fuel: {this.FuelQuantity:f2}L");
            return result.ToString();
        }
    }
}
