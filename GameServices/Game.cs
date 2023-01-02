using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            mapStats = new(gameMap);
            this.gameStats = gameStats;
            this.firstPlayer = firstPlayer;
            this.secondPlayer = secondPlayer;
            this.counter = counter;
        }

        [System.Text.Json.Serialization.JsonConstructor]
        public Game(Map gameMap, MapStat mapStats, GameStat gameStats, Player firstPlayer, Player secondPlayer)
        {
            this.gameMap = gameMap;
            this.mapStats = mapStats;
            this.gameStats = gameStats;
            this.firstPlayer = firstPlayer;
            this.secondPlayer = secondPlayer;
        }

        private readonly Map gameMap;
        private readonly MapStat mapStats;
        private readonly GameStat gameStats;

        private readonly Player firstPlayer;
        private readonly Player secondPlayer;

        public Map GameMap { get => gameMap; }
        public MapStat MapStats { get => mapStats; }
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
