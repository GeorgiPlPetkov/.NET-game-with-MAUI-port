using BattleshipClone.Game.Ships;
using BattleshipClone.Game.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipClone.Game
{
    internal interface IGameBoard
    {
        int BoardWidth { get; }
        int BoardHeight { get; }
        
        Tile[,] Tiles { get; }
        Ship[] Ships { get; }

        int GetShipIndexFromCoordinates(int x, int y);

        void AddShip(Ship ship);
        void RotateShipClockwise(Ship ship);
        void MoveShip(Ship ship, int x, int y);
    }
}
