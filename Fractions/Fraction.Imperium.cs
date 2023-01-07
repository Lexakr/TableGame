using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableGame.Units;

namespace TableGame.Fractions
{
    internal class Imperium : Fraction
    {
        public Imperium()
        {
            Name = "Империум Человечества";

            FractionUnits = new List<Type>
            {
                typeof(SoldierImperium),
            };
        }
    }
}
