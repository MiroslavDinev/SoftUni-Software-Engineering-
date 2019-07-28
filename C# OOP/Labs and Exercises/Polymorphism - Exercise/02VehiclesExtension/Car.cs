namespace _02VehiclesExtension
{
    using System;
    public class Car : Vehicle
    {
        private const double airConditionerConsumption = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumption + airConditionerConsumption;
        }
        public override string Drive(double distance)
        {
            double fuelUsed = distance * this.FuelConsumptionPerKm;

            if (fuelUsed <= this.FuelQuantity)
            {
                this.FuelQuantity -= fuelUsed;
                return $"{this.GetType().Name} travelled {distance} km";
            }
            else
            {
                return $"{this.GetType().Name} needs refueling";
            }
        }

        public override void Refuel(double amount)
        {
            if(amount<=0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if(amount + this.FuelQuantity > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
            }

            this.FuelQuantity += amount;
        }

        public override string ToString()
        {
            return $"Car: {this.FuelQuantity:f2}";
        }
    }
}
