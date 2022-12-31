using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableGame.Units;

namespace TableGame.MapServices
{

    internal class Map
    {
        private readonly string name;
        private readonly List<List<Tile>> tiles;
        //private readonly List<Tile> tiles = new();
        private readonly int size_x, size_y;
        public string Name { get => name; }
        public List<List<Tile>> Tiles { get => tiles; }
        //public List<Tile> Tiles { get => tiles; }
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
            tiles = TileCreator(size_x, size_y);
        }

        [System.Text.Json.Serialization.JsonConstructor]
        public Map(int size_x, int size_y, string name, List<List<Tile>> coordinates)
        {
            tiles = new();

            this.name = name;
            this.size_x = size_x;
            this.size_y = size_y;
            this.tiles = coordinates;
        }

        //public Map()
        public List<List<Tile>> TileCreator(int size_x, int size_y)
        {
            var newMap = new List<List<Tile>>();

            for (int x = 0; x < size_x; x++)
            {
                var newListX = new List<Tile>();

                for (int y = 0; y < size_y; y++)
                {
                    // DEBUG - PLEASE DELETE
                    if(y == 6)
                    {
                        newListX.Add(new Tile(x + 1, y + 1) { TileObject = new SoldierImperium() });
                        continue;
                    }
                    if (y == 8)
                    {
                        newListX.Add(new Tile(x + 1, y + 1) { TileObject = new SoldierOrks() });
                        continue;
                    }

                    newListX.Add(new Tile(x + 1, y + 1));
                }

                newMap.Add(newListX);
            }
            return newMap;
        }

        public void AddObject(MapObject o)
        {
            int x = o.PosX;
            int y = o.PosY;
            //tiles[x, y].TileObject = o;
        }

        public void RemoveObject(MapObject o)
        {
            int x = o.PosX;
            int y = o.PosY;
            //tiles[x, y].TileObject = null;
        }

        public void SetTileType(int x, int y, string type)
        {

        }


    }
}
