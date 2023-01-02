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

        }

        [System.Text.Json.Serialization.JsonConstructor]
        public Soldier(int posX, int posY)
        {
            PosX= posX;
            PosY= posY;
        }

        public override bool MeleeAttack(ref Unit target)
        {
            return false;
        }
    }


}
