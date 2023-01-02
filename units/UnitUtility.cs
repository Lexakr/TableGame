using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableGame.Units
{
    internal static class UnitUtility
    {
        public static bool IsMovable(this Tile t)
        {
            if (t.Passability && t.TileObject == null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Подброс кубика 1D6
        /// </summary>
        /// <returns>Выпавшее число</returns>
        public static int RollDice()
        {
            return new Random().Next(1, 7);
        }
    }
}
