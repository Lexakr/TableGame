using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableGame.Units;

namespace TableGame.Fractions
{
    internal class Orks : Fraction
    {
        public override string Name { get; } = "Орки";

        public override List<Type> FractionUnits { get; } = new List<Type>
        {
            typeof(SoldierOrks),
        };
    }
}
