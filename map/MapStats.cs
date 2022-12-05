using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableGame.map
{
    internal class MapStats
    {
        List<IMapObject?> Objects { get; set; }
        public MapStats(Map map) 
        {
            Objects = new List<IMapObject?>();
        }
        public void ShowMapStats(Map map)
        {
            // TODO нормальный вывод объектов
            Console.WriteLine("Map objects: " + GetMapObjects(map));
        }

        // Получение списка всех объектов на карте
        public List<IMapObject?> GetMapObjects(Map map)
        {
            return map.Coordinates.Cast<IMapObject?>().Where(x => x != null).ToList();

/*            for (int i = 0; i < map.Size_x; i++) // та же логика что сверху
            {
                for (int j = 0; j < map.Size_y; j++)
                {
                    IMapObject? ob = map.Coordinates[i, j].TileObject;
                    if (ob != null)
                        objects.Add(ob);
                }
            }
            return objects;*/
        }
    }
}
