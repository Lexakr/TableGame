using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableGame.MapServices
{
    internal interface ICoordinates
    {
        public int PosX { get; }
        public int PosY { get; }

        string GetLocation()
        {
            return PosX.ToString() + "," + PosY.ToString();
        }
    }

    internal interface IMovable
    {
        public (int, int) Location { get; set; }
        // Метод, изменяющий расположение исходя из направления и скорости движения
        public void Move()
        {
            ///
        }
    }
}
