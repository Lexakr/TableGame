using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TableGame.MapServices;
using TableGame.Units;

namespace TableGame
{
    /// <summary>
    /// Игровая клетка. В текущей версии вмещает в себя только 1 объект (юнит или структуру).
    /// 
    /// </summary>
    internal class Tile : ICoordinates
    {
        private readonly int posX, posY; // координаты тайла
        private MapObject? tileObject; // объект на тайле

        public int PosX { get => posX; }
        public int PosY { get => posY; }
        public MapObject? TileObject { get => tileObject; set => tileObject = value; } // TODO обработка если тайлобжекта нет
        public bool Passability { get; set; } // флаг проходимости тайла, заготовка на будущее?

#if DEBUG
        public string Hash { set;  get; }
#endif

        public string StringCoordinates { get { return $"{PosX},{PosY}"; } }

        public Tile(int posX, int posY)
        {
            tileObject = null;
            Passability = true; // пустой тайл всегда проходим
            this.posX = posX;
            this.posY = posY;

#if DEBUG
            Hash = this.GetHashCode().ToString();
#endif
        }

        [System.Text.Json.Serialization.JsonConstructor]
        public Tile(int posX, int posY, MapObject? tileObject, bool Passability)
        {
            this.posX = posX;
            this.posY = posY;
            this.tileObject = tileObject;
            this.Passability = Passability;
        }

        public void AddObj(MapObject e) => tileObject = e;
        public void RemoveObj() => tileObject = null;

        public bool IsInteractable()
        {
            if (this.tileObject is Unit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
