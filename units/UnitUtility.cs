using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableGame.Abilities;

namespace TableGame.Units
{
    internal static class UnitUtility
    {
        public static bool IsMovable(this Tile t)
        {
            if (t.Passability && t.TileObject == null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Подброс кубика 1D6
        /// </summary>
        /// <returns>Выпавшее число</returns>
        public static int RollDice1D6()
        {
            return new Random().Next(1, 7);
        }

        public static string DisplayUnitInfo(this Unit unit)
        {
            return $"Имя: {unit.Name}, фракция: {unit.FractionName}\n" +
                $"Здоровье: {unit.Health}/{unit.MaxHealth}\n" +
                $"Навык ближнего боя: {unit.MeleeSkill}, урон: {unit.MeleeDamage}\n" +
                $"Навык дальнего боя: {unit.RangeSkill}, урон: {unit.RangeDamage}\n" +
                $"Очки передвижения: {unit.MovePointsCurrent}/{unit.MovePointsTotal}\n" +
                $"{unit.ShowAbilitiesList}";
        }

        public static string ShowAbilitiesList(this Unit unit)
        {
            if (unit.Abilities == null)
            {
                return "У юнита нет способностей";
            }

            var abilities = string.Empty;
            if (unit.Abilities.Any(x => x is ActiveAbility))
            {
                abilities += "Активные способности:\n";
                foreach (var ability in unit.Abilities.Where(x => x is ActiveAbility))
                {
                    abilities += $"{ability.Name}: {ability.Description}\n";
                }
                abilities += "\n";
            }

            if (unit.Abilities.Any(x => x is PassiveAbility))
            {
                abilities += "Пассивки:\n";
                foreach (var ability in unit.Abilities.Where(x => x is PassiveAbility))
                {
                    abilities += $"{ability.Name}: {ability.Description}\n";
                }
            }

            return abilities;

        }
    }
}
