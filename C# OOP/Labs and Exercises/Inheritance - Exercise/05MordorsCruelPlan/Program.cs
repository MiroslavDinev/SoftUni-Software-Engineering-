using _05MordorsCruelPlan.Moods;
using System;
using System.Collections.Generic;

namespace _05MordorsCruelPlan
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Food> foods = new List<Food>();

            string[] tokens = Console.ReadLine().Split();

            foreach (var item in tokens)
            {
                if(item.ToLower()=="cram")
                {
                    foods.Add(new Cram());
                }
                else if (item.ToLower() == "lembas")
                {
                    foods.Add(new Lembas());
                }
                else if (item.ToLower() == "apple")
                {
                    foods.Add(new Apple());
                }
                else if (item.ToLower() == "melon")
                {
                    foods.Add(new Melon());
                }
                else if (item.ToLower() == "mushrooms")
                {
                    foods.Add(new Mushrooms());
                }
                else if (item.ToLower() == "honeycake")
                {
                    foods.Add(new HoneyCake());
                }
                else
                {
                    foods.Add(new Rest());
                }
            }

            int totalPoints = 0;

            foreach (var item in foods)
            {
                totalPoints += item.Points;
            }

            Console.WriteLine(totalPoints);

            if(totalPoints<-5)
            {
                Console.WriteLine(nameof(Angry));
            }
            else if (totalPoints>=-5 && totalPoints<=0)
            {
                Console.WriteLine(nameof(Sad));
            }
            else if (totalPoints>=1 && totalPoints<=15)
            {
                Console.WriteLine(nameof(Happy));
            }
            else if (totalPoints>15)
            {
                Console.WriteLine(nameof(JavaScript));
            }
        }
    }
}
