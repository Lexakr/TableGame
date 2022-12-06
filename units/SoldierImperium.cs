using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableGame.abilities;
using TableGame.abilities.passive_abilities;
using TableGame.fractions;

namespace TableGame.units
{
    internal class SoldierImperium : Soldier
    {
        public SoldierImperium()
        {
            Name = "Imperium Soldier";
            UnitFraction = new Imperium().Name;
            Abilities = new List<Ability>
            {
                new IncreasedLuck(),
            };

        }
    }
}
