using BattleshipClone.DB;
namespace BattleshipClone.Pages;

public class SavedGamesPage : ContentPage
{
	private ISavedStateRepository repository;

	private VerticalStackLayout saves_list;
	private List<SavedGameState> game_states;
    public SavedGamesPage()
	{
		repository = new SavedStateRepository();
		
		

		saves_list = new() {
			HeightRequest = 1000,
			WidthRequest = 500,
		};
		Content = new ScrollView
		{
			Content = saves_list
		};

        game_states = repository.GetAll().Result;
        UpdateSavesList();
    }

	private void UpdateSavesList() {
       
        saves_list.Children.Clear();
		Button back_b = new()
		{
			Text = "Back",
			FontSize = 24,
			Margin = 3,

		};
        back_b.Clicked += (s, e) => {
            Shell.Current.GoToAsync("//MainPage", false);
        };
        
		for(int save_index = 0; save_index < game_states.Count; save_index++)
			saves_list.Children.Add(CreateSaveStateMenu(game_states[save_index]));

		saves_list.Children.Add(back_b);
    }

    private Frame CreateSaveStateMenu(SavedGameState svg) {
		Button delete_b = new()
		{
			Margin = 5,
			Padding = 0,

			WidthRequest = 55,
			HorizontalOptions = LayoutOptions.Fill,
			VerticalOptions = LayoutOptions.Center,

			Text = "Delete"
		};
		delete_b.Clicked += async (s, e) =>
		{
            await repository.Delete(svg);
            await Navigation.PushAsync(new SavedGamesPage(), false);
        };
        Button open_b = new() {
            Margin = 5,
            Padding = 0,

            WidthRequest = 55,
            HorizontalOptions = LayoutOptions.Fill,
            VerticalOptions = LayoutOptions.Center,

            Text = "Open"
        };
		open_b.Clicked += (s, e) =>
		{
			Navigation.PushAsync(new BattlePage(svg), false);
        };

        return new Frame()
		{
			HeightRequest = 100,
			WidthRequest = 500,

			Margin = 3,

			Content = new HorizontalStackLayout {
				Children = {
					new VerticalStackLayout {
						HorizontalOptions = LayoutOptions.Start,
						VerticalOptions = LayoutOptions.Center,
						Children = {
							new Label {
								Margin = 5,

								HorizontalTextAlignment = TextAlignment.Start,
								VerticalTextAlignment = TextAlignment.Center,
								Text = $"{svg.Name}"
							},
							new Label {
								Margin = 5,

								HorizontalTextAlignment = TextAlignment.Start,
								VerticalTextAlignment = TextAlignment.Center,
								Text = $"Current Turn: {svg.TurnNumber}"
							}
						},
					},
					new Label {
						Margin = 15,

						HorizontalTextAlignment = TextAlignment.Center,
						VerticalTextAlignment = TextAlignment.Center,

						Text = $"Difficulty: {svg.Difficulty}",
						FontSize = 24
					},
					delete_b,
					open_b
				}
			}
		};
	}
}