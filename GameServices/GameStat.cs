using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableGame.GameServices
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

        [System.Text.Json.Serialization.JsonConstructor]
        public GameStat(int MovesNum, int Points)
        {
            this.MovesNum = MovesNum;
            this.Points = Points;
        }
    }
}
