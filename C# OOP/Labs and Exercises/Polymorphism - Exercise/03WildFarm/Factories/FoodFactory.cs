namespace WildFarmEdited.Factories
{
    using WildFarmEdited.Foods;
    public static class FoodFactory
    {
        public static Food Create(string[] foodArgs)
        {
            string foodType = foodArgs[0];
            int quantity = int.Parse(foodArgs[1]);

            if(foodType == "Fruit")
            {
                Fruit fruit = new Fruit(quantity);
                return fruit;
            }
            else if (foodType == "Meat")
            {
                Meat meat = new Meat(quantity);
                return meat;
            }
            else if (foodType == "Seeds")
            {
                Seeds seeds = new Seeds(quantity);
                return seeds;
            }
            else if (foodType == "Vegetable")
            {
                Vegetable vegetable = new Vegetable(quantity);
                return vegetable;
            }

            return null;
        }
    }
}
