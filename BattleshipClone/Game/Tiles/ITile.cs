using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipClone.Game.Tiles
{
    internal interface ITile
    {
        string TileType { get; }
        int DepthIndex { get; }
    }
}
