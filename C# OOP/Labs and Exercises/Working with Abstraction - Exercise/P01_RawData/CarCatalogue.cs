namespace P01_RawData
{
    using System.Collections.Generic;
    public class CarCatalogue
    {
        private List<Car> cars;
        public CarCatalogue()
        {
            this.cars = new List<Car>();
        }

        public void Add (string[] parameters)
        {
            string model = parameters[0];

            int engineSpeed = int.Parse(parameters[1]);
            int enginePower = int.Parse(parameters[2]);

            Engine engine = new Engine(engineSpeed, enginePower);
            
            int cargoWeight = int.Parse(parameters[3]);
            string cargoType = parameters[4];

            Cargo cargo = new Cargo(cargoWeight, cargoType);

            double tire1Pressure = double.Parse(parameters[5]);
            int tire1age = int.Parse(parameters[6]);
            double tire2Pressure = double.Parse(parameters[7]);
            int tire2age = int.Parse(parameters[8]);
            double tire3Pressure = double.Parse(parameters[9]);
            int tire3age = int.Parse(parameters[10]);
            double tire4Pressure = double.Parse(parameters[11]);
            int tire4age = int.Parse(parameters[12]);

            Tire[] tires = new Tire[]
            {
                new Tire(tire1Pressure,tire1age),
                new Tire (tire2Pressure,tire2age),
                new Tire(tire3Pressure,tire3age),
                new Tire (tire4Pressure,tire4age)
            };

            Car car = new Car(model, engine, cargo,tires);

            this.cars.Add(car);
        }

        public List<Car> GetCars()
        {
            return this.cars;
        }
    }
}
