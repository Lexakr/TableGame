using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;
using Windows.Networking.Sockets;

namespace TableGame
{
    enum LogLevel
    {
        Info,
        Debug,
        Warning,
        Error,
        Fatal
    }

    public class Logger
    {
        private static readonly Logger instance = new Logger();

        public ObservableCollection<string> Logs { get; private set; }

        /// <summary>
        /// Поле чисто для ИНФО сообщений - для отображения в интерфейс
        /// </summary>
        public ObservableCollection<string> LogsOnlyInfo { get; private set; }

        public Logger()
        {
            Logs = new ObservableCollection<string>();
            LogsOnlyInfo = new ObservableCollection<string>();

/*            for (int i = 0; i < 200; i++)
                Info("test");*/
        }

        public static Logger GetInstance()
        {
            return instance;
        }

        private void Add (string message, LogLevel level, ConsoleColor color)
        {
            var normalMessage = $"[{level.ToString()}] [{DateTime.Now}] {message}";

            Logs.Add(normalMessage);

            if(LogLevel.Info == level)
                LogsOnlyInfo.Add ($"{DateTime.Now} - {message}");

            Console.WriteLine(normalMessage, color);
        }

        public void Info(string message) => Add(message, LogLevel.Info, ConsoleColor.White);

        public void Debug(string message) => Add(message, LogLevel.Debug, ConsoleColor.DarkGreen);

        public void Warn(string message) => Add(message, LogLevel.Warning, ConsoleColor.DarkYellow);

        public void Error(string message) => Add(message, LogLevel.Error, ConsoleColor.Red);

        public void Fatal(string message) => Add(message, LogLevel.Fatal, ConsoleColor.DarkRed);
    }
}
