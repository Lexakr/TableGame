using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TableGame
{
    internal class Tile : ICoordinates
    {
        private readonly int posX, posY;
        private IMapObject? tileObject;

        public int PosX { get => posX; }
        public int PosY { get => posY; }
        public IMapObject? TileObject { get => tileObject; set => tileObject = value; } // TODO обработка если тайлобжекта нет
        public bool Passability { get; set; } // флаг проходимости тайла

        public Tile(int posX, int posY)
        {
            tileObject = null;
            Passability = true; // пустой тайл всегда проходим
            this.posX = posX;
            this.posY = posY;
        }

/*        public void AddObject(IMapObject e)
        {
            //objects.Add(e);
        }
        public void RemoveObject(IMapObject e)
        {
            //objects.Remove(e);
        }*/
    }
}
