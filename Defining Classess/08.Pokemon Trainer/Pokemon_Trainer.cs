namespace _08.Pokemon_Trainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Pokemon_Trainer
    {
        public static void Main()
        {
            string line = Console.ReadLine();
            List<Trainer> trainers = new List<Trainer>();
            while (line != "Tournament")
            {
                string[] input = Regex.Split(line.Trim(), @"\s+");
                string trainerName = input[0];
                string pokemonName = input[1];
                string element = input[2];
                int health = int.Parse(input[3]);
                Pokemon pok = new Pokemon(pokemonName, element, health);
                if (trainers.Exists(t => t.name == trainerName))
                {
                    trainers.FirstOrDefault(t => t.name == trainerName).AddPokemnon(pok);
                }
                else
                {
                    Trainer trainer = new Trainer(trainerName);
                    trainer.AddPokemnon(pok);
                    trainers.Add(trainer);
                }
                
                line = Console.ReadLine();
            }

            line = Console.ReadLine();
            while (line != "End")
            {
                string command = line;
                trainers.ForEach(t =>
                {
                    if (t.pokemons.FirstOrDefault(p => p.element == command) != null)
                    {
                        t.badgets++;
                    }
                    else
                    {
                        t.pokemons.ForEach(p => p.health -= 10);
                    }
                });
                trainers.ForEach(t => t.pokemons = t.pokemons.Where(p => p.health > 0).ToList());
                line = Console.ReadLine();
            }

            var sortedTrainers = trainers.OrderByDescending(t => t.badgets).ToList();
            sortedTrainers.ForEach(Console.WriteLine);
        }
    }

    public class Trainer
    {
        public string name;

        public int badgets;

        public List<Pokemon> pokemons;

        public Trainer(string name)
        {
            this.name = name;
            this.badgets = 0;
            this.pokemons = new List<Pokemon>();
        }

        public void AddPokemnon(Pokemon pokemon)
        {
            this.pokemons.Add(pokemon);
        }

        public override string ToString()
        {
            return $"{this.name} {this.badgets} {this.pokemons.Count}";
        }
    }

    public class Pokemon
    {
        //name, an element and health
        public string name;

        public string element;

        public int health;

        public Pokemon(string name, string element, int health)
        {
            this.name = name;
            this.element = element;
            this.health = health;
        }

    }
}
