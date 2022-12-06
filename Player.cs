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
        public List<Unit> PlayerUnits { get; set; }
        
        public Player() 
        {
            PlayerName = "Player1";
            PlayerFraction = "Imperium"; // REFACT
            PlayerUnits = new List<Unit> { new Soldier(), new Soldier() };
        }

        public void PlayerMove()
        {

        }

    }
}
