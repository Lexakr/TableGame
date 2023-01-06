using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableGame.Abilities
{
    public class Ability
    {
        public string Name { get; set; }
        public string Description { get; set; }

        [System.Text.Json.Serialization.JsonConstructor]
        public Ability(string name, string description)
        {
            Name = name;
            Description = description;
        }

    }
}
