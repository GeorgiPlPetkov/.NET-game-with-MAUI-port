namespace BattleshipClone.Game.Ships
{
    public class Ship : IShip
    {
        public string ShipClass { get; private set; }
        public int Size { get { return Positions.GetLength(0); } } 

        public int BowX { 
            get { return Positions[0, 0]; } 
            private set { Positions[0, 0] = value; } 
        }
        public int BowY {
            get { return Positions[0, 1]; }
            private set { Positions[0, 1] = value; }
        }

        public int SternX
        {
            get { return Positions[Size - 1, 0]; }
            private set { Positions[Size - 1, 0] = value; }
        }
        public int SternY
        {
            get { return Positions[Size - 1, 1]; }
            private set { Positions[Size - 1, 1] = value; }
        }

        public int[,] Positions { get; private set; }
        public Ship(string ship_class, int size)
        {
            ShipClass = ship_class;
            
            Positions = new int[size, 2];
            for (int pos_index = 0; pos_index < size; pos_index++) { 
                Positions[pos_index, 0] = pos_index;
                Positions[pos_index, 1] = 0;
            }
        }

        
        public static Ship Destroyer()
        {
            return new Ship("Destroyer", 2);
        }
        public static Ship Cruiser()
        {
            return new Ship("Cruiser", 3);
        }
        public static Ship Battleship()
        {
            return new Ship("Battleship", 4);
        }

        public void MoveBy(int x, int y)
        {
            for (int pos_index = 0; pos_index < Size; pos_index++)
            {
                Positions[pos_index, 0] += x;
                Positions[pos_index, 1] += y;
            }
        }
        public void MoveTo(int x, int y)
        {
            int x_offset = x - BowX;
            int y_offset = y - BowY;
            
            MoveBy(x_offset, y_offset);
        }
        public void RotateClockwise()
        {
            int x = SternX;
            int y = SternY;

            MoveTo(0, 0);

            for (int pos_index = 0; pos_index < Size; pos_index++) {
                int temp = Positions[pos_index, 0];
                Positions[pos_index, 0] = Positions[pos_index, 1];
                Positions[pos_index, 1] = -temp;
            }
            MoveTo(x, y);
        }
    }
}
