namespace _02VehiclesExtension
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        public double TankCapacity { get; protected set; }
        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }

            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }               
            }
        }

        public double FuelConsumptionPerKm { get; protected set; }

        public abstract string Drive(double distance);

        public abstract void Refuel(double amount);
    }
}
