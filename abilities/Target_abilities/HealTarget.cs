﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableGame.Units;

namespace TableGame.Abilities.Active_abilities
{
    internal class HealTarget : TargetAbility
    {
        /// <summary>
        /// Сколько лечит скилл
        /// </summary>
        public static int HealPoints => 2;
        public override bool CanUseOnEnemy => false;
        public override string Name => "Лечение";
        public override string Description => $"Восстанавливает {HealPoints} единицы здоровья выбранной цели";

        /// <summary>
        /// Применение хила на цель
        /// </summary>
        public override void ApplyAbilityOnTarget(ref Unit caster, ref Unit target)
        {
            target.Health += HealPoints;
            // Если здоровье больше максимального
            if (target.Health > target.MaxHealth)
                target.Health = target.MaxHealth;
        }
    }


}
