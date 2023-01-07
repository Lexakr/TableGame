using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableGame.Units;

namespace TableGame.Abilities.Target_abilities
{
    internal class Fireball : TargetAbility
    {
        public override bool CanUseOnEnemy => true;
        public override string Name { get; } = "Фаербол";
        public override string Description { get; } = "Запускает в цель снаряд, наносящий большой урон, уменьшающийся с расстоянием";

        public override void ApplyAbilityOnTarget(ref Unit caster, ref Unit target)
        {

        }
    }
}
