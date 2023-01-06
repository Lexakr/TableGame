using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableGame.Units;

namespace TableGame.Abilities
{
    internal abstract class PassiveAbility : Ability, IAbility
    {
        public PassiveAbility()
        {

        }

        /// <summary>
        /// Действие пассивной способности, выполняемое каждый ход
        /// </summary>
        public abstract void ProcessPassiveAbility(Unit unit);
    }
}
