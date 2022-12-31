using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableGame.Units;

namespace TableGame.Fractions
{
    abstract public class Fraction
    {
        public string Name { get; set; }
        public List<Unit> FractionUnits { get; set; }

        public Fraction() { }
        [System.Text.Json.Serialization.JsonConstructor]
        public Fraction (string name, List<Unit> fractionUnits)
        {
            Name = name;
            FractionUnits = fractionUnits;
        }

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
