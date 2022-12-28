using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableGame.Units
{
    internal static class UnitUtility
    {
        public static bool IsMovable(Tile t)
        {
            if (t.Passability && t.TileObject == null)
                return true;
            else
                return false;
        }
    }
}
