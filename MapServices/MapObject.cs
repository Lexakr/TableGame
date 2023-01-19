using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableGame.MapServices
{
    public abstract class MapObject : ICoordinates
    {
        public virtual string Name { get; set; } = "Map Object";
        public int PosX { get; set; }
        public int PosY { get; set; }
        public virtual string Icon { get; set; } = string.Empty;
    }
}
