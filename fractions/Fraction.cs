using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableGame.units;

namespace TableGame.fractions
{
    abstract internal class Fraction
    {
        public string Name { get; set; }
        public List<Unit> FractionUnits { get; set; }

        public void ShowFractionUnits()
        {
            Console.WriteLine("Fraction: " + Name);
        }

    }

    internal class Imperium : Fraction
    {
        public Imperium()
        {
            Name = "Imperium";
            FractionUnits = new List<Unit>
            {
                new SoldierImperium(),
                // ...
            };
        }
    }

    internal class Orks : Fraction 
    {
        public Orks()
        {
            Name = "Orks";
            FractionUnits = new List<Unit> 
            { 
                new SoldierOrks(), 
            };
        }
        
    }
}
