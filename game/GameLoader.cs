using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.Json.Serialization;
using TableGame.game;

namespace TableGame.game
{
    internal static class GameLoader
    {
        /// <summary>
        /// Загрузка игровой сессии. JSON десериализация из массива байтов UTF-8.
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <returns></returns>
        public static Game LoadGame(string fileName)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    Converters = { new Array2DConverter() },
                };
                string jsonUtf8Bytes = File.ReadAllText(fileName);
                // перегрузка десериализации (из документации)
                //var utf8Reader = new Utf8JsonReader(jsonUtf8Bytes);
                Game loadedGame = JsonSerializer.Deserialize<Game>(jsonUtf8Bytes, options);
                return loadedGame;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Сохранение игровой сессии. JSON сериализация в массив байтов UTF-8.
        /// </summary>
        /// <remarks>
        /// UTF-8 сокращает временные затраты на 5-10%.
        /// </remarks>
        /// <param name="o">Сессия для сохранения</param>
        /// <param name="fileName">Имя файла</param>
        /// <returns></returns>
        public static bool SaveGame(Game o, string fileName)
        {
            //_ = new JsonSerializerOptions { IncludeFields = true };
            var options = new JsonSerializerOptions
            {
                Converters = { new Array2DConverter() },
            };
            try
            {
                string jsonString = JsonSerializer.Serialize(o, options);
                //byte[] jsonString = JsonSerializer.SerializeToUtf8Bytes(o, options);
                File.WriteAllText(fileName, jsonString);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in serialization: " + e.Message);
                return false;
            }
        }
    }
}
