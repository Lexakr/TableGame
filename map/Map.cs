using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableGame.units;

namespace TableGame.map
{
    /// <summary>
    /// 
    /// </summary>
    internal class Map
    {
        private readonly string name;
        private readonly Tile[,] coordinates;
        private readonly List<Tile> tiles = new();
        private readonly int size_x, size_y;
        public string Name { get => name; }
        public Tile[,] Coordinates { get => coordinates; }
        public List<Tile> Tiles { get => tiles; }
        public int Size_x { get => size_x; }
        public int Size_y { get => size_y; }

        /// <summary>
        /// Creates an instance of a map with a user-defined size
        /// </summary>
        /// <param name="size_x">ширина</param>
        /// <param name="size_y">высота</param>
        /// <param name="name">имя</param>
        public Map(int size_x, int size_y, string name)
        {
            this.name = name;
            this.size_x = size_x;
            this.size_y = size_y;
            coordinates = TileCreator(size_x, size_y);
        }

        [System.Text.Json.Serialization.JsonConstructor]
        public Map(int size_x, int size_y, string name, Tile[,] coordinates)
        {
            this.name = name;
            this.size_x = size_x;
            this.size_y = size_y;
            this.coordinates = coordinates;
        }

        //public Map()
        public Tile[,] TileCreator(int size_x, int size_y)
        {
            Tile[,] newMap = new Tile[size_x, size_y];
            for (int i = 0; i < size_x; i++)
            {
                for (int j = 0; j < size_y; j++)
                {
                    newMap[i, j] = new Tile(i, j);
                    tiles.Add(newMap[i, j]);
                }
            }
            return newMap;
        }

        public void AddObject(MapObject o)
        {
            int x = o.PosX;
            int y = o.PosY;
            coordinates[x, y].TileObject = o;
        }

        public void RemoveObject(MapObject o)
        {
            int x = o.PosX;
            int y = o.PosY;
            coordinates[x, y].TileObject = null;
        }

        public void SetTileType(int x, int y, string type)
        {

        }


    }
}
