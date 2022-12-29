using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableGame.Units;

namespace TableGame
{
    internal class Player
    {
        public string PlayerName { get; set; }
        public string PlayerFraction { get; set; }
        public List<Unit>? PlayerUnits { get; set; }
        
        public Player() 
        {
            PlayerName = "Player1";
            PlayerFraction = "Imperium"; // REFACT
            PlayerUnits = new List<Unit> { new SoldierImperium() };
        }

        [System.Text.Json.Serialization.JsonConstructor]
        public Player(string PlayerName, string PlayerFraction, List<Unit>? PlayerUnits)
        {
            this.PlayerName = PlayerName;
            this.PlayerFraction = PlayerFraction;
            this.PlayerUnits = PlayerUnits;
        }


        /// <summary>
        /// Выбор действия после ПКМ по тайлу
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="tile"></param>
        public void EndTileAction(Unit unit, ref Tile startTile, ref Tile endTile) // TODO: REF проверить что передается ссылка на место в памяти!!!
        {
            // Если тайл свободен - перемещаем туда юнита.
            if (endTile.Passability == true)
            {
                // TODO: проверка, дойдет ли до туда юнит за ход. или не тут?
                MoveUnit(unit, ref startTile, ref endTile); // TODO: REF проверить что передается ссылка на место в памяти!!!
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
            }

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

        public void AttackTargetUnit(Unit unit, Unit targetUnit)
        {
            // что-то типа targetUnit.OnAttack(unit);
        }

    }
}
