using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace TableGame.GameServices
{
    /// <summary>
    /// Класс для загрузки и сохранения игровых сессий.
    /// </summary>
    internal static class GameLoader
    {
        /// <summary>
        /// Загрузка игровой сессии. JSON десериализация из массива байтов UTF-8.
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <returns>Экземпляр Game или null, если неуспех</returns>
        public static Game? LoadGame(string fileName)
        {
            try
            {
                using StreamReader stream = File.OpenText(fileName);
                // Обрабатывать поля, использовать конвертер для 2D массивов
                //var options = new JsonSerializerOptions
                //{
                //    IncludeFields = true,
                //    PropertyNameCaseInsensitive = true,
                //    WriteIndented = true,
                //};
                JsonSerializer serializer = new();
                serializer.TypeNameHandling = TypeNameHandling.Auto;
                
                return (Game)serializer.Deserialize(stream, typeof(Game));
                //return JsonSerializer.Deserialize<Game>(stream, settings);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка загрузки");
                // Возвращаем null как неудачу операции
                return null;
            }
        }
        /// <summary>
        /// Сохранение игровой сессии. JSON сериализация в текст UTF-8.
        /// </summary>
        public static bool SaveGame(Game o, string fileName)
        {
            //var options = new JsonSerializerOptions
            //{
            //    IncludeFields = true,
            //    PropertyNameCaseInsensitive = true,
            //    WriteIndented = true,
            //};
            try
            {
                // serialize JSON directly to a file
                using StreamWriter file = File.CreateText(fileName);
                JsonSerializer serializer = new JsonSerializer();
                serializer.TypeNameHandling = TypeNameHandling.Auto;
                serializer.Formatting = Formatting.Indented;
                serializer.Serialize(file, o);
                return true;
                //using var stream = new FileStream(fileName, FileMode.Create);
                //JsonSerializer.Serialize(stream, o, options);
                //return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка сохранения");
                return false;
            }
        }
    }
}
