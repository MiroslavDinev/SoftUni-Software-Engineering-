namespace FightingArena
{
    using System.Collections.Generic;
    using System.Linq;

    public class Arena
    {
        private List<Gladiator> gladiators;

        public Arena(string name)
        {
            this.Name = name;
            this.gladiators = new List<Gladiator>();
        }

        public string Name { get; set; }

        public int Count
        {
            get
            {
                return this.gladiators.Count;
            }
        }

        public void Add(Gladiator gladiator)
        {
            this.gladiators.Add(gladiator);
        }

        public void Remove(string name)
        {
            Gladiator gladiator = this.gladiators.FirstOrDefault(x => x.Name == name);
            this.gladiators.Remove(gladiator);
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
            int bestStat = 0;
            Gladiator bestGladiator = null;

            foreach (Gladiator gladiator in this.gladiators)
            {
                if(gladiator.GetStatPower()>bestStat)
                {
                    bestStat = gladiator.GetStatPower();
                    bestGladiator = gladiator;
                }
            }

            return bestGladiator;
        }

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            int bestStat = 0;
            Gladiator bestGladiator = null;

            foreach (Gladiator gladiator in this.gladiators)
            {
                if (gladiator.GetWeaponPower() > bestStat)
                {
                    bestStat = gladiator.GetWeaponPower();
                    bestGladiator = gladiator;
                }
            }

            return bestGladiator;
        }

        public Gladiator GetGladitorWithHighestTotalPower()
        {
            int bestStat = 0;
            Gladiator bestGladiator = null;

            foreach (Gladiator gladiator in this.gladiators)
            {
                if (gladiator.GetTotalPower() > bestStat)
                {
                    bestStat = gladiator.GetTotalPower();
                    bestGladiator = gladiator;
                }
            }

            return bestGladiator;
        }

        public override string ToString()
        {
            return $"[{this.Name}] - [{this.Count}] gladiators are participating.";
        }
    }
}
