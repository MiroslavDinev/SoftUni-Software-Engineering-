namespace _01Vehicles
{
    public class VehicleFactory
    {
        public Vehicle Create(string[] parameters)
        {
            string type = parameters[0];

            if(type == "Car")
            {
                double carFuelQuantity = double.Parse(parameters[1]);
                double carFuelConsumption = double.Parse(parameters[2]);

                Car car = new Car(carFuelQuantity, carFuelConsumption);

                return car;
            }
            else if (type == "Truck")
            {
                double truckFuelQuantity = double.Parse(parameters[1]);
                double truckFuelConsumption = double.Parse(parameters[2]);

                Truck truck = new Truck(truckFuelQuantity, truckFuelConsumption);

                return truck;
            }

            return null;
        }
    }
}
