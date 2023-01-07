using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableGame.Abilities.Passive_abilities;
using TableGame.Abilities;

namespace TableGame.Units
{
    internal class SoldierOrks : Soldier
    {
        public SoldierOrks()
        {
            Name = "Орк Воин";

            FractionName = "Орки";

            Icon = "/Resources/enemyTest3.png";

            Abilities = new List<Ability>
            {
                new PassiveRegeneration(),
            };
        }
        [System.Text.Json.Serialization.JsonConstructor]
        public SoldierOrks(string name, string unitfraction, List<Ability>? abilities)
        {
            Name = name;
            FractionName = unitfraction;
            Abilities = abilities;
        }
    }
}
