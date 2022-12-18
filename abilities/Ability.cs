using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableGame.abilities
{
    internal class Ability
    {
        public string Name { get; set; }

        [System.Text.Json.Serialization.JsonConstructor]
        public Ability(string Name)
        {
            this.Name = Name;
        }

    }
}
