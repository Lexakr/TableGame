using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableGame.game
{
    internal class GameStat
    {
        public int MovesNum { get; }
        public int Points { get; set; }
        public GameStat(int movesNum)
        {
            MovesNum = movesNum;
            Points = 0;
        }
    }
}
