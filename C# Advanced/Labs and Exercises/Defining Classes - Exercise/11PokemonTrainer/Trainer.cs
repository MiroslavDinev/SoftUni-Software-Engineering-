namespace _11PokemonTrainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Trainer
    {
        public string Name { get; set; }

        public int Badges { get; set; }

        public List<Pokemon> Pokemons { get; set; } = new List<Pokemon>();

        public void DecreaseHealth()
        {
            for (int i = 0; i < Pokemons.Count; i++)
            {
                Pokemons[i].Health -= 10;
            }
        }

        public void RemoveDead()
        {
            Pokemons = Pokemons.Where(p => p.Health > 0).ToList();
        }
    }
}
