using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace DefiningClasses
{
   public class StartUp
    {
       public static void Main(string[] args)
        {
            HashSet<Trainer> trainers = new HashSet<Trainer>();
            string input;
            while((input = Console.ReadLine()) != "Tournament")
            {
                var trainerArrgs = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string trainerName = trainerArrgs[0];
                string pokemonName = trainerArrgs[1];
                string pokemonElement = trainerArrgs[2];
                int pokemonHealth = int.Parse(trainerArrgs[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                Trainer trainer = new Trainer(trainerName, 0);                

                var existingTrainer = trainers.Where(t => t.Name == trainerName).FirstOrDefault();
                if (trainers.Contains(existingTrainer))
                {
                    existingTrainer.Pokemons.Add(pokemon);
                }
                else
                {
                    trainers.Add(trainer);
                    trainer.Pokemons.Add(pokemon);
                }
            }

            string command;
            while((command = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    var train = trainer.Pokemons.Where(p => p.Element == command).FirstOrDefault();

                    if(train == null)
                    {
                        for (int i = 0; i < trainer.Pokemons.Count; i++)
                        {
                            trainer.Pokemons[i].Health -= 10;

                            if (trainer.Pokemons[i].Health <= 0)
                            {
                                trainer.Pokemons.RemoveAt(i);
                            }
                        }                                                         
                    }
                    else
                    {
                        trainer.NumberOfBadges += 1;
                    }
                }
            }

            Console.WriteLine(String.Join(Environment.NewLine, trainers.OrderByDescending(t => t.NumberOfBadges)));
        }
    }
}
