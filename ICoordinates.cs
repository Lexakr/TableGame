﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableGame
{
    internal interface ICoordinates
    {
        public int PosX { get; }
        public int PosY { get; }

        string GetLocation()
        {
            return PosX.ToString() + "," + PosY.ToString();
        }
    }
}
