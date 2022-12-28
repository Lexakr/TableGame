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
        /// 
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="tile"></param>
        public void Action(Unit unit, Tile tile)
        {
            //
            MoveUnit(unit, tile);
        }

        /// <summary>
        /// Переместить выделенного юнита на выбранную клетку
        /// </summary>
        /// <param name="unit">Выделенный на карте юнит</param>
        /// <param name="tile">Выбранный на карте тайл</param>
        public void MoveUnit(Unit unit, Tile tile)
        {

            tile.AddObj(unit); 
            unit.CurrentLocation = tile;
        }

    }
}
