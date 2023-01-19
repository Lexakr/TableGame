using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableGame.Abilities.Passive_abilities;
using TableGame.Abilities;
using TableGame.Abilities.Target_abilities;

namespace TableGame.Units
{
    internal class SoldierOrks : Soldier
    {
        public override string Name { get; set; } = "Орк Воин";
        public override string FractionName { get; set; } = "Орки";
        public override string Icon { get; set; } = "/Resources/enemyTest3.png";
        public override List<Ability>? Abilities { get; set; } = new()
            {
                new PassiveRegeneration(),
            };
        public override int RangeSkill { get; set; } = 3;
        public override int AttackRadius { get; set; } = 7;
    }
}
