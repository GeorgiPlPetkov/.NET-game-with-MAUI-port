using BattleshipClone.DB;
using BattleshipClone.Game;
using BattleshipClone.Pages.CustomElements;

namespace BattleshipClone.Pages;

public partial class BattlePage : ContentPage
{
    private readonly ISavedStateRepository repository;
    private readonly Enemy enemy;

    private GameBoard player_board;
    private GameBoardUI player_board_ui;
    private GameBoard enemy_board;
    private GameBoardUI enemy_board_ui;

    private BattlePageUI display;
    private BattleDisplayInfo display_info;
    
    public BattlePage(ISavedStateRepository repo, Enemy enemy)
    {
        repository = repo;
        this.enemy = enemy;

        List<TapGestureRecognizer> enemy_tile_bhv = new List<TapGestureRecognizer>();
        TapGestureRecognizer player_tap = new TapGestureRecognizer();
        player_tap.Tapped += OnPlayerTap;
        enemy_tile_bhv.Add(player_tap);

        player_board = new GameBoard();
        enemy_board = new GameBoard();
        player_board_ui = new GameBoardUI(player_board);
        enemy_board_ui = new GameBoardUI(enemy_board, enemy_tile_bhv, null);

        display = new();
        display_info = new BattleDisplayInfo(); 
        

        Content = new VerticalStackLayout
        {
            Children = {
                player_board_ui,
                display,
                enemy_board_ui,
            }
        };
    }

    private void OnPlayerTap(object? sender, EventArgs e)
    {
        Image tile_image = (Image) sender!;

        int player_shot_x = (int)tile_image.MinimumWidthRequest;
        int player_shot_y = (int)tile_image.MinimumHeightRequest;

        int player_hit_result = enemy_board.Check(player_shot_x, player_shot_y);

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
            enemy_hit_result = player_board.Check(enemy_shot_x, enemy_shot_y);
        }

        display_info.CurrentTurn++;
        display.Update(display_info);

        player_board_ui.UpdateShips();
        enemy_board_ui.UpdateShips();
    }
}
public struct BattleDisplayInfo { 
    public int Hits { get; set; }
    public int Misses { get; set; }
    public int CurrentTurn { get; set; }

    public BattleDisplayInfo()
    { 
        Hits = 0;  
        Misses = 0;
        CurrentTurn = 0;
    }
}
public partial class BattlePageUI : HorizontalStackLayout {
    private readonly Label turn_display;
    private readonly Label hit_display;
    private readonly Label miss_display;

    public BattlePageUI() {
        WidthRequest = GameBoard.TileSize * 8 * 2;
        HeightRequest = 32;
        
        HorizontalOptions = LayoutOptions.Center;
        VerticalOptions = LayoutOptions.Center;

        turn_display = new() { 
            Text = "Turn: 1"
        };
        hit_display = new()
        {
            Text = "Hits: 0"
        };
        miss_display = new()
        {
            Text = "Misses: 0"
        };

        Children.Add(turn_display);
        Children.Add(hit_display);
        Children.Add(miss_display);
    }

    public void Update(BattleDisplayInfo new_info) { 
        turn_display.Text = $"Turn: {new_info.CurrentTurn}";
        hit_display.Text = $"Turn: {new_info.Hits}";
        miss_display.Text = $"Turn: {new_info.Misses}";
    }
}