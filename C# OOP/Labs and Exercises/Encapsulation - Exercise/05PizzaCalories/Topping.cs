namespace _05PizzaCalories
{
    using System;
    using System.Collections.Generic;
    public class Topping
    {
        private const int baseCaloriesPerGram = 2;

        private string type;
        private double weight;
        private Dictionary<string, double> typeModifiers;

        public Topping(string type, double weight)
        {
            this.typeModifiers = new Dictionary<string, double>();
            this.SeedTypes();
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get => this.type;

            private set
            {
                if(!this.typeModifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.type = value;
            }
        }
        public double Weight
        {
            get => this.weight;

            private set
            {
                if(value<1 || value>50)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }

        private void SeedTypes()
        {
            this.typeModifiers.Add("meat", 1.2);
            this.typeModifiers.Add("veggies", 0.8);
            this.typeModifiers.Add("cheese", 1.1);
            this.typeModifiers.Add("sauce", 0.9);
        }

        public double CaloriesPerGram
        {
            get
            {
                return (baseCaloriesPerGram * this.Weight) * this.typeModifiers[this.Type.ToLower()];
            }
        }
    }
}
