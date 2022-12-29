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

        // Текущая игра
        // Там и карта лежит - Map -Tiles
        [ObservableProperty]
        private Game currentGame;


        public MainWindowVM()
        {
            var newMap = new Map(32, 32, "test_map");

            currentGame = new Game(newMap,
                new GameStat(16),
                new Player(),
                new Player());
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

            

            // здесь должен быть метод Move и обработкой 2х тайлов
            
        }

        private void ChooseAction()
        {

        }





    }
}
