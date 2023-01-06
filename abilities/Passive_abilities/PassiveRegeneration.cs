using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableGame.Units;

namespace TableGame.Abilities.Passive_abilities
{
    internal class PassiveRegeneration : PassiveAbility
    {
        private int counter = 0;
        public PassiveRegeneration()
        {
            Name = "Пассивная Регенерация";
            Description = "Регенерирует очко здоровья каждый ход";
        }

        public override void ProcessPassiveAbility(Unit unit)
        {
            counter++;

            if (counter == 2)
            {
                unit.Health++;
                counter = 0;
            }
        }
    }
}
