using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableGame.Abilities
{
    public abstract class Ability
    {
        public abstract string Name { get; }
        public abstract string Description { get; }


/*        [System.Text.Json.Serialization.JsonConstructor]
        public Ability(string name, string description)
        {
            Name = name;
            Description = description;
        }*/

    }
}
