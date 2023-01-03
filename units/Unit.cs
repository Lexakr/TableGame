﻿using System;
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
        /// <summary>Фракция юнита</summary>
        public string FractionName { get; set; }

        /// <summary>Текущий уровень здоровья</summary>
        public int Health { get; set; }

        /// <summary>Максимальное здоровье</summary>
        public int MaxHealth { get; }

        /// <summary>Цена покупки</summary>
        public int Price { get; }

        /// <summary>Навык ближнего боя 1-100%, 6-0%</summary>
        public int MeleeSkill { get; set; }

        /// <summary>Кол-во урона в ближнем бою</summary>
        public int MeleeDamage { get; set; }

        /// <summary>Навык дальнего боя 1-100%, 6-0%.</summary>
        public int RangeSkill { get; set; }

        /// <summary>Кол-во урона в ближнем бою</summary>
        public int RangeDamage { get; set; }

        /// <summary>Дальность хода</summary>
        public int MovePointsTotal { get; set; }

        /// <summary>Дальность хода</summary>
        public int MovePointsCurrent { get; set; } = 0;

        /// <summary>Способности юнита</summary>
        public List<Ability>? Abilities { get; set; }

        /// <summary>
        /// Юнит по умолчанию соответствует Imperium Soldier
        /// </summary>
        public Unit()
        {
            MaxHealth = 4;
            Health = MaxHealth; // полное здоровье
            Price = 50;
            MeleeDamage = 2;
            MovePointsTotal = 3;
            FractionName = "FractionName";
        }

        [System.Text.Json.Serialization.JsonConstructor]
        public Unit(string Name, int PosX, int PosY, Tile? CurrentLocation, string UnitFraction, int Health, int MaxHealth, int Price, 
            bool IsMelee, bool IsRange, int Power, int MeleeAttacks, int MovePoints, List<Ability>? Abilities)
        {
            this.Name = Name;
            this.PosX = PosX;
            this.PosY = PosY;
            this.FractionName = UnitFraction;
            this.Health = Health;
            this.MaxHealth = MaxHealth;
            this.Price = Price;
            this.MeleeDamage = MeleeAttacks;
            //this.MovePoints = MovePoints;
            this.Abilities = Abilities;
        }

        /// <summary>
        /// Обновляет координаты юнита и добавляет юнита в тайл.
        /// </summary>
        /// <param name="t">Tile куда переместить юнита</param>
        /// <returns></returns>
        public void MoveTo(ref Tile t, int changeMovePoints = -1)
        {
            t.AddObj(this);
            PosX = t.PosX;
            PosY = t.PosY;

            if (changeMovePoints == -1)
                return;

            // Проверка на возможность операции нужно реализовать ДО вызова этого метода
            MovePointsCurrent = MovePointsTotal - changeMovePoints;
        }

        /// <summary>
        /// Атака в ближнем бою выделенного юнита
        /// </summary>
        /// <returns>Успех или неуспех</returns>
        public virtual bool MeleeAttack(ref Unit target)
        {
            // Бросаем кубик, чтобы определить, нанесли ли мы урон
            if(UnitUtility.RollDice() > this.MeleeSkill)
            {
                target.Health -= this.MeleeDamage;
                return true;
            }
            // Урон не был нанесен
            return false;
        }

        /// <summary>
        /// Атака в дальнем бою выделенного юнита
        /// </summary>
        /// <returns>Успех или неуспех</returns>
        public virtual bool RangeAttack(ref Unit target)
        {
            // Бросаем кубик, чтобы определить, нанесли ли мы урон
            if (UnitUtility.RollDice() > this.RangeSkill)
            {
                target.Health -= this.RangeDamage;
                return true;
            }
            // Урон не был нанесен
            return false;
        }
    }
}
