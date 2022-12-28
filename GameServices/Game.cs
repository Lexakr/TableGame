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
    internal class Game
    {
        
        public Game(Map gameMap, GameStat gameStats, List<Player> players)
        {
            this.gameMap = gameMap;
            mapStats = new(gameMap);
            this.gameStats = gameStats;
            this.players = players;
        }

        [System.Text.Json.Serialization.JsonConstructor]
        public Game(Map gameMap, MapStat mapStats, GameStat gameStats, List<Player> players)
        {
            this.gameMap = gameMap;
            this.mapStats = mapStats;
            this.gameStats = gameStats;
            this.players = players;
        }

        private readonly Map gameMap;
        private readonly MapStat mapStats;
        private readonly GameStat gameStats;
        private readonly List<Player> players;
        
        public Map GameMap { get => gameMap; }
        public MapStat MapStats { get => mapStats; }
        public GameStat GameStats { get => gameStats; }
        public List<Player> Players { get => players; }

/*        public Game CreateGame()
        {
            Game _game = new();


            return _game;
        }*/
    }
}
