using System.Collections.Generic;
using WildFarmEdited.Foods;

namespace WildFarmEdited.Animals.Mammals
{
    public class Mouse : Mammal
    {

        private const double gainWeight = 0.10;
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override string AskFood()
        {
            return "Squeak";
        }

        public override void Eat(Food food)
        {
            base.BaseEat(food, new List<string> { nameof(Fruit), nameof(Vegetable) }, gainWeight);
        }
    }
}
