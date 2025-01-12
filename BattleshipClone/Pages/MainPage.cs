namespace BattleshipClone.Pages;

public class MainPage : ContentPage
{
	public MainPage()
	{
		Content = new VerticalStackLayout
		{
			Children = {
				new Label {
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center,
					Text = "Main Page, will probably hold title"
				},
				new Image {
					Source = ImageSource.FromFile("dotnet_bot.png"),
					HeightRequest = 100,
					WidthRequest = 100,
				}
			}
		};
	}
}