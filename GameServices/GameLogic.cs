using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableGame.Units;

namespace TableGame.GameServices
{
    internal static class GameLogic
    {
        /// <summary>
        /// Выбор действия после ПКМ по тайлу
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="tile"></param>
        public static void TileAction(ref Tile startTile, ref Tile endTile) // TODO: REF проверить что передается ссылка на место в памяти!!!
        {
            /*// Если тайл свободен - перемещаем туда юнита.
            if (endTile.Passability == true)
            {
                // TODO: проверка, дойдет ли до туда юнит за ход. или не тут?
                MoveUnit(startTile.unit, ref startTile, ref endTile); // TODO: REF проверить что передается ссылка на место в памяти!!!
            }

            // Если на тайле объект чужой фракции, атакуем его
            else if (endTile.TileObject != null && endTile.TileObject.GetType() == typeof(Unit))
            {
                // TODO: ПЕРЕДЕЛАТЬ!!!! Надо взаимодействовать со значением в памяти, а если создается новая переменная, как сейчас, то делать ее ссылкой
                var targetUnit = endTile.TileObject as Unit;

                if (targetUnit.Fraction != unit.Fraction)
                {
                    AttackTargetUnit(unit, targetUnit);
                }
            }*/

            // TODO: Возможно какое-то действие, если выбранный тайл занят препятствием
        }

        /// <summary>
        /// Переместить выделенного юнита на выбранную клетку
        /// </summary>
        /// <param name="unit">Выделенный на карте юнит</param>
        /// <param name="startTile">Текущий тайл выделенного юнита</param>
        /// <param name="endTile">Выбранный на карте тайл</param>
        public static void MoveUnit(Unit unit, ref Tile startTile, ref Tile endTile) // TODO: REF проверить что передается ссылка на место в памяти!!!
        {
            if (endTile.IsMovable())
            {
                startTile.RemoveObj();
                endTile.AddObj(unit);
                unit.CurrentLocation = endTile;
            }
            else
            {
                // TODO: Какая-то реакция, если эндТайл это препятствие или занят союзным юнитом
            }
        }

        public static void AttackTargetUnit(Unit unit, Unit targetUnit)
        {
            // что-то типа targetUnit.OnAttack(unit); наоборот
            // void Attack(this unit, targetUnit);
        }
    }
}
