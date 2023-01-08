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

        /// <summary>
        /// Конструктор для любого объекта по умолчанию. Отрицательные координаты
        /// означают, что объект еще не помещен на карту и его локация null
        /// </summary>
        public MapObject()
        {
            Name = "Name";
        }

        [System.Text.Json.Serialization.JsonConstructor]
        public MapObject(string name, int posX, int posY, Tile? currentLocation)
        {
            Name = name;
            PosX = posX;
            PosY = posY;
        }
    }
}
