using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableGame.Units;

namespace TableGame.Abilities.Passive_abilities
{
    internal class PassiveRegeneration : PassiveAbility
    {
        public override string Name { get; } = "Пассивная Регенерация";
        public override string Description { get; } = "Восстанавливает 1 единицу здоровья каждый ход";

        private int counter = 0;

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
