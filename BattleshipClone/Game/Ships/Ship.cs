using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipClone.Game.Ships
{
    internal class Ship : IShip
    {
        public string ShipClass { get; private set; }
        public int Size { get; private set; }

        private int center_index;
        public int CenterX { 
            get { return Positions[center_index, 0]; } 
            private set { Positions[center_index, 0] = value; } 
        }
        public int CenterY {
            get { return Positions[center_index, 1]; }
            private set { Positions[center_index, 1] = value; }
        }

        public int[,] Positions { get; private set; }
        public Ship(string ship_class, int x, int y, int size)
        {
            ShipClass = ship_class;
            Size = size;

            center_index = size / 2;

            Positions = new int[size, 2];

            CenterX = x;
            CenterY = y;

            SetPositions();
        }

        private void SetPositions()
        {
            for (int pos_index = center_index - 1; pos_index >= 0; pos_index--)
            {
                Positions[pos_index, 0] = CenterX - pos_index;
                Positions[pos_index, 1] = CenterY;
            }

            for (int pos_index = center_index + 1; pos_index < Size; pos_index++)
            {
                Positions[pos_index, 0] = CenterX + pos_index;
                Positions[pos_index, 1] = CenterY;
            }
        }
        public static Ship Destroyer()
        {
            return new Ship("destroyer", 1, 0, 2);
        }
        public static Ship Cruiser()
        {
            return new Ship("cruiser", 2, 0, 3);
        }
        public static Ship Carrier()
        {
            return new Ship("carrier", 3, 0, 4);
        }
        public static Ship Battleship()
        {
            return new Ship("battleship", 4, 0, 5);
        }

        public void MoveBy(int x, int y)
        {
            for (int pos_index = 0; pos_index < Positions.Length; pos_index++)
            {
                Positions[pos_index, 0] += x;
                Positions[pos_index, 1] += y;
            }
        }
        public void MoveTo(int x, int y)
        {
            int x_offset = CenterX - x;
            int y_offset = CenterY - y;

            MoveBy(x_offset, y_offset);
        }
        public void RotateClockwise()
        {
            int x = CenterX;
            int y = CenterY;

            MoveTo(0, 0);

            for (int pos_index = 0; pos_index < Positions.Length; pos_index++) {
                Positions[pos_index, 0] = Positions[pos_index, 1];
                Positions[pos_index, 1] = -Positions[pos_index, 0];
            }

            MoveTo(x, y);
        }
    }
}
