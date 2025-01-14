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

        private int current_ship_index = 0;
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
            Ships[current_ship_index] = ship;
            current_ship_index++;
        }

        public void MoveShip(int x, int y)
        {
            Ships[current_ship_index].MoveTo(x, y);

            if (IsShipInBounds(Ships[current_ship_index])) { 
                
            }
        }
        public void RotateShipClockwise()
        {
            Ships[current_ship_index].RotateClockwise();
        }
        

        private bool IsShipInBounds(Ship ship) {
            int x_bow = ship.Positions[0, 0];
            int y_bow = ship.Positions[0, 1];

            int x_stern = ship.Positions[ship.Positions.Length, 0];
            int y_stern = ship.Positions[ship.Positions.Length, 1];

            return IsPointInBounds(x_bow, y_bow) && IsPointInBounds(x_stern, y_stern); 
        }

        private bool IsPointInBounds(int x, int y)
        {
            return (x >= 0 && x <= BoardWidth && y >= 0 && y <= BoardHeight);
        }
    }
}
