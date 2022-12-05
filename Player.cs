using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableGame.units;

namespace TableGame
{
    internal class Player
    {
        public string PlayerName { get; set; }
        public string PlayerFraction { get; set; }
        public List<Unit> PlayerUnits { get; set; }

    }
}
