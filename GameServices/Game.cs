using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TableGame.MapServices;

namespace TableGame.GameServices
{
    /// <summary>
    /// Game хранит в себе всю логику игры, включая объект карты,
    /// ее статистику, статистику игры и самих игроков. 
    /// </summary>
    internal partial class Game : ObservableObject
    {
        
        public Game(Map gameMap, GameStat gameStats, Player firstPlayer, Player secondPlayer, StepCounter counter)
        {
            this.gameMap = gameMap;
            this.gameStats = gameStats;
            this.firstPlayer = firstPlayer;
            this.secondPlayer = secondPlayer;
            this.counter = counter;
        }

        // TODO: activePlayer нужно через ссылку на firstPlayer или secondPlayer, ReferenceHandler
        [JsonConstructor]
        public Game(Map gameMap, GameStat gameStats, Player firstPlayer, Player secondPlayer, StepCounter counter, Player activePlayer)
        {
            this.gameMap = gameMap;
            this.gameStats = gameStats;
            this.firstPlayer = firstPlayer;
            this.secondPlayer = secondPlayer;
            Counter = counter;
            ActivePlayer = activePlayer;
        }

        private readonly Map gameMap;

        // TODO: Понять, нужно ли это поле и свойство ваще
        private readonly GameStat gameStats;

        private readonly Player firstPlayer;
        private readonly Player secondPlayer;

        public Map GameMap { get => gameMap; }
        public GameStat GameStats { get => gameStats; }
        public Player FirstPlayer { get => firstPlayer; }
        public Player SecondPlayer { get => secondPlayer; }

        [ObservableProperty]
        private StepCounter counter;

        [ObservableProperty]
        private Player activePlayer;

        /// <summary>
        /// Передача хода другому игроку
        /// </summary>
        /// <param name="p"></param>
        public void NextStep()
        {
            if (ActivePlayer == FirstPlayer)
            {
                ActivePlayer = SecondPlayer;
            }
            else
            {
                ActivePlayer = FirstPlayer;
            }
            counter.NextStep();
        }
    }
}
