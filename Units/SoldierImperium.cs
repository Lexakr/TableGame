using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableGame.Abilities;
using TableGame.Abilities.Passive_abilities;
using TableGame.Abilities.Target_abilities;
using TableGame.Fractions;

namespace TableGame.Units
{
    internal class SoldierImperium : Soldier
    {
        public SoldierImperium()
        {
            Name = "Имперский Пехотинец";

            FractionName = "Империум Человечества";

            Icon = "/Resources/enemyTest1.png";

            Abilities = new List<Ability>
            {
                new PassiveRegeneration(),
                new HealTarget(),
                new Fireball(),
            };
        }
    }
}
