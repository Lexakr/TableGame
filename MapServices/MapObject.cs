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
        public Tile? CurrentLocation { get; set; } // ref to Tile
        public string Picture { get; set; }

        /// <summary>
        /// Конструктор для любого объекта по умолчанию. Отрицательные координаты
        /// означают, что объект еще не помещен на карту и его локация null
        /// </summary>
        public MapObject()
        {
            Name = "Name";
            CurrentLocation = null;
        }

        [System.Text.Json.Serialization.JsonConstructor]
        public MapObject(string name, int posX, int posY, Tile? currentLocation)
        {
            Name = name;
            PosX = posX;
            PosY = posY;
            CurrentLocation = currentLocation;
        }

        /// <summary>
        /// Описание объекта и его характеристики
        /// </summary>
        //TODO: public abstract string Desciption { get; set; }
    }
}
