using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableGame.Structures
{
    internal class Rock : Structure
    {
        public Rock()
        {
            Icon = "/Resources/Rocks/rock" + new Random().Next(1, 5).ToString() + ".png";
        }
    }
}
