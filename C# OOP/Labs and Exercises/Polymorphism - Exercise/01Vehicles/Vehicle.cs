namespace _01Vehicles
{
    public abstract class Vehicle
    {
        public double FuelQuantity { get; protected set; }

        public double FuelConsumptionPerKm { get; protected set; }

        public abstract string Drive(double distance);

        public abstract void Refuel(double amount);
    }
}
