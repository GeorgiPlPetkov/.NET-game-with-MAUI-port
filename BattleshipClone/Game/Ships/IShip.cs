using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipClone.Game.Ships
{
    public interface IShip
    {
        string ShipClass { get; }
        
        int BowX { get; }
        int BowY { get; }
        int SternX { get; }
        int SternY { get; }

        int[,] Positions { get; }
        int Size { get; }

        void RotateClockwise();
        void MoveTo(int x, int y);
        void MoveBy(int x, int y);

    }
}
