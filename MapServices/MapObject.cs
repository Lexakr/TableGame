using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableGame.MapServices
{
    public abstract class MapObject : ICoordinates
    {
        public string Name { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public string Icon { get; set; }
    }
}
