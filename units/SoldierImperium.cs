using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableGame.Abilities;
using TableGame.Abilities.Passive_abilities;
using TableGame.Fractions;

namespace TableGame.Units
{
    internal class SoldierImperium : Soldier
    {
        public string Icon { get { return "/Resources/enemyTest1.png"; } }

        public SoldierImperium()
        {
            Name = "Imperium Soldier";

            FractionName = "Imperium";

            Abilities = new List<Ability>
            {
                new IncreasedLuck("Lucker"),
            };
        }
        [System.Text.Json.Serialization.JsonConstructor]
        public SoldierImperium(string name, string unitfraction, List<Ability>? abilities)
        {
            Name =name;
            FractionName = unitfraction;
            Abilities = abilities;
        }
    }
}
