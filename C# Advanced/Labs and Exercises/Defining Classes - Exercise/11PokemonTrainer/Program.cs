using System;
using System.Linq;
using System.Collections.Generic;

namespace _11PokemonTrainer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Tournament")
                {
                    break;
                }

                string[] tokens = command.Split();
                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (trainers.Any(t=>t.Name==trainerName))
                {
                    Trainer trainerInList = trainers.Where(t => t.Name == trainerName).FirstOrDefault();

                    int index = trainers.IndexOf(trainerInList);

                    trainers[index].Pokemons.Add(pokemon);
                }
                else
                {
                    Trainer trainer = new Trainer();

                    trainer.Name = trainerName;
                    trainer.Pokemons.Add(pokemon);

                    trainers.Add(trainer);
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                if (command == "Fire")
                {
                    for (int i=0; i<trainers.Count; i++)
                    {
                        Trainer trainer = trainers[i];

                        if (trainer.Pokemons.Any(x=>x.Element=="Fire"))
                        {
                            trainer.Badges += 1;
                        }
                        else
                        {
                            trainer.DecreaseHealth();
                            trainer.RemoveDead();
                        }
                    }
                }
                else if (command == "Water")
                {
                    for (int i = 0; i < trainers.Count; i++)
                    {
                        Trainer trainer = trainers[i];

                        if (trainer.Pokemons.Any(x => x.Element == "Water"))
                        {
                            trainer.Badges += 1;
                        }
                        else
                        {
                            trainer.DecreaseHealth();
                            trainer.RemoveDead();
                        }
                    }
                }
                else if (command == "Electricity")
                {
                    for (int i = 0; i < trainers.Count; i++)
                    {
                        Trainer trainer = trainers[i];

                        if (trainer.Pokemons.Any(x => x.Element == "Electricity"))
                        {
                            trainer.Badges += 1;
                        }
                        else
                        {
                            trainer.DecreaseHealth();
                            trainer.RemoveDead();
                        }
                    }
                }
            }

            foreach (Trainer trainer in trainers.OrderByDescending(x=>x.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count()}");
            }
        }
    }
}
