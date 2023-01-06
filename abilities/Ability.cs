using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableGame.Abilities
{
    public abstract class Ability
    {
        public static string Name { get; set; }
        public static string Description { get; set; }

/*        [System.Text.Json.Serialization.JsonConstructor]
        public Ability(string name, string description)
        {
            Name = name;
            Description = description;
        }*/

    }
}
