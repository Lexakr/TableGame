using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableGame.fractions
{
    abstract internal class Fraction
    {
        public string Name { get; set; }
        public List<string> UnitsList { get; set; }
        protected Fraction() 
        {
            Name = "Fraction";
        }

        public void FractionInfo()
        {
            Console.WriteLine("Fraction: " + Name);
        }

    }

    internal class Imperium : Fraction
    {
        public Imperium()
        {
            Name = "Imperium of Man";
        }
    }

    internal class Orks : Fraction 
    {
        public Orks()
        {
            Name = "Orks";
        }
        
    }
}
