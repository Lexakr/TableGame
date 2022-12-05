using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableGame.units;

namespace TableGame.map
{
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

        // Creates an instance of a map with a user-defined size
        public Map(int size_x, int size_y, string name)
        {
            this.name = name;
            this.size_x = size_x;
            this.size_y = size_y;
            coordinates = new Tile[size_x, size_y];
            for (int i = 0; i < size_x; i++)
            {
                for (int j = 0; j < size_y; j++)
                {
                    coordinates[i, j] = new Tile(i, j);
                    tiles.Add(coordinates[i, j]);
                }
            }
        }

        public void AddObject(IMapObject o)
        {
            int x = o.PosX;
            int y = o.PosY;
            coordinates[x, y].TileObject = o;
        }

        public void RemoveObject(IMapObject o)
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
