using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableGame.Abilities
{
    internal class PassiveAbility : Ability, IAbility
    {
        public PassiveAbility(string Name) : base(Name)
        {
        }
    }
}
