using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableGame.Abilities;
using TableGame.Units;
using TableGame.MapServices;
using TableGame.Fractions;

namespace TableGame.Units
{
    public abstract class Unit : MapObject
    {
        public string Fraction { get; set; } // 
        public int Health { get; set; } // а надо ли?
        public int MaxHealth { get; } // количество урона, которое модель выдержит и не погибнет
        public int Price { get; } // "стоимость" юнита в очках
        public bool IsMelee { get; set; } // может ли ближний бой
        public bool IsRange { get; set; } // может ли дальний бой
        public int Power { get; set; } // физическая сила модели и вероятность нанесения урона в рукопашном бою
        public int MeleeAttacks { get; set; } // Количество ударов, которые модель может нанести в рукопашном бою
        public int Defense { get; set; } // защита, которую броня даёт модели.
        public int MovePoints { get; set; }
        public List<Ability>? Abilities { get; set; }

        /// <summary>
        /// Юнит по умолчанию соответствует Imperium Soldier
        /// </summary>
        public Unit()
        {
            MaxHealth = 4;
            Health = MaxHealth; // полное здоровье
            Price = 50;
            IsMelee = true;
            IsRange = true;
            Power = 4;
            MeleeAttacks = 2;
            Defense = 3;
            MovePoints = 3;
            Fraction = "Fraction";
        }
/*        Name = "Name";
            PosX = -1;
            PosY = -1;
            CurrentLocation = null;*/

        [System.Text.Json.Serialization.JsonConstructor]
        public Unit(string Name, int PosX, int PosY, Tile? CurrentLocation, string UnitFraction, int Health, int MaxHealth, int Price, 
            bool IsMelee, bool IsRange, int Power, int MeleeAttacks, int Defense, 
            int MovePoints, List<Ability>? Abilities)
        {
            this.Name = Name;
            this.PosX = PosX;
            this.PosY = PosY;
            this.CurrentLocation = CurrentLocation;
            this.Fraction = UnitFraction;
            this.Health = Health;
            this.MaxHealth = MaxHealth;
            this.Price = Price;
            this.IsMelee = IsMelee;
            this.IsRange = IsRange;
            this.Power = Power;
            this.MeleeAttacks = MeleeAttacks;
            this.Defense = Defense;
            this.MovePoints = MovePoints;
            this.Abilities = Abilities;
        }

        /// <summary>
        /// Перемещение Unit на новый Tile
        /// </summary>
        /// <param name="t">Тайл на который перемещаемся</param>
        public void MoveTo(Tile t)
        { 
            ((ICoordinates)t).GetLocation(); // Приведение к интерфейсу
            if (UnitUtility.IsMovable(t))
            {
                CurrentLocation = t;
                PosX = t.PosX;
                PosY = t.PosY;
            }
            else
                Console.WriteLine("Location is busy.");
        }

        public abstract void Attack();
    }
}
