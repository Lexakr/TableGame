using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TableGame
{
    internal class GameLoader
    {
        public bool LoadGame(string fileName)
        {
            try
            {
                byte[] jsonUtf8Bytes = File.ReadAllBytes(fileName);
                // перегрузка десериализации (из документации)
                var utf8Reader = new Utf8JsonReader(jsonUtf8Bytes);
                Game? loadedGame = JsonSerializer.Deserialize<Game>(ref utf8Reader);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool SaveGame(Game o, string fileName)
        {
            _ = new JsonSerializerOptions { IncludeFields = true }; // сериализация для полей
            try
            {
                byte[] jsonString = JsonSerializer.SerializeToUtf8Bytes(o); // на 5-10% быстрее, чем строковый метод
                File.WriteAllBytes(fileName, jsonString);
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
