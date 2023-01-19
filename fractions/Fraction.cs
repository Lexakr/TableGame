using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TableGame.Units;

namespace TableGame.Fractions
{
    public abstract class Fraction
    {
        /// <summary>
        /// Имя фракции
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Список типов юнитов фракции
        /// </summary>
        [JsonIgnore]
        public abstract List<Type> FractionUnits { get; }
    }
}
