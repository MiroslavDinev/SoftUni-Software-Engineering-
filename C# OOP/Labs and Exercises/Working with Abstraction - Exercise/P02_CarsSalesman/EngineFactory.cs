namespace P02_CarsSalesman
{
    using System.Collections.Generic;
    public class EngineFactory
    {
        private List<Engine> engines;

        public EngineFactory()
        {
            this.engines = new List<Engine>();
        }

        public void Add(string[] parameters)
        {
            string model = parameters[0];
            int power = int.Parse(parameters[1]);

            int displacement = -1;

            if (parameters.Length == 3 && int.TryParse(parameters[2], out displacement))
            {
                this.engines.Add(new Engine(model, power, displacement));
            }
            else if (parameters.Length == 3)
            {
                string efficiency = parameters[2];
                this.engines.Add(new Engine(model, power, efficiency));
            }
            else if (parameters.Length == 4)
            {
                string efficiency = parameters[3];
                this.engines.Add(new Engine(model, power, int.Parse(parameters[2]), efficiency));
            }
            else
            {
                this.engines.Add(new Engine(model, power));
            }
        }

        public List<Engine> GetEngines()
        {
            return this.engines;
        }
    }
}
