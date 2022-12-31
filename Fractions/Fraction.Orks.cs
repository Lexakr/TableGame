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
        public Orks()
        {
            Name = "Orks";
            FractionUnits = new List<Type>
            {
                typeof(SoldierOrks),
            };
        }

    }
}
