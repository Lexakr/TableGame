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
        private List<Tile> tilesToClear = new();
        /// <summary>
        /// Нужен для синглтона
        /// </summar
        private static readonly Lazy<GameLogic> lazy =
        new Lazy<GameLogic>(() => new GameLogic());


        public delegate int MenuChoise(List<string> list);
        public event MenuChoise OpenMenu;
        public Game CurrentGame { get; set; }

        /// <summary>
        /// Обработка первого клика игрока
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="tile"></param>
        public bool TileAction(ref Tile startTile) // TODO: REF проверить что передается ссылка на место в памяти!!!
        {
            Debug.WriteLine("INSIDE GAMELOGIC" + CurrentGame.GetHashCode().ToString());
/*            if (!startTile.IsInteractable())
            {
                return false;
            }*/

            // проверка фракции юнита в тайле и фракции игрока

            // красим тайлы кого атаковать можно и куда дойти можно
            var tileUnit = startTile.TileObject as Unit;
            tileUnit = new SoldierImperium();
            tileUnit.PosX = startTile.PosX;
            tileUnit.PosY = startTile.PosY;
            ShowActionTiles(ref tileUnit);
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
            //TODO: перенести ниже. Это для теста:
            ClearActionTiles();
            return true;

            // клетка препятствие
            if (!endTile.IsInteractable())
            {
                return false;
            }

            // клетка вне радиуса

            // клетка пустая

            // клетка с врагом
            // melee/range attack

            // клетка изначальная

            
            return true;
        }

        /// <summary>
        /// Переместить выделенного юнита на выбранную клетку
        /// </summary>
        /// <param name="unit">Выделенный на карте юнит</param>
        /// <param name="startTile">Текущий тайл выделенного юнита</param>
        /// <param name="endTile">Выбранный на карте тайл</param>
        public void MoveUnit(ref Unit unit, ref Tile startTile, ref Tile endTile) // TODO: REF проверить что передается ссылка на место в памяти!!!
        {
            if (endTile.IsMovable())
            {
                startTile.RemoveObj();
                unit.MoveTo(ref endTile);
            }
            else
            {
                // TODO: Какая-то реакция, если эндТайл это препятствие или занят союзным юнитом
            }
        }

        public void AttackTargetUnit(ref Unit unit, ref Unit targetUnit)
        {
            // что-то типа targetUnit.OnAttack(unit); наоборот
            // void Attack(this unit, targetUnit);
        }

        private void ShowActionTiles(ref Unit unit)
        {

            Debug.WriteLine($"Show action: unit pos: {unit.PosX},{unit.PosY}. MOVE POINTS: {unit.MovePoints}");

            // List INDEX
            int left = unit.PosX - 1 - unit.MovePoints;
            int right = unit.PosX - 1 + unit.MovePoints;
            int top = unit.PosY - 1 + unit.MovePoints;
            int bottom = unit.PosY - 1 - unit.MovePoints;

            // кол-во шагов - спиралей
            for(int i = 0; i < unit.MovePoints; i++)
            {
                // left-right
                for (int x = left; x <= right; x++)
                {
                    // заполнение
                    ChangeStateForAction(x, top, ref unit);
                    ChangeStateForAction(x, bottom, ref unit);
                }

                // top-bottom
                for (int y = bottom; y <= top; y++)
                {
                    // заполненеие
                    ChangeStateForAction(left, y, ref unit);
                    ChangeStateForAction(right, y, ref unit);
                }

                top -= 1;
                bottom += 1;
                left += 1;
                right -= 1;
            }

        }

        /// <summary>
        /// Сменить состояние тайла на соответствующий для взаимодействия с юнитом
        /// </summary>
        /// <param name="x">ИНДЕКС объекта на карте</param>
        /// <param name="y">ИНДЕКС ОБЪЕКТА НА КАРТЕ</param>
        /// <param name="unit"></param>
        private void ChangeStateForAction(int x, int y, ref Unit unit)
        {
            if (x < 0 || y < 0 || x >= CurrentGame.GameMap.Size_x || y >= CurrentGame.GameMap.Size_y)
                return;

            //Debug.WriteLine($"Обрабатываю клетку в ренже: {x},{y}");

            var tile = CurrentGame.GameMap.Tiles[x][y];

            if (tile.Passability)
            {
                // green state
                tile.State = TileStates.CanMove;
                tilesToClear.Add(tile);
            }
            else if (tile.TileObject is Unit && (tile.TileObject as Unit).FractionName != unit.FractionName)
            {
                // red staet
                tile.State = TileStates.CanAttack;
                tilesToClear.Add(tile);
            }
            
        }

        /// <summary>
        /// Очистка окрашенных тайлов после завершения хода юнитом
        /// </summary>
        private void ClearActionTiles()
        {
            foreach (Tile t in tilesToClear)
            {
                t.State = TileStates.Default;
            }
            tilesToClear.Clear();
        }

        /// <summary>
        /// Принудительная очистка всех тайлов
        /// </summary>
        private void ClearAllTilesOnMap()
        {
            foreach (var item1 in CurrentGame.GameMap.Tiles)
            {
                foreach (var item2 in item1)
                {
                    item2.State = TileStates.Default;
                }
            }
        }

        // TODO: IMPORTANT - ADD func for MOVE unit on start game

        public bool PutUnitOnMap(ref Unit unit, ref Tile tile)
        {
            // TODO: проверка на участок карты, выделен ли он под стартовое размещение юнитов
            if (tile.IsMovable())
            {
                unit.MoveTo(ref tile);
                return true;
            }
            return false;
        }
    }
}
