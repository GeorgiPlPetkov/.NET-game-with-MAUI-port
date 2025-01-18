using BattleshipClone.Game;

namespace BattleshipClone.Pages.CustomElements
{
    public struct BattleDisplayInfo
    {
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
    public partial class BattleDisplayUI : HorizontalStackLayout
    {
        private readonly Label display_label;

        public BattleDisplayUI()
        {
            WidthRequest = GameBoard.TileSize * 8 * 2;

            HorizontalOptions = LayoutOptions.Center;
            VerticalOptions = LayoutOptions.Center;

            display_label = new()
            {
                Text = "Turn: 1 | Hits: 0 | Misses: 0",
                FontSize = 24
            };

            Children.Add(display_label);
        }

        public void Update(BattleDisplayInfo new_info)
        {
            display_label.Text = $"Turn: {new_info.CurrentTurn} | Hits: {new_info.Hits} | Misses: {new_info.Misses}";
        }
    }
}
