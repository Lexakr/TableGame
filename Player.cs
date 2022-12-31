using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableGame.Fractions;
using TableGame.Units;

namespace TableGame
{
    public class Player
    {
        public string PlayerName { get; set; }
        public Fraction PlayerFraction { get; set; }
        public List<Unit>? PlayerUnits { get; set; }
        
        public Player() 
        {
            PlayerName = "Player1";
            //PlayerFraction = "Imperium"; // REFACT
            PlayerUnits = new List<Unit> { new SoldierImperium() };
        }

        public Player(string playerName, Fraction playerFraction)
        {
            PlayerName = playerName;
            PlayerFraction = playerFraction;
        }

        [System.Text.Json.Serialization.JsonConstructor]
        public Player(string PlayerName, string PlayerFraction, List<Unit>? PlayerUnits)
        {
            this.PlayerName = PlayerName;
            //this.PlayerFraction = PlayerFraction;
            this.PlayerUnits = PlayerUnits;
        }
    }
}
