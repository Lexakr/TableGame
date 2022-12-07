using System.Text.Json;

namespace TableGame.game
{
    /// <summary>
    /// Класс для загрузки и сохранения игровых сессий.
    /// </summary>
    internal static class GameLoader
    {
        /// <summary>
        /// Загрузка игровой сессии. JSON десериализация из массива байтов UTF-8.
        /// </summary>
        public static Game? LoadGame(string fileName)
        {
            try
            {
                using var stream = new FileStream(fileName, FileMode.Open);
                // Обрабатывать поля, использовать конвертер для 2D массивов
                var options = new JsonSerializerOptions
                {
                    Converters = { new Array2DConverter() },
                    IncludeFields = true
                };
                return JsonSerializer.Deserialize<Game>(stream, options);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                // Возвращаем null как неудачу операции
                return null;
            }
        }
        /// <summary>
        /// Сохранение игровой сессии. JSON сериализация в текст UTF-8.
        /// </summary>
        public static bool SaveGame(Game o, string fileName)
        {
            var options = new JsonSerializerOptions
            {
                IncludeFields = true,
                Converters = { new Array2DConverter() },
            };
            try
            {
                using var stream = new FileStream(fileName, FileMode.Create);
                JsonSerializer.Serialize(stream, o, options);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
