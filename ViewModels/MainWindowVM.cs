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

        private GameLogic gameLogic;

        public MainWindowVM(Player player)
        {

            var newMap = new Map(32, 32, "test_map");

            currentGame = new Game(newMap,
                new GameStat(16),
                player,
                new Player());

            gameLogic = new GameLogic();
            gameLogic.CurrentGame = currentGame;
            gameLogic.OpenMenu += OpenChooseMenu;

            Debug.WriteLine("INSIDE GAMELOGIC" + CurrentGame.GetHashCode().ToString());
        }


        [RelayCommand]
        private void StartGame()
        {

            var newMap = new Map(16, 16, "game_map");

            CurrentGame = new Game(newMap,
                new GameStat(16),
                new Player(),
                new Player());

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
                // записываем начальный (стартовый) объект триггер
                previosTile = tile;

                if (!gameLogic.TileAction(ref tile))
                {
                    // действие с юнитом совершено: можно обнулить триггер
                    previosTile = null;
                    return;
                }
            }
            // если игроку нужно выбирает уже вторую клетку для взаимодействия
            else
            {
                // отправляем запрос на взаимодейсвтвие этих двух клеток
                if (gameLogic.TileAction(ref tile, ref previosTile))
                    previosTile = null;
            }

        }

        private int OpenChooseMenu(List<string> choices)
        {
            var menuWindow = new ChooseActionsWindow(choices);
            menuWindow.ShowDialog();

            return menuWindow.ResultChoice;
        }
    }
}
