using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipClone.Game.Tiles
{
    public class Tile : ITile
    {
        public string TileType { get; private set; }
        public int DepthIndex { get; private set; }

        public Tile(string tile_type, int depth_index)
        {
            TileType = tile_type;
            DepthIndex = depth_index;
        }

        public static Tile PlayerTile() 
        {
            return new Tile("player_water", 2);
        }

        public static Tile EnemyTile() {
            return new Tile("enemy_water", 2);
        }
    }
}
