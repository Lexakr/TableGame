using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableGame.GameServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TableGame.MapServices;
using Windows.Networking.Sockets;
using System.Collections.ObjectModel;
using System.Diagnostics;
using TableGame.Views;
using TableGame.Units;

namespace TableGame.ViewModels
{
    /// <summary>
    /// Класс ИГРЫ
    /// </summary>
    internal partial class MainWindowVM : ObservableValidator
    {

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ClickMapButtonCommand))]
        private Tile? selectedMapButton;

        /// <summary>
        /// Логика обработки 1го поля и второго поля на которое нажмёт игрок
        /// Если поле = null = это первый клик на поле, если есть = начать взаимодействие с вторым
        /// </summary>
        private Tile previosTile;

        // Текущая игра
        // Там и карта лежит - Map -Tiles
        [ObservableProperty]
        private Game currentGame;

        
        [ObservableProperty]
        private Unit listBoxSelectedItem;

        private GameLogic gameLogic;

        public MainWindowVM(Player player1, Player player2, int totalSteps)
        {
            var newMap = new Map(32, 32, "test_map");
            var counter = new StepCounter(totalSteps);

            currentGame = new Game(newMap,
                new GameStat(16),
                player1,
                player2,
                counter);

            gameLogic = new GameLogic();
            gameLogic.CurrentGame = currentGame;
            gameLogic.OpenMenu += OpenChooseMenu;

            counter.GameEnded += GameOver;

            StartGame();
            
        }

        private void StartGame()
        {   
            if(RollDice("Выбор игрока/чей ход\n\n(Игрок 1: 1-3\nИгрок 2: 4-6)") > 3)
            {
                CurrentGame.ActivePlayer = CurrentGame.FirstPlayer;
            }
            else
            {
                CurrentGame.ActivePlayer = CurrentGame.SecondPlayer;
            }

            Debug.Write("ACTIVE PLAYER: " + CurrentGame.ActivePlayer.PlayerName);


            // назначение первого игрока? (вызов окна костей в диалоге)

            // TODO: вызов магазина в диалоговом окне + в последовательности активного игрока

            // TODO: ЛОГИКА ИГРЫ - если шаг 0 - выбор юнитов чтобы ставить
        }

        [RelayCommand]
        private void NextStep()
        {
            CurrentGame.NextStep();
        }

        [RelayCommand]
        private void ClickMapButton(Tile tile)
        {
            Debug.WriteLine($"Command ClickMapButton: x:{tile.PosX} y:{tile.PosY} Hash:{tile.Hash}");

            // ТРИГГЕРНАЯ СИСИТЕМА:
            //
            // Если это первый клик игрока будет null (ранее не выбирал юнита для действия)
            if (previosTile == null)
            {
                if (CurrentGame.Counter.Current < 2)
                {
                    if (ListBoxSelectedItem != null)
                    {
                        if (gameLogic.PutUnitOnMap(ref listBoxSelectedItem, ref tile))
                        {
                            var result = CurrentGame.ActivePlayer.PlayerUnits.Remove(ListBoxSelectedItem);
                            previosTile = null;
                            return;
                        }
                    }

                    return;
                }

                if (!gameLogic.TileAction(ref tile))
                {
                    // действие с юнитом совершено: можно обнулить триггер
                    previosTile = null;
                    return;
                }

                // записываем начальный (стартовый) объект триггер
                previosTile = tile;
            }
            // если игроку нужно выбирает уже вторую клетку для взаимодействия
            else
            {
                // отправляем запрос на взаимодейсвтвие этих двух клеток
                    gameLogic.TileAction(ref previosTile, ref tile);
                    previosTile = null;
            }

        }

        private int OpenChooseMenu(List<string> choices)
        {
            var menuWindow = new ChooseActionsWindow(choices);
            menuWindow.ShowDialog();

            return menuWindow.ResultChoice;
        }

        private int RollDice(string nameOfEvent)
        {
            var diceWindow = new RollDiceWindow(nameOfEvent);
            diceWindow.ShowDialog();

            return diceWindow.RollResult;
        }

        // TODO: some window?
        private void GameOver()
        {

        }
    }
}
