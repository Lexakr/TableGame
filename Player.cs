using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableGame.units;

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

        public void PlayerMove()
        {

        }

    }
}
