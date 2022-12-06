using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableGame
{
    /// <summary>
    /// Интерфейс Команды объявляет метод для выполнения команд.
    /// </summary>
    internal interface ICommand
    {
        void Execute();
    }
}
