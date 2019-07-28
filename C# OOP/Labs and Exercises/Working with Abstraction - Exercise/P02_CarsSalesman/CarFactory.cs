namespace P02_CarsSalesman
{
    using System.Collections.Generic;
    using System.Linq;

    public class CarFactory
    {
        private List<Car> cars;
        private EngineFactory engines;

        public CarFactory(EngineFactory engineFactory)
        {
            this.cars = new List<Car>();
            this.engines = engineFactory;
        }

        public void Add(string[] parameters)
        {
            string model = parameters[0];
            string engineModel = parameters[1];
            Engine engine = engines.GetEngines().FirstOrDefault(x => x.Model == engineModel);

            int weight = -1;

            if (parameters.Length == 3 && int.TryParse(parameters[2], out weight))
            {
                cars.Add(new Car(model, engine, weight));
            }
            else if (parameters.Length == 3)
            {
                string color = parameters[2];
                cars.Add(new Car(model, engine, color));
            }
            else if (parameters.Length == 4)
            {
                string color = parameters[3];
                cars.Add(new Car(model, engine, int.Parse(parameters[2]), color));
            }
            else
            {
                cars.Add(new Car(model, engine));
            }
        }

        public List<Car> GetCars()
        {
            return this.cars;
        }
    }
}
