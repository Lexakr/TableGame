using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableGame.abilities;

namespace TableGame.units
{
    internal class Unit : ICoordinates
    {
        private int posY;
        public string Name { get; set; }
        public string Fraction { get; set; }
        public string Race { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; }
        public int Price { get; } // "стоимость" юнита в очках

        public bool IsMelee { get; set; } // может ли ближний бой
        public bool IsRange { get; set; } // может ли дальний бой
        public int Power { get; set; } // физическая сила модели и вероятность нанесения урона в рукопашном бою
        public int Durability { get; set; } //сопротивляемость модели физическому урону.
        public int Wounds { get; set; } // количество урона, которое модель выдержит и не погибнет
        public int MeleeAttacks { get; set; } // Количество ударов, которые модель может нанести в рукопашном бою
        public int Defense { get; set; } // защита, которую броня даёт модели.

        public int PosX { get; set; }
        public int PosY { get => posY; set => posY = value; }
        public List<Ability>? Abilities { get; set; }
        public Unit()
        {
            // by default
            Name = "Unit";
            Fraction = "Neutral";
        }
    }
}
