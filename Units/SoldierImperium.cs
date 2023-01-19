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
        public override string Name { get; set; } = "Имперский Пехотинец";
        public override string FractionName { get; set; } = "Империум Человечества";
        public override string Icon { get; set; } = "/Resources/enemyTest1.png";
        public override List<Ability>? Abilities { get; set; } = new()
            {
                new PassiveRegeneration(),
                new HealTarget(),
                new Fireball(),
            };
    }
}
