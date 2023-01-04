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
            if (!startTile.IsInteractable())
            {
                return false;
            }

            if (((Unit)startTile.TileObject).FractionName != CurrentGame.ActivePlayer.PlayerFraction.Name)
            {
                return false;
            }

            // проверка фракции юнита в тайле и фракции игрока

            // красим тайлы кого атаковать можно и куда дойти можно
            ShowActionTiles(ref startTile);
            return true;
            // Ожидание следующего клика игрока

           /* var result = OpenMenu(new List<string>() { "test", "test2" }); */
        }

        /// <summary>
        /// Обработка второго клика игрока
        /// </summary>
        /// <param name="startTile"></param>
        /// <param name="endTile"></param>
        public bool TileAction(ref Tile startTile, ref Tile endTile)
        {
            if (endTile.State == TileStates.Default)
            {
                ClearActionTiles();
                return false;
            }

            // клетка пустая
            
            if (endTile.IsMovable())
            {
                MoveUnit(ref startTile, ref endTile);
                ClearActionTiles();
                return true;
            }

            // клетка с врагом
            if (endTile.State == TileStates.CanAttack)
            {
                // TODO: melee/range attack атака требует MovePoints и обнуляет их
            }

            // клетка с союзником
            if (endTile.State == TileStates.Ally)
            {
                // TODO: интеракт с союзником
            }

            // клетка изначальная
            // TODO: Выделение активного юнита белым цветом, add Tilestate.SelectedUnit
            if (startTile == endTile)
            {
                // меню что можно делать юниту с самим собой
            }

            ClearActionTiles();
            return true;
        }

        /// <summary>
        /// Переместить выделенного юнита на выбранную клетку
        /// </summary>
        /// <param name="unit">Выделенный на карте юнит</param>
        /// <param name="startTile">Текущий тайл выделенного юнита</param>
        /// <param name="endTile">Выбранный на карте тайл</param>
        public void MoveUnit(ref Tile startTile, ref Tile endTile)
        {
            ((Unit)startTile.TileObject).MoveTo(ref endTile);
            // TODO: отнимать MovePoints
            ((Unit)startTile.TileObject).MovePointsCurrent -= Math.Max(Math.Abs(startTile.PosX - endTile.PosX), Math.Abs(startTile.PosY - endTile.PosY));

            startTile.RemoveObj();
            // TODO: Вызвать функцию отрисовки ShowActionTiles ЕСЛИ есть ещё movePoints
            ClearActionTiles();
            ShowActionTiles(ref endTile);
        }

        public void AttackTargetUnit(ref Unit unit, ref Unit targetUnit)
        {
            // что-то типа targetUnit.OnAttack(unit); наоборот
            // void Attack(this unit, targetUnit);
        }

        private void ShowActionTiles(ref Tile tile)
        {
            var unit = tile.TileObject as Unit;
            Debug.WriteLine($"Show action: unit pos: {unit.PosX},{unit.PosY}. MOVE POINTS: {unit.MovePointsCurrent}");

            // List INDEX
            int left = unit.PosX - 1 - unit.MovePointsCurrent;
            int right = unit.PosX - 1 + unit.MovePointsCurrent;
            int top = unit.PosY - 1 + unit.MovePointsCurrent;
            int bottom = unit.PosY - 1 - unit.MovePointsCurrent;

            // кол-во шагов - спиралей
            for(int i = 0; i < unit.MovePointsCurrent; i++)
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
            else if (tile.TileObject is Unit)
            {
                // проверка на врага
                if((tile.TileObject as Unit).FractionName != unit.FractionName)
                {
                tile.State = TileStates.CanAttack;
                tilesToClear.Add(tile);
                }
                // если юнит не враг = друг
                else
                {
                    tile.State = TileStates.Ally;
                    tilesToClear.Add(tile);
                }
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
                unit.MoveTo(ref tile, 0); // 0 - это снять MovePoints
                return true;
            }
            return false;
        }
    }
}
