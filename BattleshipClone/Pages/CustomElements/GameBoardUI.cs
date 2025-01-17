using BattleshipClone.Game;
using BattleshipClone.Game.Ships;
using BattleshipClone.Game.Tiles;

namespace BattleshipClone.Pages.CustomElements
{
    public partial class GameBoardUI : AbsoluteLayout
    {
        private readonly GameBoard board;
        private readonly List<TapGestureRecognizer> tile_gestures;
        private readonly List<TapGestureRecognizer> ship_gestures;

        private const int scale = 2;
        public GameBoardUI(GameBoard board) { 
            this.board = board;
            this.tile_gestures = [];
            this.ship_gestures = [];

            HorizontalOptions = LayoutOptions.Center;
            VerticalOptions = LayoutOptions.Center;

            BackgroundColor = Colors.Coral;

            WidthRequest = board.BoardWidth * GameBoard.TileSize * scale;
            HeightRequest = board.BoardHeight * GameBoard.TileSize * scale;

            Load();
        }        

        public GameBoardUI(GameBoard board, List<TapGestureRecognizer>? tile_gestures, List<TapGestureRecognizer>? ship_gestures) 
            : this(board) {
            
            this.tile_gestures = tile_gestures!;
            this.ship_gestures = ship_gestures!;

            Load();
        }

        public void Load() {
            Children.Clear();

            for (int tile_y = 0; tile_y < board.BoardHeight; tile_y++)
                for (int tile_x = 0; tile_x < board.BoardHeight; tile_x++)
                {
                    Tile current_tile = board.Tiles[tile_y, tile_x];
                    Image tile_ui = new()
                    {
                        Source = ImageSource.FromFile($"{current_tile.TileType}.png"),

                        WidthRequest = GameBoard.TileSize * scale,
                        HeightRequest = GameBoard.TileSize * scale,

                        MinimumWidthRequest = tile_x,
                        MinimumHeightRequest = tile_y,

                        TranslationX = tile_x * GameBoard.TileSize * scale,
                        TranslationY = tile_y * GameBoard.TileSize * scale,
                    };

                    foreach (TapGestureRecognizer tgr in tile_gestures)
                        tile_ui.GestureRecognizers.Add(tgr);

                    Children.Add(tile_ui);
                }
        }

        public void UpdateShips() {
            int culling_floor = board.BoardWidth * board.BoardHeight;

            for(int cull_index = Children.Count; cull_index >= culling_floor; cull_index--)
                Children.RemoveAt(cull_index);
            
            foreach (Ship s in board.Ships)
            {
                if (s == null) 
                    break;
                
                for (int ship_bit_index = 0; ship_bit_index < s.Size; ship_bit_index++)
                {
                    Image ship_bit = new()
                    {
                        WidthRequest = GameBoard.TileSize * scale,
                        HeightRequest = GameBoard.TileSize * scale,

                        MinimumWidthRequest = s.Positions[ship_bit_index, 0],
                        MinimumHeightRequest = s.Positions[ship_bit_index, 1],

                        TranslationX = s.Positions[ship_bit_index, 0] * GameBoard.TileSize * scale,
                        TranslationY = s.Positions[ship_bit_index, 1] * GameBoard.TileSize * scale,

                        Source = ImageSource.FromFile($"{s.ShipClass.ToLower()}.png"),
                    };

                    foreach (TapGestureRecognizer tgr in ship_gestures)
                        ship_bit.GestureRecognizers.Add(tgr);
        
                    Children.Add(ship_bit);
                }
            }
        }

        public void UpdateOverlay() { 
        
        }
    }
}
