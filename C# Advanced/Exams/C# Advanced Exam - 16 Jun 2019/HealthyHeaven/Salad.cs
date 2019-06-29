namespace HealthyHeaven
{
    using System.Collections.Generic;
    using System.Text;

    public class Salad
    {
        private List<Vegetable> products;

        public string Name { get; set; }

        public Salad(string name)
        {
            this.Name = name;
            this.products = new List<Vegetable>();
        }

        public int GetTotalCalories()
        {
            int totalCalories = 0;

            foreach (Vegetable vegetable in this.products)
            {
                totalCalories += vegetable.Calories;
            }

            return totalCalories;
        }

        public int GetProductCount()
        {
            return this.products.Count;
        }

        public void Add(Vegetable product)
        {
            this.products.Add(product);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"* Salad {this.Name} is {this.GetTotalCalories()} calories and have {this.GetProductCount()} products:");

            foreach (Vegetable vegetable in this.products)
            {
                sb.AppendLine(vegetable.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
