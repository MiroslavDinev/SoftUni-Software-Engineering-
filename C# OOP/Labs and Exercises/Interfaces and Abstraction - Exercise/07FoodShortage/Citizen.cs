namespace _07FoodShortage
{
    public class Citizen : IId,IBuyer
    {
        public Citizen(string name,int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.ID = id;
            this.Birthday = birthday;
            this.Food = 0;
        }

        public string ID  {get; private set;}

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Birthday { get; private set; }

        public int Food { get; private set; }

        public void BuyFood()
        {
             this.Food += 10;
        }
    }
}
