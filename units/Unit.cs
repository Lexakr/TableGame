﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using TableGame.Abilities;
using TableGame.MapServices;

namespace TableGame.Units
{
    public abstract class Unit : MapObject, IObserver
    {
        /// <summary>Фракция юнита</summary>
        public string FractionName { get; set; }

        /// <summary>Текущий уровень здоровья</summary>
        public int Health { get; set; }

        /// <summary>Максимальное здоровье</summary>
        public int MaxHealth { get; }

        /// <summary>Цена покупки</summary>
        public int Price { set;  get; } = 1;

        /// <summary>Навык ближнего боя 1-100%, 6-0%</summary>
        public int MeleeSkill { get; set; }

        /// <summary>Кол-во урона в ближнем бою</summary>
        public int MeleeDamage { get; set; }

        /// <summary>Навык дальнего боя 1-100%, 6-0%.</summary>
        public int RangeSkill { get; set; }

        /// <summary>Кол-во урона в дальнем бою</summary>
        public int RangeDamage { get; set; }

        /// <summary>Радиус атаки</summary>
        public int AttackRadius { get; set; }

        /// <summary>Дальность хода</summary>
        public int MovePointsTotal { get; set; }

        /// <summary>Дальность хода</summary>
        public int MovePointsCurrent { get; set; } = 0;

        /// <summary>Способности юнита</summary>
        public List<Ability>? Abilities { get; set; }

        public string StringCoordinates { get { return $"x: {PosX}, y: {PosY}"; } }

        /// <summary>
        /// Юнит по умолчанию соответствует Imperium Soldier
        /// </summary>
        public Unit()
        {
            MaxHealth = 4;
            Health = MaxHealth; // полное здоровье
            Price = 50;
            MeleeDamage = 2;
            RangeSkill = 6;
            RangeDamage = 3;
            MovePointsTotal = 3;
            FractionName = "FractionName";
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
            MovePointsCurrent -= changeMovePoints;
        }

        /// <summary>
        /// Атака в ближнем бою выделенного юнита
        /// </summary>
        /// <returns>Успех или неуспех</returns>
        public virtual string MeleeAttack(ref Unit target)
        {
            // Бросаем кубик, чтобы определить, нанесли ли мы урон
            if (this.MeleeSkill >= UnitUtility.RollDice1D6())
            {
                target.Health -= this.MeleeDamage;
                return $"{this.Name}: {this.StringCoordinates} нанес {target.Name}: {target.StringCoordinates} {this.MeleeDamage} урона в ближнем бою";
            }
            // Урон не был нанесен
            return $"{this.Name}: {this.StringCoordinates} не поразил {target.Name}: {target.StringCoordinates}";
        }

        /// <summary>
        /// Атака в дальнем бою выделенного юнита
        /// </summary>
        /// <returns>Успех или неуспех</returns>
        public virtual string RangeAttack(ref Unit target)
        {
            // Бросаем кубик, чтобы определить, нанесли ли мы урон
            if (this.RangeSkill >= UnitUtility.RollDice1D6())
            {
                target.Health -= this.RangeDamage;
                return $"{this.Name}: {this.StringCoordinates} нанес {target.Name}: {target.StringCoordinates} {this.RangeDamage} урона выстрелом";
            }
            // Урон не был нанесен
            return $"{this.Name}: {this.StringCoordinates} не попал в {target.Name}: {target.StringCoordinates}";
        }

        public string Data()
        {
            return GetType().GetProperties()
                .Select(info => (info.Name, Value: info.GetValue(this, null) ?? "(null)"))
                .Aggregate(
                    new StringBuilder(),
                    (sb, pair) => sb.AppendLine($"{pair.Name}: {pair.Value}"),
                    sb => sb.ToString());
        }

        public void Update(ISubject counter)
        {
            MovePointsCurrent = MovePointsTotal;

            if (Abilities != null)
            {
                foreach (PassiveAbility ab in Abilities.Where(x => x is PassiveAbility))
                {
                    ab.ProcessPassiveAbility(this);
                }
            }
        }
    }
}
