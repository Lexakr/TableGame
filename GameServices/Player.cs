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
        public Fraction Fraction { get; set; }

        /// <summary>
        /// Очки игрока. дающиеся за действия (убийство и тд)
        /// </summary>
        [ObservableProperty]
        private int score = 0;

        [ObservableProperty]
        private int money = 100;

        [ObservableProperty]
        private ObservableCollection<Unit> unitsInInvertory;

        public Player(string name, Fraction fraction)
        {
            Name = name;
            Fraction = fraction;
            UnitsInInvertory = new ObservableCollection<Unit> {  }; 
        }

        [System.Text.Json.Serialization.JsonConstructor]
        public Player(string name, Fraction fraction, ObservableCollection<Unit>? unitsInInvertory, int score, int money)
        {
            this.Name = name;
            this.Fraction = fraction;
            this.UnitsInInvertory = unitsInInvertory;
            this.score = score;
            this.money = money;
        }
    }
}
