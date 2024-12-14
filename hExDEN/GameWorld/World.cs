using hExDEN.GameWorld.Hats;
using System.Collections;
using System.Numerics;
namespace hExDEN.GameWorld
{
    public class World
    {
        public const int TileSize = 32; 

        public int Radius { get; private set; }
        public Dictionary<Vector2, Tile> Tiles { get; private set; }

        public IHat[] Hats { get; private set; }
        
        public World(Dictionary<Vector2, Tile> tiles, IHat[] hats) 
        { 
            Tiles = tiles;
            Hats = hats;
        }

        public static World GenerateWorld(int radius, int number_of_hats)
        {
            Dictionary<Vector2, Tile> new_world_tiles = new();
            Vector2 space_position = new();
            Vector2 absolute_position = new();
            for (int q = 0; q < radius; q++)
                for (int r = 0; r < radius; r++)
                {
                    absolute_position = new(q, r);
                    space_position = OffsetForHexagons(q * TileSize, r * TileSize, r % 2 != 0);
                    new_world_tiles.Add(absolute_position, Tile.BlankTile(space_position, null));
                }
            
            IHat[] hats = new IHat[number_of_hats];
            
            World newWorld = new(new_world_tiles, hats);
            newWorld.Radius = radius;
            return newWorld;
        }

        private static Vector2 Get2dCoords(Vector2 axial_position) 
        { 
            int offset_on_odds = Math.Abs(axial_position.Y) % 2 < 1 ? 1 : 0;
            
            float eoX = axial_position.X + ((axial_position.Y - offset_on_odds) / 2);
            float eoY = axial_position.Y;
            
            return new Vector2(eoX, eoY); 
        }
        private static Vector2 OffsetForHexagons(int q, int r, bool isRowOdd)
        {
            float q_offset = isRowOdd ? TileSize * .5f : 0;
            float r_offset = isRowOdd ? TileSize * .25f : 0;
            
            float hex_q = q + q_offset;
            float hex_r = r - r_offset;
            
            return new Vector2(hex_q, hex_r);
        }
    }
}
