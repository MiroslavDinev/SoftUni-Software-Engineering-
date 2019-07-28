namespace WildFarmEdited.Animals
{
    using Foods;
    using System;
    using System.Collections.Generic;

    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public string Name { get; protected set; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }

        public abstract void Eat(Food food);

        protected void BaseEat(Food food, List<string> eatableFoods, double gainValue)
        {
            string foodType = food.GetType().Name;

            if(eatableFoods.Contains(foodType))
            {
                this.Weight += food.Quantity * gainValue;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {foodType}!");
            }
        }

        public abstract string AskFood();

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
