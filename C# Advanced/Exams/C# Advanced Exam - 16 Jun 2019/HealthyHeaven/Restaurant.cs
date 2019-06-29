namespace HealthyHeaven
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Restaurant
    {
        private List<Salad> data;

        public Restaurant(string name)
        {
            this.Name = name;
            this.data = new List<Salad>();
        }

        public string Name { get; set; }

        public void Add(Salad salad)
        {
            this.data.Add(salad);
        }

        public bool Buy(string name)
        {
            if(this.data.Any(x=>x.Name == name))
            {
                Salad salad = this.data.FirstOrDefault(x => x.Name == name);
                this.data.Remove(salad);
                return true;
            }

            return false;
        }

        public Salad GetHealthiestSalad()
        {
            int leastCallories = int.MaxValue;
            Salad bestSalad = null;

            foreach (Salad salad in this.data)
            {
                if(salad.GetTotalCalories()<leastCallories)
                {
                    leastCallories = salad.GetTotalCalories();
                    bestSalad = salad;
                }
            }

            return bestSalad;
        }

        public string GenerateMenu()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{this.Name} have {this.data.Count} salads:");

            foreach (Salad salad in this.data)
            {
                result.AppendLine(salad.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
