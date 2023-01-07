using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableGame.Fractions;
using TableGame.Units;

namespace TableGame.GameServices
{
    public partial class Player : ObservableObject
    {
        public string Name { get; set; }
        public Fraction PlayerFraction { get; set; }

        [ObservableProperty]
        private int money = 100;

        [ObservableProperty]
        private ObservableCollection<Unit> unitsInInvertory;

        public Player(string playerName, Fraction playerFraction)
        {
            Name = playerName;
            PlayerFraction = playerFraction;
            UnitsInInvertory = new ObservableCollection<Unit> { new SoldierImperium(), new SoldierImperium(), new SoldierOrks() }; // TODO: CLEAR TEMP | Solder FOR TEST
        }

        [System.Text.Json.Serialization.JsonConstructor]
        public Player(string PlayerName, string PlayerFraction, ObservableCollection<Unit>? PlayerUnits)
        {
            this.Name = PlayerName;
            //this.PlayerFraction = PlayerFraction;
            this.UnitsInInvertory = PlayerUnits;
        }
    }
}
