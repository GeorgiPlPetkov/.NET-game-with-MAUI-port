using BattleshipClone.Game.Ships;
using BattleshipClone.Game.Tiles;

namespace BattleshipClone.Game
{
    internal class GameBoard : IGameBoard
    {
        public int BoardWidth { get; private set; }
        public int BoardHeight { get; private set; }


        public Tile[,] Tiles { get; private set; }

        private int current_ship_index = 0;
        public Ship[] Ships { get; private set; }

        public const int TileSize = 32;

        public GameBoard() {
            BoardWidth = 8;
            BoardHeight = 8;

            Tiles = new Tile[BoardHeight, BoardWidth];
            for (int tile_y = 0; tile_y < BoardWidth; tile_y++)
                for (int tile_x = 0; tile_x < BoardWidth; tile_x++)
                {
                    Tiles[tile_y, tile_x] = Tile.DeepWaterTile();
                }

            Ships = new Ship[5];
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

        public void MoveShip(int new_x, int new_y)
        {
            IShip ship = Ships[current_ship_index];
            
            int x_bow = ship.Positions[0, 0];
            int y_bow = ship.Positions[0, 1];

            int x_stern = ship.Positions[ship.Positions.Length, 0];
            int y_stern = ship.Positions[ship.Positions.Length, 1];

            int x_offset = ship.CenterX - new_x;
            int y_offset = ship.CenterY - new_y;
            if (IsPointInBounds(x_bow + x_offset, y_bow + y_offset) 
                && IsPointInBounds(x_stern + x_offset, y_stern + y_offset)) { 
                ship.MoveTo(new_x, new_y);
            }
        }
        public void RotateShipClockwise()
        {
            Ships[current_ship_index].RotateClockwise();
        }

        private bool IsPointInBounds(int x, int y)
        {
            return (x >= 0 && x <= BoardWidth && y >= 0 && y <= BoardHeight);
        }
    }
}
