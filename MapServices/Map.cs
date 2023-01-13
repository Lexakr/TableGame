using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableGame.Structures;
using TableGame.Units;
using Windows.Networking.Vpn;

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
        /// /// <param name="genRandomStructure">Указать квадрат например 5х5 = 5. Генерации структур</param>
        public Map(int size_x, int size_y, string name, int genRandomStructure)
        {
            this.name = name;
            this.size_x = size_x;
            this.size_y = size_y;
            tiles = TileCreator(size_x, size_y);

            // добавить случайные структуры на карту зонами 5х5
            StructureGeneratorOnMap(genRandomStructure);
        }

        [System.Text.Json.Serialization.JsonConstructor]
        public Map(int size_x, int size_y, string name, List<List<Tile>> coordinates)
        {
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
                    newListX.Add(new Tile(x + 1, y + 1));
                }

                newMap.Add(newListX);
            }

            return newMap;
        }

        /// <summary>
        /// Генерация структур на карте. Блочная. Int указывает зону (квадрат)
        /// где будет структура например 5х5 = 5
        /// </summary>
        private void StructureGeneratorOnMap(int sideOfSquare)
        {
            var test = Math.Ceiling(Convert.ToDecimal(Tiles.Count) / sideOfSquare);

            // по Х
            var blockX = 0;

            // приведение к большему числу - чтобы на границах поля корректно формировались структуры
            for (int i = 0; i < Math.Ceiling(Convert.ToDecimal(Tiles.Count) / sideOfSquare); i++)
            {
                // спускаемся ниже
                var blockY = 0;

                for (int j = 0; j < Math.Ceiling(Convert.ToDecimal(Tiles[0].Count) / sideOfSquare); j++)
                {
                    var x = new Random().Next(0, sideOfSquare) + blockX;
                    var y = new Random().Next(0, sideOfSquare) + blockY;

                    if (x >= Tiles.Count || y >= Tiles[0].Count)
                    {
                        blockY += sideOfSquare;
                        continue;
                    }

                    Tiles[x][y].AddObj(new Rock());

                    blockY += sideOfSquare;
                }

                blockX += sideOfSquare;
            }

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
