namespace Heroes
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class HeroRepository
    {
        private List<Hero> data;

        public HeroRepository()
        {
            this.data = new List<Hero>();
        }

        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }

        public void Add(Hero hero)
        {
            this.data.Add(hero);
        }

        public void Remove(string name)
        {
            Hero hero = this.data.FirstOrDefault(x => x.Name == name);
            this.data.Remove(hero);
        }

        public Hero GetHeroWithHighestStrength()
        {
            int bestStat = 0;

            Hero bestHero = null;

            foreach (Hero hero in this.data)
            {
                int heroStat = hero.Item.Strength;

                if(heroStat>bestStat)
                {
                    bestStat = heroStat;
                    bestHero = hero;
                }
            }

            return bestHero;
        }

        public Hero GetHeroWithHighestAbility()
        {
            int bestStat = 0;

            Hero bestHero = null;

            foreach (Hero hero in this.data)
            {
                int heroStat = hero.Item.Ability;

                if (heroStat > bestStat)
                {
                    bestStat = heroStat;
                    bestHero = hero;
                }
            }

            return bestHero;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            int bestStat = 0;

            Hero bestHero = null;

            foreach (Hero hero in this.data)
            {
                int heroStat = hero.Item.Intelligence;

                if (heroStat > bestStat)
                {
                    bestStat = heroStat;
                    bestHero = hero;
                }
            }

            return bestHero;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (Hero hero in this.data)
            {
                result.AppendLine(hero.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
