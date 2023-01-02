using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableGame.Fractions;
using TableGame.Units;

namespace TableGame.GameServices
{
    public partial class Player : ObservableObject
    {
        public string PlayerName { get; set; }
        public Fraction PlayerFraction { get; set; }

        [ObservableProperty]
        private List<Unit> playerUnits;

        public List<string> PlayerUnitNames
        {
            get => PlayerUnits.Select(x => x.Name).ToList();
        }

        public Player(string playerName, Fraction playerFraction)
        {
            PlayerName = playerName;
            PlayerFraction = playerFraction;
            PlayerUnits = new List<Unit> { new SoldierImperium(), new SoldierOrks() }; // TODO: CLEAR TEMP | Solder FOR TEST
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
