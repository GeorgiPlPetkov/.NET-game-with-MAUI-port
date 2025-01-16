using BattleshipClone.Game.Ships;
using BattleshipClone.Game.Tiles;

namespace BattleshipClone.Game
{
    internal class GameBoard : IGameBoard
    {
        public int BoardWidth { get; private set; }
        public int BoardHeight { get; private set; }


        public Tile[,] Tiles { get; private set; }

        private int current_ship_count = 0;
        public Ship[] Ships { get; private set; }

        public const int TileSize = 32;

        public GameBoard() {
            BoardWidth = 8;
            BoardHeight = 8;

            Ships = new Ship[6];

            Tiles = new Tile[BoardHeight, BoardWidth];
            for (int tile_y = 0; tile_y < BoardWidth; tile_y++)
                for (int tile_x = 0; tile_x < BoardWidth; tile_x++)
                {
                    Tiles[tile_y, tile_x] = Tile.DeepWaterTile();
                }

            
        }

        // returns the index of the ship on the tile or -1
        public int Check(int x, int y)
        {
            Ship funny_check_ship = new("hehe", 1);
            funny_check_ship.MoveTo(x, y);

            for (int ship_index = 0; ship_index < current_ship_count; ship_index++)
            {
                if (DoShipsIntersect(funny_check_ship, Ships[ship_index]))
                {
                    return ship_index;
                }
            }

            return -1;
        }
        public void AddShip(Ship new_ship)
        {
            Ships[current_ship_count] = new_ship;
            
            for (int ship_index = 0; ship_index < current_ship_count; ship_index++) {
                Ship current_ship = Ships[ship_index];

                while (DoShipsIntersect(new_ship, current_ship)) {
                    new_ship.MoveBy(0, 1);
                }
            }

            current_ship_count++;
        }

        public void MoveShip(Ship ship, int new_x, int new_y)
        {
            int old_x = ship.BowX;
            int old_y = ship.BowY;
            ship.MoveTo(new_x, new_y);


            int attempts = 0;
            while (!IsShipInBounds(ship) || !DoesShipFit(ship)) { 
                ship.RotateClockwise();
                
                if (attempts > 3) {
                    MoveShip(ship, 0, 0);
                    attempts = 0;
                }
                attempts++;
            }
        }
        public void RotateShipClockwise(Ship ship)
        {
            ship.RotateClockwise();

            while (!IsShipInBounds(ship) || !DoesShipFit(ship)) { 
                ship.RotateClockwise(); 
            }
        }

        private bool IsShipInBounds(Ship ship)
        {
            if (ship.BowX < 0 || ship.BowX > BoardWidth || ship.BowY < 0 || ship.BowY > BoardHeight)
                return false;

            if (ship.SternX < 0 || ship.SternX > BoardWidth || ship.SternY < 0 || ship.SternY > BoardHeight)
                return false;

            return true;
        }
        private bool DoesShipFit(Ship ship) {
            for (int ship_index = 0; ship_index < current_ship_count; ship_index++)
            {
                Ship current_ship = Ships[ship_index];
                if (current_ship == ship)
                    continue;

                if (DoShipsIntersect(ship, current_ship))
                    return false;
            }

            return true;
        }
        //Checks if 2 ships intersect, I treat the ships as lines since they don't have any real width
        static bool DoShipsIntersect(Ship ship_1, Ship ship_2)
        {
            // Find the four orientations needed for general and 
            // special cases 
            int o1 = GetOrientation(ship_1.BowX, ship_1.BowY, ship_1.SternX, ship_1.SternY, ship_2.BowX, ship_2.BowY); // s1b, s1s, s2s
            int o2 = GetOrientation(ship_1.BowX, ship_1.BowY, ship_1.SternX, ship_1.SternY, ship_2.SternX, ship_2.SternY); // s1b s1s s2s
            int o3 = GetOrientation(ship_2.BowX, ship_2.BowY, ship_2.SternX, ship_2.SternY, ship_1.BowX, ship_1.BowY); // s2b s2s s1b
            int o4 = GetOrientation(ship_2.BowX, ship_2.BowY, ship_2.SternX, ship_2.SternY, ship_1.SternX, ship_1.SternY); // s2b s2s s1s

            // General case 
            if (o1 != o2 && o3 != o4)
                return true;

            // Special Cases (if the lines are collinear but the points lie directly between them) 
            if (o1 == 0 && CheckSegment(ship_1.BowX, ship_1.BowY, ship_2.BowX, ship_2.BowY, ship_1.SternX, ship_1.SternY)) 
                return true;
           
            if (o2 == 0 && CheckSegment(ship_1.BowX, ship_1.BowY, ship_2.SternX, ship_2.SternY, ship_1.SternX, ship_1.SternY)) 
                return true;
            
            if (o3 == 0 && CheckSegment(ship_2.BowX, ship_2.BowY, ship_1.BowX, ship_1.BowY, ship_2.SternX, ship_2.SternY)) 
                return true;
            
            if (o4 == 0 && CheckSegment(ship_2.BowX, ship_2.BowY, ship_1.SternX, ship_1.SternY, ship_2.SternX, ship_2.SternY)) 
                return true;

            return false; 
        }
        // Check if p2 lies between p1 and 3
        static bool CheckSegment(int p1_x, int p1_y, int p2_x, int p2_y, int p3_x, int p3_y)
        {
            if (p2_x <= Math.Max(p1_x, p3_x) && p2_x >= Math.Min(p1_x, p3_x) &&
                p2_y <= Math.Max(p1_y, p3_y) && p2_y >= Math.Min(p1_y, p3_y))
                return true;

            return false;
        }

        // Funky orientation calculations stolen from the net
        // Here to be exact https://www.geeksforgeeks.org/orientation-3-ordered-points/ 
        // 0 --> p1, p2 and p3 are collinear 
        // 1 --> Clockwise 
        // 2 --> Counterclockwise 
        static int GetOrientation(int p1_x, int p1_y, int p2_x, int p2_y, int p3_x, int p3_y)
        {
            int val = (p2_y - p1_y) * (p3_x - p2_x) -
                    (p2_x - p1_x) * (p3_y - p2_y);

            if (val == 0) return 0; // collinear 

            return (val > 0) ? 1 : 2; // clock or counterclock wise 
        }
    }
}
