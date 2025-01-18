using BattleshipClone.DB;
using BattleshipClone.Game;
using BattleshipClone.Pages.CustomElements;

namespace BattleshipClone.Pages;

public partial class BattlePage : ContentPage
{
    private readonly ISavedStateRepository repository;
    private SavedGameState game_state;
    private readonly Enemy enemy;

    private GameBoard player_board;
    private GameBoardUI player_board_ui;
    private GameBoard enemy_board;
    private GameBoardUI enemy_board_ui;

    private BattleDisplayUI display;
    private BattleDisplayInfo display_info;

    private Frame quit_menu;
    private Button quit_button;
    private Button save_button;
    private Entry game_name_entry;    
    public BattlePage(SavedGameState game_state)
    {
        repository = new SavedStateRepository();
        this.enemy = new Enemy();
        
        this.game_state = LoadGameState(game_state);

        game_name_entry = new Entry {
            Margin = 5,
            Text = game_state.Name
        };
        save_button = new Button {
            Margin = 5,
            Text = "Save and Quit"
        };
        save_button.Clicked += (s, e) => {
            game_state.EnemyShots = enemy_board.GetShotMapAsByte();
            game_state.PlayerShots = player_board.GetShotMapAsByte();
            
            if (game_state.StateId == 0) {
                game_state.Name = game_name_entry.Text;
                repository.Create(game_state);
            }
            else {
                if (game_state.Name == game_name_entry.Text) {
                    repository.Update(game_state);
                }
                else {
                    game_state.StateId = 0;
                    game_state.Name = game_name_entry.Text;
                    repository.Create(game_state);
                }
            }

            Shell.Current.GoToAsync("//MainPage", false);            
        };
        quit_button = new Button {
            Margin = 5,
            Text = "Quit"
        };
        quit_button.Clicked += (s, e) => {
            Shell.Current.GoToAsync("//MainPage", false);
        };
        quit_menu = new Frame
        {
            WidthRequest = 300,
            HeightRequest = 200,
            Content = new VerticalStackLayout {
                game_name_entry,
                save_button,
                quit_button
            }
        };

        Content = new VerticalStackLayout
        {
            Children = {
                display,
                new HorizontalStackLayout {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,

                    Children = {
                        player_board_ui,
                        enemy_board_ui,
                    }
                },
                quit_menu
            }
        };
    }

    private SavedGameState LoadGameState(SavedGameState current_state) { 
        player_board = new GameBoard(true);
        player_board.LoadShotMap(current_state.PlayerShots);
        player_board.LoadShipMap(current_state.PlayerShips);
        
        enemy_board = new GameBoard(false);
        enemy_board.LoadShotMap(current_state.EnemyShots);
        enemy_board.LoadShipMap(current_state.EnemyShips);
        
        player_board_ui = new GameBoardUI(player_board);

        List<TapGestureRecognizer> enemy_tile_bhv = new();
        TapGestureRecognizer player_tap = new();
        player_tap.Tapped += OnPlayerTap;
        enemy_tile_bhv.Add(player_tap);
        enemy_board_ui = new GameBoardUI(enemy_board, enemy_tile_bhv, []);

        display = new();
        display_info = new BattleDisplayInfo();
        
        display.Update(display_info);
        player_board_ui.UpdateShips();

        player_board_ui.UpdateOverlay(true);
        enemy_board_ui.UpdateOverlay(false);

        return current_state;
    }

    private void OnPlayerTap(object? sender, EventArgs e)
    {
        Image tile_image = (Image) sender!;

        int player_shot_x = (int)tile_image.MinimumWidthRequest;
        int player_shot_y = (int)tile_image.MinimumHeightRequest;

        int player_hit_result = enemy_board.Hit(player_shot_x, player_shot_y);
        if (player_hit_result == -2) {
            return;
        }
        else if (player_hit_result == -1) {
            display_info.Misses++;
        }
        else { 
            display_info.Hits++;
        }

        int enemy_hit_result = -2;
        while (enemy_hit_result == -2) {
            (int enemy_shot_x, int enemy_shot_y) = enemy.MakeMove();
            enemy_hit_result = player_board.Hit(enemy_shot_x, enemy_shot_y);
        }

        display_info.CurrentTurn++;
        display.Update(display_info);

        player_board_ui.UpdateShips();
        player_board_ui.UpdateOverlay(true);
        enemy_board_ui.UpdateOverlay(false);
    }
}
