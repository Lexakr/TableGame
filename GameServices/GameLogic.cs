using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TableGame.Abilities;
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
        private Logger logger = Logger.GetInstance();

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

            if ((startTile.TileObject as Unit).FractionName != CurrentGame.ActivePlayer.PlayerFraction.Name)
            {
                return false;
            }

            if ((startTile.TileObject as Unit).MovePointsCurrent == 0)
            {
                return false;
            }

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
                // TODO: проверка можно ли melee атаку
                var target = (Unit)endTile.TileObject;
                var attacker = (Unit)startTile.TileObject;

                // TODO: логи, открывание меню только с возможными атаками
                List<string> variances = new() { "Range Attack", "Melee Attack" };

                List<TargetAbility> targetAbilities = new();

                if (attacker.Abilities != null)
                {
                    foreach (TargetAbility ability in attacker.Abilities.Where(x => x is TargetAbility).Where(x => (x as TargetAbility).CanUseOnEnemy))
                    {
                        targetAbilities.Add(ability);
                        variances.Add(ability.Name);
                    }
                }

                var result = OpenMenu(variances);

                switch (result)
                {
                    // Закрыли окно - не выбрали действие
                    case -1:
                        ClearActionTiles();
                        return false;
                    case 0:
                        attacker.RangeAttack(ref target);
                        logger.Info($"{attacker.Name}: {startTile.StringCoordinates} нанес {target.Name}: {endTile.StringCoordinates} {attacker.RangeDamage} урона выстрелом");
                        break;
                    case 1:
                        attacker.MeleeAttack(ref target);
                        logger.Info($"{attacker.Name}: {startTile.StringCoordinates} нанес {target.Name}: {endTile.StringCoordinates} {attacker.MeleeDamage} урона");
                        break;
                    default:
                        foreach (var ability in targetAbilities)
                        {
                            if (variances[result] == ability.Name)
                            {
                                logger.Info(ability.ApplyAbilityOnTarget(ref attacker, ref target));
                            }
                        }
                        break;
                }

                // Перевод в ноль очков хода после атаки
                attacker.MovePointsCurrent = 0;

                if (target.Health <= 0)
                {
                    CurrentGame.ActivePlayer.Score += target.Price;
                    endTile.TileObject = null;
                }
            }

            // клетка с союзником
            if (endTile.State == TileStates.Ally)
            {
                var ally = (Unit)endTile.TileObject;
                var unit = (Unit)startTile.TileObject;

                List<string> variances = new();

                List<TargetAbility> targetAbilities = new();

                if (unit.Abilities != null && unit.Abilities.Find(x => x is TargetAbility) != null)
                {
                    foreach (TargetAbility ability in unit.Abilities.Where(x => x is TargetAbility).Where(x => !(x as TargetAbility).CanUseOnEnemy))
                    {
                        targetAbilities.Add(ability);
                        variances.Add(ability.Name);
                    }

                    var result = OpenMenu(variances);

                    switch (result)
                    {
                        // Закрыли окно - не выбрали действие
                        case -1:
                            ClearActionTiles();
                            return false;
                        default:
                            foreach (var ability in targetAbilities)
                            {
                                if (variances[result] == ability.Name)
                                {
                                    logger.Info(ability.ApplyAbilityOnTarget(ref unit, ref ally));
                                }
                            }
                            break;
                    }

                    // Перевод в ноль очков хода после каста на союзника
                    unit.MovePointsCurrent = 0;
                }
            }

            // клетка изначальная
            // TODO: Выделение активного юнита белым цветом, add Tilestate.SelectedUnit
            if (startTile == endTile)
            {
                var unit = (Unit)startTile.TileObject;

                if (unit.Abilities == null || unit.Abilities.Find(x => x is TargetAbility) == null)
                {
                    ClearActionTiles();
                    return false;
                }

                List<string> variances = new();
                List<TargetAbility> targetAbilities = new();

                foreach (TargetAbility ability in unit.Abilities.Where(x => x is TargetAbility).Where(x => !(x as TargetAbility).CanUseOnEnemy))
                {
                    targetAbilities.Add(ability);
                    variances.Add(ability.Name);
                }

                var result = OpenMenu(variances);

                switch (result)
                {
                    // Закрыли окно - не выбрали действие
                    case -1:
                        ClearActionTiles();
                        return false;
                    default:
                        foreach (var ability in targetAbilities)
                        {
                            if (variances[result] == ability.Name)
                            {
                                logger.Info(ability.ApplyAbilityOnTarget(ref unit, ref unit));
                            }
                        }
                        break;
                }

                // Перевод в ноль очков хода после каста на союзника
                unit.MovePointsCurrent = 0;
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
            // просчитать MovePoints - хватит или нет
            int xDiffrent = endTile.PosX - startTile.PosX;
            int yDiffrent = endTile.PosY - startTile.PosY;
            logger.Info($"До инверсий: Разница Х: {xDiffrent} Разница Y {yDiffrent}");

            xDiffrent = xDiffrent < 0 ? -xDiffrent : xDiffrent;
            yDiffrent = yDiffrent < 0 ? -yDiffrent : yDiffrent;
            logger.Debug($"После инверсий: Разница Х: {xDiffrent} Разница Y {yDiffrent}");

            var movePoints = xDiffrent > yDiffrent ? xDiffrent : yDiffrent;
            logger.Debug($"Разница (movePoints): {movePoints}");

            ((Unit)startTile.TileObject).MoveTo(ref endTile, movePoints); // Отнимать MovePoints
            logger.Debug($"Текущие (movePoints) юнита: {(endTile.TileObject as Unit).MovePointsCurrent}");

            startTile.RemoveObj();
            // TODO: Вызвать функцию отрисовки ShowActionTiles ЕСЛИ есть ещё movePoints

        }

        public void AttackTargetUnit(ref Unit unit, ref Unit targetUnit)
        {
            // что-то типа targetUnit.OnAttack(unit); наоборот
            // void Attack(this unit, targetUnit);
        }

        private void ShowActionTiles(ref Tile tile)
        {
            // Тайл с юнитом
            tile.State = TileStates.SelectedUnit;
            tilesToClear.Add(tile);

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
        public void ClearActionTiles()
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
            if (tile.State == TileStates.CanMove && tile.IsMovable())
            {
                unit.MoveTo(ref tile, 0); // 0 - это снять MovePoints
                CurrentGame.Counter.Attach(unit);
                tile.State = TileStates.Default;
                return true;
            }
            return false;
        }

        public void ShowTilesToPutUnit()
        {
            // 20% от общей высоты карты
            int height = CurrentGame.GameMap.Size_y / 5;

            // верхняя часть поля
            if (CurrentGame.ActivePlayer == CurrentGame.FirstPlayer)
            {
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < CurrentGame.GameMap.Size_x; x++)
                    {
                        if (CurrentGame.GameMap.Tiles[y][x].IsMovable())
                        {
                            CurrentGame.GameMap.Tiles[y][x].State = TileStates.CanMove;
                            tilesToClear.Add(CurrentGame.GameMap.Tiles[y][x]);
                        }
                    }
                }
            }

            // нижняя часть поля
            if (CurrentGame.ActivePlayer == CurrentGame.SecondPlayer)
            {
                for (int y = CurrentGame.GameMap.Size_y - 1; y > CurrentGame.GameMap.Size_y - height; y--)
                {
                    for (int x = 0; x < CurrentGame.GameMap.Size_x; x++)
                    {
                        if (CurrentGame.GameMap.Tiles[y][x].IsMovable())
                        {
                            CurrentGame.GameMap.Tiles[y][x].State = TileStates.CanMove;
                            tilesToClear.Add(CurrentGame.GameMap.Tiles[y][x]);
                        }
                    }
                }
            }
        }
    }
}
