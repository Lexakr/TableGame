﻿using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TableGame.MapServices;
using TableGame.Units;

namespace TableGame
{
    /// <summary>
    /// Состояние клетки для TileAction метода.
    /// Может ли с ней взаимодействовать выделенный юнит
    /// </summary>
    public enum TileStates
    {
        Default,
        /// <summary>Подсветка зеленым тайла, в который может дойти юнит</summary>
        CanMove,
        /// <summary>Подсветка красным тайла, который может атаковать юнит</summary>
        CanAttack,
        /// <summary>В клетке союзник</summary>
        Ally
    }

    /// <summary>
    /// Игровая клетка. В текущей версии вмещает в себя только 1 объект (юнит или структуру).
    /// </summary>
    public partial class Tile : ObservableObject, ICoordinates
    {
        private readonly int posX, posY; // координаты тайла

        [ObservableProperty]
        private MapObject? tileObject; // объект на тайле

        public int PosX { get => posX; }
        public int PosY { get => posY; }

        [ObservableProperty]
        private TileStates state; 

        public string Picture { get; set; }

        /// <summary>
        /// Флаг проходимости тайла
        /// </summary>
        public bool Passability
        {
            get
            {
                if (TileObject == null) 
                    return true;
                else
                    return false;
            }
        }

#if DEBUG
        public string Hash { set;  get; }
#endif

        public string StringCoordinates { get { return $"{PosX},{PosY}"; } }

        public Tile(int posX, int posY)
        {
            tileObject = null;
            this.posX = posX;
            this.posY = posY;
            State = TileStates.Default;

#if DEBUG
            Hash = this.GetHashCode().ToString();
#endif
        }

        [System.Text.Json.Serialization.JsonConstructor]
        public Tile(int posX, int posY, MapObject? tileObject, bool Passability)
        {
            this.posX = posX;
            this.posY = posY;
            this.tileObject = tileObject;
            State = TileStates.Default;
        }

        public void AddObj(MapObject e) => TileObject = e;
        public void RemoveObj() => TileObject = null;

        public bool IsInteractable()
        {
            if (this.tileObject is Unit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
