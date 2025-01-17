using BattleshipClone.Game;
using BattleshipClone.Game.Tiles;
using BattleshipClone.Game.Ships;
using BattleshipClone.Pages.CustomElements;
using SQLitePCL;

namespace BattleshipClone.Pages;

public partial class SetupPage : ContentPage
{
    private GameBoard player_board;
    private GameBoardUI player_board_ui;

    private HorizontalStackLayout ship_list_ui = new();
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

    private readonly List<TapGestureRecognizer> ship_bit_behaviour = [];
    private readonly List<TapGestureRecognizer> tile_behaviour = [];
    public SetupPage()
    {
        TapGestureRecognizer rotation_gesture = new();
        rotation_gesture.Tapped += OnShipDoubleTap;
        rotation_gesture.NumberOfTapsRequired = 2;
        
        TapGestureRecognizer selection_gesture = new();
        selection_gesture.Tapped += OnShipSelectedFromBoard;

        TapGestureRecognizer placement_gesture = new();
        placement_gesture.Tapped += OnTileTap;

        ship_bit_behaviour.Add(rotation_gesture);
        ship_bit_behaviour.Add(selection_gesture);
        tile_behaviour.Add(placement_gesture);

        player_board = new();
        player_board_ui = new(player_board, tile_behaviour, ship_bit_behaviour);

        ship_list_ui.ChildRemoved += OnShipPloppedDown;

        Content = new VerticalStackLayout
        {
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,

            Children = {
                player_board_ui,
                new ScrollView { 
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,

                    Orientation = ScrollOrientation.Horizontal,
                    Content = ship_list_ui
                },
            }
        };

        LoadShipList();
        player_board_ui.UpdateShips();
    }

    /// <summary>
    /// Ship list functionalities
    /// </summary>
    private void LoadShipList() {
        for (int ship_index = 0; ship_index < ship_list.Count; ship_index++)
        {
            Ship ship = ship_list[ship_index];

            Frame ship_frame = new()
            {
                WidthRequest = 200,
                HeightRequest = 200,

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

    private void UpdateShipList() {
        for (int ship_index = 0; ship_index < ship_list.Count; ship_index++)
        {
            Frame f = (Frame) ship_list_ui.Children[ship_index];
            f.MinimumWidthRequest = ship_index;
        }
    }
    private void OnShipPloppedDown(object? sender, EventArgs e)
    {
        int childs = ship_list_ui.Children.Count;

        if (childs > 0)
            return;

        Label difficutly_label = new() { 
            Text = "$Difficutly: 1",
            HorizontalTextAlignment = TextAlignment.Center,
            VerticalTextAlignment = TextAlignment.Center, 
            
            Margin = 3,
        };
        Slider difficutly_slider = new()
        {
            Value = 1,
            Minimum = 1,
            Maximum = 3,

            Margin = 3,

            WidthRequest = 180,
        };
        difficutly_slider.ValueChanged += (s, e) =>
        {
            int dif_val = (int)e.NewValue;
            difficutly_label.Text = $"Difficutly: {dif_val}";
        };
        Button start_game_b = new()
        {
            Text = "Play",

            Margin = 3,
        };
        start_game_b.Clicked += (s, e) => {
            Shell.Current.GoToAsync("//GamePage");
        };
        Button reset_setup_ui_b = new()
        {
            Text = "Reset",
            Margin = 3,
        };
        reset_setup_ui_b.Clicked += (s, e) => { 
            player_board = new();
            player_board_ui = new(player_board, tile_behaviour, ship_bit_behaviour);
            
            ship_list = new() {
                Ship.Destroyer(),
                Ship.Destroyer(),
                Ship.Destroyer(),

                Ship.Cruiser(),
                Ship.Cruiser(),

                Ship.Battleship(),
            };
            ship_list_ui.ChildRemoved -= OnShipPloppedDown;
            ship_list_ui.Children.Clear();
            ship_list_ui.ChildRemoved += OnShipPloppedDown;
            LoadShipList();
            
            selected_ship = null;
            selected_ship_index = -1;
            
            player_board_ui.Load();
            player_board_ui.UpdateShips();
        };
        Button main_menu_b = new()
        {
            Text = "Main Menu",
            Margin = 3,
        };
        main_menu_b.Clicked += (s, e) => { Shell.Current.GoToAsync("//MainPage"); };
        Frame finish_screen_frame = new() {
            WidthRequest = 300,
            HeightRequest = 300,
            Content = new VerticalStackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,

                TranslationX = 10,
                TranslationY = 10,
                
                Children = { 
                    difficutly_label,
                    difficutly_slider,
                    start_game_b,
                    reset_setup_ui_b,
                    main_menu_b,
                }
            }
        };

        ship_list_ui.Children.Add(finish_screen_frame);
    }

    /// <summary>
    /// Game board management functionalities
    /// </summary>
    private void OnTileTap(object? sender, TappedEventArgs e)
    {
        if (selected_ship == null)
            return;

        if (!IsSelectedShipOnTheBoard())
        {
            player_board.AddShip(selected_ship);
            ship_list.RemoveAt(selected_ship_index);
            ship_list_ui.Children.RemoveAt(selected_ship_index);
            selected_ship_index = -1;
        }
        Image image_sender = (Image)sender!;

        int tile_x = (int)image_sender.MinimumWidthRequest;
        int tile_y = (int)image_sender.MinimumHeightRequest;
        
        player_board.MoveShip(selected_ship, tile_x, tile_y);

        player_board_ui.UpdateShips();
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
        player_board_ui.UpdateShips();
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
        player_board_ui.UpdateShips();
    }

}