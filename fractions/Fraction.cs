using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableGame.Units;

namespace TableGame.Fractions
{
    public abstract class Fraction
    {
        /// <summary>
        /// Имя фракции
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список типов юнитов фракции
        /// </summary>
        public List<Type> FractionUnits { get; set; } = new();

        public Fraction() { }

        [System.Text.Json.Serialization.JsonConstructor]
        public Fraction (string name)
        {
            Name = name;
        }
    }
}
