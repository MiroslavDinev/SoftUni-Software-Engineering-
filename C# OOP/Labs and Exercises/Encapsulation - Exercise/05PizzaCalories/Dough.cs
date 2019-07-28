namespace _05PizzaCalories
{
    using System;
    using System.Collections.Generic;
    public class Dough
    {
        private const int caloriesPerGram = 2;

        private string flourType;
        private string bakingTechnique;
        private double weight;
        private Dictionary<string, double> flourModifiers;
        private Dictionary<string, double> bakeModifiers;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.flourModifiers = new Dictionary<string, double>();
            this.bakeModifiers = new Dictionary<string, double>();
            this.SeedFlour();
            this.SeedBaking();
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;

            private set
            {
                if(!this.flourModifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }
        public string BakingTechnique
        {
            get => this.bakingTechnique;

            private set
            {
                if(!this.bakeModifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }
        public double Weight
        {
            get => this.weight;

            private set
            {
                if(value<1 || value>200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }

        private void SeedFlour()
        {
            this.flourModifiers.Add("white", 1.5);
            this.flourModifiers.Add("wholegrain", 1.0);
        }

        private void SeedBaking()
        {
            this.bakeModifiers.Add("crispy", 0.9);
            this.bakeModifiers.Add("chewy", 1.1);
            this.bakeModifiers.Add("homemade", 1.0);
        }

        public double CaloriesPerGram
        {
            get
            {
                return (this.Weight * caloriesPerGram) * this.flourModifiers[this.FlourType.ToLower()] * this.bakeModifiers[this.BakingTechnique.ToLower()];
            }
        }
    }
}
