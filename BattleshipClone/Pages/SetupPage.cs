using BattleshipClone.Game;
using BattleshipClone.Game.Tiles;
using BattleshipClone.Game.Ships;

namespace BattleshipClone.Pages;

public class SetupPage : ContentPage
{
    private GameBoard player_board = new();
    private AbsoluteLayout player_board_ui;

    private HorizontalStackLayout ship_list_ui = new() 
    {
        Children = {
            new Label { Text = "seeing me is bad mate >:3" }
        }
    };
    private List<Ship> ship_list = new() {
        Ship.Destroyer(),
        Ship.Destroyer(), 
        Ship.Destroyer(), 
        
        Ship.Cruiser(),
        Ship.Cruiser(),
        
        Ship.Battleship(),
    };

    public SetupPage()
    {
        player_board_ui = new()
        {
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,

            BackgroundColor = Colors.Coral,

            WidthRequest = player_board.BoardWidth * GameBoard.TileSize,
            HeightRequest = player_board.BoardHeight * GameBoard.TileSize
        };

        Content = new VerticalStackLayout
        {
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,

            Children = {
                player_board_ui,
                ship_list_ui,
            }
        };


        UpdateShipList();
        UpdateBoard();

    }

    private void UpdateShipList() {
        ship_list_ui.Children.Clear();
        
        foreach (IShip ship in ship_list) {
            ship_list_ui.Children.Add(new Frame {
                HeightRequest = 200,
                WidthRequest = 200,
                
                CornerRadius = 2,
                
                Padding = 0,
                Margin = 0,
                Content = new AbsoluteLayout { 
                    new Image {
                        TranslationX = 0,
                        TranslationY = 0,
                        
                        WidthRequest = 200,
                        HeightRequest = 200,
                    },
                    new Label { 
                        Text = ship.ShipClass,

                        TranslationX = 0,
                        TranslationY = 180,
                    },
                    new Label {
                        Text = ship.Size.ToString(),
                        TranslationX = 0,
                        TranslationY = 0
                    },
                }
            });
        }
    }
   
    private void UpdateBoard() {  
        for (int tile_y = 0; tile_y < player_board.BoardHeight; tile_y++)
            for (int tile_x = 0; tile_x < player_board.BoardHeight; tile_x++) {
                Tile current_tile = player_board.Tiles[tile_y, tile_x];

                player_board_ui.Add(new Image { 
                    Source = ImageSource.FromFile($"{current_tile.TileType}.png"),
                    
                    WidthRequest = GameBoard.TileSize,
                    HeightRequest = GameBoard.TileSize,
                    
                    TranslationX = tile_x * GameBoard.TileSize,
                    TranslationY = tile_y * GameBoard.TileSize,
                });
            }
       
    }
}