namespace WildFarmEdited.Animals.Mammals.Felines
{
    using System.Collections.Generic;
    using WildFarmEdited.Foods;
    public class Tiger : Feline
    {

        private const double gainWeight = 1.00;
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string AskFood()
        {
            return "ROAR!!!";
        }

        public override void Eat(Food food)
        {
            base.BaseEat(food, new List<string> { nameof(Meat) }, gainWeight);
        }
    }
}
