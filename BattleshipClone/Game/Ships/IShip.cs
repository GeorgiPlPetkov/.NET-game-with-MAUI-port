using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipClone.Game.Ships
{
    internal interface IShip
    {
        string ShipClass { get; }
        int CenterX { get; }
        int CenterY { get; }
        int[,] Positions { get; }
        int Size { get; }

        void RotateClockwise();
        void MoveTo(int x, int y);
        void MoveBy(int x, int y);

    }
}
