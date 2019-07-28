namespace _02VehiclesExtension
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
                double carTankCapacity = double.Parse(parameters[3]);

                Car car = new Car(carFuelQuantity, carFuelConsumption, carTankCapacity);

                return car;
            }
            else if (type == "Truck")
            {
                double truckFuelQuantity = double.Parse(parameters[1]);
                double truckFuelConsumption = double.Parse(parameters[2]);
                double truckTankCapacity = double.Parse(parameters[3]);

                Truck truck = new Truck(truckFuelQuantity, truckFuelConsumption, truckTankCapacity);

                return truck;
            }
            else
            {
                double busFuelQuantity = double.Parse(parameters[1]);
                double busFuelConsumption = double.Parse(parameters[2]);
                double busTankCapacity = double.Parse(parameters[3]);

                Bus bus = new Bus(busFuelQuantity, busFuelConsumption, busTankCapacity);

                return bus;
            }
        }
    }
}
