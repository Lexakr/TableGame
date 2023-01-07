using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableGame.Units;

namespace TableGame.Abilities
{
    internal abstract class TargetAbility : Ability
    {
        /// <summary>
        /// Можно ли применить на врага
        /// </summary>
        public abstract bool CanUseOnEnemy { get; }

        public abstract void ApplyAbilityOnTarget(ref Unit caster, ref Unit target);
    }
}
