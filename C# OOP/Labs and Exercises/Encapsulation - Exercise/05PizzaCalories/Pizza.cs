namespace _05PizzaCalories
{
    using System;
    using System.Collections.Generic;
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if(value.Length<1 || value.Length>15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public void Add(Topping topping)
        {
            if(this.toppings.Count==10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.toppings.Add(topping);
        }

        public double TotalCalories
        {
            get
            {
                double total = 0;

                foreach (Topping topping in this.toppings)
                {
                    total += topping.CaloriesPerGram;
                }

                return total + this.dough.CaloriesPerGram;
            }           
        }
    }
}
