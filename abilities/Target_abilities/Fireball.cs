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
        public static int Damage => 3;
        public override bool CanUseOnEnemy => true;
        public override string Name { get; } = "Фаербол";
        public override string Description { get; } = $"Запускает в цель снаряд, наносящий {Damage} единиц урона";

        public override string ApplyAbilityOnTarget(ref Unit caster, ref Unit target)
        {
            target.Health -= Damage;
            if (target.Health <= 0)
                return $"{caster.Name}: {caster.StringCoordinates} запустил в {target.Name}: {target.StringCoordinates} {Name}, нанес {Damage} урона и убил его";

            return $"{caster.Name}: {caster.StringCoordinates} запустил в {target.Name}: {target.StringCoordinates} {Name} и нанес {Damage} урона";
        }
    }
}
