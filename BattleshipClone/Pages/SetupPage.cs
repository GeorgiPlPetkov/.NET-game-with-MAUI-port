using BattleshipClone.Game;
using BattleshipClone.Game.Tiles;
using BattleshipClone.Game.Ships;

namespace BattleshipClone.Pages;

public class SetupPage : ContentPage
{

    private GameBoard board;
    private AbsoluteLayout board_display;

    private List<Ship> ship_loadout = new() {
        Ship.Destroyer(),
        Ship.Destroyer(), 
        Ship.Destroyer(), 
        
        Ship.Cruiser(),
        Ship.Cruiser(),
        
        Ship.Carrier(),
        Ship.Battleship(),
    };

    public SetupPage()
    {
        board = new GameBoard();
        LoadBoard(board);
        Content = new VerticalStackLayout
        {
            Children = {
                new Label {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    Text = "Where the game will happen"
                },
                board_display,
            }
        };
    }
   
    private void LoadBoard(GameBoard board) { 
        board_display = new() {
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            
            BackgroundColor = Colors.Coral,

            WidthRequest = board.TileSize * board.Tiles.GetLength(0),
            HeightRequest = board.TileSize * board.Tiles.GetLength(1),
        };
        
        for (int tile_y = 0; tile_y < board.BoardHeight; tile_y++)
            for (int tile_x = 0; tile_x < board.BoardHeight; tile_x++) {
                Tile current_tile = board.Tiles[tile_y, tile_x];
                
                board_display.Add(new Image { 
                    Source = ImageSource.FromFile($"{current_tile.TileType}.png"),
                    
                    WidthRequest = board.TileSize,
                    HeightRequest = board.TileSize,
                    
                    TranslationX = tile_x * board.TileSize,
                    TranslationY = tile_y * board.TileSize,
                });
            }
       
    }
}