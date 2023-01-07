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
        public SoldierImperium()
        {
            Name = "Imperium Soldier";

            FractionName = "Imperium";

            Icon = "/Resources/enemyTest1.png";

            Abilities = new List<Ability>
            {
                new PassiveRegeneration(),
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
