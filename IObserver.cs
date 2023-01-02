using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace TableGame
{
    public interface IObserver
    {
        // Получает обновление от издателя
        void Update(ISubject subject);
    }
}
