using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TableGame.MapServices;
using TableGame.Units;

namespace TableGame.GameServices
{
    /// <summary>
    /// Логика взаимодействия персонажей.
    /// !!!Важно: перед стартом игры в GameLogic передается карта текущей Game
    /// </summary>
    internal class GameLogic
    {
        /// <summary>
        /// Нужен для синглтона
        /// </summar
        private static readonly Lazy<GameLogic> lazy =
        new Lazy<GameLogic>(() => new GameLogic());


        public delegate int MenuChoise(List<string> list);

        public event MenuChoise OpenMenu;

        /// <summary>
        /// 
        /// </summary>
        public Map CurrentMap { get; set; }

        /// <summary>
        /// Обработка первого клика игрока
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="tile"></param>
        public bool TileAction(ref Tile startTile) // TODO: REF проверить что передается ссылка на место в памяти!!!
        {
            if (!startTile.IsInteractable())
            {
                return false;
            }

            // красим тайлы кого атаковать можно и куда дойти можно
            return true;
            // Ожидание следующего клика игрока

           /* var result = OpenMenu(new List<string>() { "test", "test2" });

            // Если тайл свободен - перемещаем туда юнита.
            if (endTile.Passability == true)
            {
                // TODO: проверка, дойдет ли до туда юнит за ход. или не тут?
                MoveUnit(startTile.TileObject as Unit, ref startTile, ref endTile); // TODO: REF проверить что передается ссылка на место в памяти!!!
            }

            // Если на тайле объект чужой фракции, атакуем его
            else if (endTile.TileObject != null && endTile.TileObject is Unit)
            {
                var targetUnit = endTile.TileObject as Unit;
                var unit = startTile.TileObject as Unit;

                if (targetUnit.Fraction != unit.Fraction)
                {
                    AttackTargetUnit(unit, targetUnit);
                }
            }*/

            // TODO: Возможно какое-то действие, если выбранный тайл занят препятствием
        }

        /// <summary>
        /// Обработка второго клика игрока
        /// </summary>
        /// <param name="startTile"></param>
        /// <param name="endTile"></param>
        public bool TileAction(ref Tile startTile, ref Tile endTile)
        {
            // клетка препятствие
            if (!endTile.IsInteractable())
            {
                return false;
            }

            // клетка вне радиуса

            // клетка пустая

            // клетка с врагом

            // клетка изначальная

            
            return true;
        }

        /// <summary>
        /// Переместить выделенного юнита на выбранную клетку
        /// </summary>
        /// <param name="unit">Выделенный на карте юнит</param>
        /// <param name="startTile">Текущий тайл выделенного юнита</param>
        /// <param name="endTile">Выбранный на карте тайл</param>
        public void MoveUnit(Unit unit, ref Tile startTile, ref Tile endTile) // TODO: REF проверить что передается ссылка на место в памяти!!!
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

        public void AttackTargetUnit(Unit unit, Unit targetUnit)
        {
            // что-то типа targetUnit.OnAttack(unit); наоборот
            // void Attack(this unit, targetUnit);
        }
    }
}
