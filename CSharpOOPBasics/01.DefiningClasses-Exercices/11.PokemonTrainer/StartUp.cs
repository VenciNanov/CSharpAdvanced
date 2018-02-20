using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        var line = string.Empty;

        var trainers = new Queue<Trainer>();
        var pokemons = new List<Pokemon>();

        while ((line = Console.ReadLine()) != "Tournament")
        {
            var input = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var trainerName = input[0];
            var pokemonName = input[1];
            var element = input[2];
            var health = int.Parse(input[3]);

            var pokemon = new Pokemon(pokemonName, element, health);
            var trainer = trainers.Where(x => x.Name == trainerName).FirstOrDefault();

            if (trainer == null)
            {
                trainer = new Trainer(trainerName);
                trainer.Pokemons.Push(pokemon);
                trainers.Enqueue(trainer);
            }
            else
            {
                trainer.Pokemons.Push(pokemon);
            }
        }

        while ((line = Console.ReadLine()) != "End")
        {
            var element = line;

            foreach (var trainer in trainers)
            {
                if (trainer.Pokemons.Where(x => x.Element == element).FirstOrDefault() == null)
                {
                    foreach (var pokemon in trainer.Pokemons)
                    {
                        pokemon.ReduceHealth();
                    }
                    trainer.ClearPokemons();
                }
                else
                {
                    trainer.AddBadges();
                }
            }
        }

        Console.WriteLine(string.Join(Environment.NewLine, trainers.OrderByDescending(t => t.Badges).Select(t => $"{t.Name} {t.Badges} {t.Pokemons.Count}")));
    }
}
