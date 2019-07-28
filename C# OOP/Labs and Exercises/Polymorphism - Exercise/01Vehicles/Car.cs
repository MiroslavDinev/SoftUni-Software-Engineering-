namespace _01Vehicles
{
    public class Car : Vehicle
    {
        private const double airConditionerConsumption = 0.9;
        public Car(double fuelQuantity, double fuelConsumption)
        {
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
            this.FuelQuantity += amount;
        }

        public override string ToString()
        {
            return $"Car: {this.FuelQuantity:f2}";
        }
    }
}
