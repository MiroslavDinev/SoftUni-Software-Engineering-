namespace _07SpeedRacing
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Car
    {
        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumption { get; set; }

        public double Distance { get; set; }

        public Car(string model,double fuelAmount,double fuelConsumption)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumption = fuelConsumption;
        }

        public void Drive(double amountOfKm)
        {
            if (amountOfKm*FuelConsumption<=FuelAmount)
            {
                this.FuelAmount -= amountOfKm * FuelConsumption;
                this.Distance += amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:f2} {this.Distance}"; 
        }
    }
}
