using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableGame.Units;

namespace TableGame.MapServices
{
    internal class MapStat
    {
        public string Size { get; set; }
        public List<Unit?> Units { get; set; }

        public MapStat(Map map) 
        {
            Size = "Map size: " + map.Size_x + "*" + map.Size_y;
            Units = new List<Unit?>();
        }

        [System.Text.Json.Serialization.JsonConstructor]
        public MapStat(string Size, List<Unit?> Units)
        { 
            this.Size = Size;
            this.Units = Units;
        }
        public void ShowMapStats(Map map)
        {
            /*Units = GetUnits(map);
            Console.WriteLine(Size);
            // TODO нормальный вывод объектов
            Console.WriteLine("Units on map: " + GetUnits(map).Count());
            foreach(Unit unit in Units)
            {
                if (unit is ICoordinates i)
                {
                    Console.WriteLine("Unit {0} location: " + i.GetLocation(), unit.Name);
                }
                
            }*/
            
        }

        // Получение списка всех Unit на карте
        /*public List<Unit?> GetUnits(Map map)
        {
            // реализовать через LINQ, мб в одну строку
            List<Unit?> tmp = new();
            foreach (Tile tile in map.Tiles)
            {
                if(tile.TileObject != null && tile.TileObject is Unit)
                {
                    tmp.Add((Unit?)tile.TileObject);
                }
            }
            return tmp;
            *//*            return map.Tiles
                            .Where(x => x.TileObject != null)
                            .ToList();*/

/*            for (int i = 0; i < map.Size_x; i++) // та же логика что сверху
            {
                for (int j = 0; j < map.Size_y; j++)
                {
                    Unit? ob = map.Coordinates[i, j].TileObject;
                    if (ob != null)
                        Units.Add(ob);
                }
            }
            return Units;*//*
        }*/
    }
}
