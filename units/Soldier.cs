using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableGame.Units
{
    internal class Soldier : Unit
    {
        public Soldier() 
        {
            PosX = 1;
            PosY = 1;
        }

        [System.Text.Json.Serialization.JsonConstructor]
        public Soldier(int posX, int posY)
        {
            PosX= posX;
            PosY= posY;
        }

        public override void Attack()
        {

        }
    }


}
