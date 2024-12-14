using hExDEN.BattleResolver;
using hExDEN.GameWorld;
using System.Numerics;

namespace HedenAndroidPort;

public class BattlePage : ContentPage
{
	private ScrollView buffer_view = new();
	private AbsoluteLayout world_view = new();
	private BattleResolver battle_resolver = new BattleResolver();
    public BattlePage()
	{
		Content = buffer_view;
		buffer_view.Content = world_view;
		UpdateWorld();
	}

	private void UpdateWorld() 
	{ 
		world_view.Children.Clear();

		foreach (KeyValuePair<Vector2, Tile> entry in battle_resolver.GameWorld.Tiles) 
		{
			Tile tile = entry.Value;
			world_view.Children.Add(new Image {
				Source = ImageSource.FromStream(() => new MemoryStream(tile.Image)),
				TranslationX = tile.Position.X,
				TranslationY = tile.Position.Y,
            });
		}
	}
}