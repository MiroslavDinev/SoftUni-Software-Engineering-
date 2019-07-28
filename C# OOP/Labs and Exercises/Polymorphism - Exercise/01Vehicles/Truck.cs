namespace _01Vehicles
{
    public class Truck : Vehicle
    {

        private const double  airConditionerConsumption = 1.6;
        private const double  actualTruckFuel = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption)
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
            this.FuelQuantity += amount * actualTruckFuel;
        }

        public override string ToString()
        {
            return $"Truck: {this.FuelQuantity:f2}"; 
        }
    }
}
