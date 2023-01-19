using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TableGame.Units;

namespace TableGame.Fractions
{
    internal class Imperium : Fraction
    {
        public override string Name { get; } = "Империум Человечества";

        public override List<Type> FractionUnits { get; } = new List<Type>
        {
            typeof(SoldierImperium),
        };
    }
}
