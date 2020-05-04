using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace DefiningClasses
{
   public class Trainer
    {
        public Trainer(string name, int badges)
        {
            this.Name = name;
            this.NumberOfBadges = badges;
            this.Pokemons = new List<Pokemon>();
        }

        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> Pokemons { get; }

        public override string ToString()
        {
            return $"{this.Name} {this.NumberOfBadges} {this.Pokemons.Count}";
        }
    }
}
