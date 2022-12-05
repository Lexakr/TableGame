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
        private IMapObject tileObject;


        public int PosX { get => posX; }
        public int PosY { get => posY; }
        public IMapObject TileObject { get; set; }
        public string Type { get; set; }

        public Tile(int xPos, int yPos)
        {
            this.posX = xPos;
            this.posY = yPos;
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
