using BattleshipClone.Game;
using BattleshipClone.Game.Tiles;
using BattleshipClone.Game.Ships;

namespace BattleshipClone.Pages;

public partial class SetupPage : ContentPage
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
    
    private Ship? selected_ship = null;
    private int selected_ship_index = -1;

    
    

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
        
        for(int ship_index = 0; ship_index < ship_list.Count; ship_index++) {
            Ship ship = ship_list[ship_index];
            
            Frame ship_frame = new() {
                HeightRequest = 200,
                WidthRequest = 200,

                CornerRadius = 2,
                
                Padding = 0,
                Margin = 0,

                MinimumWidthRequest = ship_index,

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
            };
            TapGestureRecognizer tgr = new();
            tgr.Tapped += OnShipSelectedFromList;
            ship_frame.GestureRecognizers.Add(tgr);
            
            ship_list_ui.Children.Add(ship_frame);
        }
    }

    
    private void UpdateBoard() {  
        player_board_ui.Children.Clear();
        for (int tile_y = 0; tile_y < player_board.BoardHeight; tile_y++)
            for (int tile_x = 0; tile_x < player_board.BoardHeight; tile_x++) {
                Tile current_tile = player_board.Tiles[tile_y, tile_x];
                Image tile_ui = new Image
                {
                    Source = ImageSource.FromFile($"{current_tile.TileType}.png"),

                    WidthRequest = GameBoard.TileSize,
                    HeightRequest = GameBoard.TileSize,

                    MinimumWidthRequest = tile_x,
                    MinimumHeightRequest = tile_y,

                    TranslationX = tile_x * GameBoard.TileSize,
                    TranslationY = tile_y * GameBoard.TileSize,
                };
                TapGestureRecognizer tap = new TapGestureRecognizer();
                tap.Tapped += OnTileTap;
                tile_ui.GestureRecognizers.Add(tap);
                
                player_board_ui.Add(tile_ui);
            }

        foreach(Ship s in player_board.Ships) {
            if (s == null) break;
            for (int ship_bit_index = 0; ship_bit_index < s.Size; ship_bit_index++)
            {
                Image ship_segment = new()
                {
                    WidthRequest = GameBoard.TileSize,
                    HeightRequest = GameBoard.TileSize,

                    MinimumWidthRequest = s.Positions[ship_bit_index, 0],
                    MinimumHeightRequest = s.Positions[ship_bit_index, 1],

                    TranslationX = s.Positions[ship_bit_index, 0] * GameBoard.TileSize,
                    TranslationY = s.Positions[ship_bit_index, 1] * GameBoard.TileSize,

                    Source = ImageSource.FromFile($"{s.ShipClass.ToLower()}.png"),
                };
                TapGestureRecognizer rotation_gesture = new();
                rotation_gesture.Tapped += OnShipDoubleTap;
                rotation_gesture.NumberOfTapsRequired = 5;
                
                TapGestureRecognizer selection_gesture = new();
                selection_gesture.Tapped += OnShipSelectedFromBoard;
                
                ship_segment.GestureRecognizers.Add(rotation_gesture);
                ship_segment.GestureRecognizers.Add(selection_gesture);

                player_board_ui.Add(ship_segment);
            }
        }
    }

    private void OnTileTap(object? sender, TappedEventArgs e)
    {
        if (selected_ship == null)
            return;

        if (!IsSelectedShipOnTheBoard())
        {
            player_board.AddShip(selected_ship);
            ship_list.RemoveAt(selected_ship_index);
            selected_ship_index = -1;
        }
        Image image_sender = (Image)sender!;

        int tile_x = (int)image_sender.MinimumWidthRequest;
        int tile_y = (int)image_sender.MinimumHeightRequest;
        
        player_board.MoveShip(selected_ship, tile_x, tile_y);

        UpdateBoard();
        UpdateShipList();
    }

    private bool IsSelectedShipOnTheBoard() {
        for(int ship_index = 0; ship_index < player_board.Ships.Length; ship_index++)
            if(selected_ship == player_board.Ships[ship_index]) return true;

        return false;
    }

    private void OnShipSelectedFromList(object? sender, EventArgs e)
    {
        Frame sender_frame = (Frame)sender!;
        selected_ship_index = (int)sender_frame.MinimumWidthRequest;

        selected_ship = ship_list[selected_ship_index];

        UpdateShipList();
        UpdateBoard();
    }

    private void OnShipSelectedFromBoard(object? sender, EventArgs e) {
        Image image_sender = (Image)sender!;

        int gamespace_x = (int)image_sender.MinimumWidthRequest;
        int gamespace_y = (int)image_sender.MinimumHeightRequest;

        int selected_ship_index = player_board.Check(gamespace_x, gamespace_y);

        if (selected_ship_index == -1)
            return;
        
        selected_ship = player_board.Ships[selected_ship_index];
    }

    private void OnShipDoubleTap(object? sender, EventArgs e) {
        if (selected_ship == null)
            return;

        player_board.RotateShipClockwise(selected_ship);
       
        UpdateShipList();
        UpdateBoard();
    }
}