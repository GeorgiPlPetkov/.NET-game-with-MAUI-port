using BattleshipClone.Game.Ships;
using BattleshipClone.Game.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipClone.Game
{
    internal class GameBoard : IGameBoard
    {
        public int BoardWidth { get; private set; }
        public int BoardHeight { get; private set; }


        public Tile[,] Tiles { get; private set; }

        private int ship_index = 0;
        public Ship[] Ships { get; private set; }

        public int TileSize { get; private set; } = 32;

        public GameBoard() {
            BoardWidth = 10;
            BoardHeight = 10;

            Tiles = new Tile[BoardHeight, BoardWidth];
            for (int tile_y = 0; tile_y < BoardWidth; tile_y++)
                for (int tile_x = 0; tile_x < BoardWidth; tile_x++)
                {
                    Tiles[tile_y, tile_x] = Tile.DeepWaterTile();
                }

            Ships = new Ship[8];
        }

        public bool Check(int x, int y)
        {
            throw new NotImplementedException();
        }
        public void AddShip(Ship ship)
        {
            throw new NotImplementedException();
        }
        public void RotateShipClockwise()
        {
            throw new NotImplementedException();
        }
        public void MoveShip(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
