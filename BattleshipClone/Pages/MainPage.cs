using BattleshipClone.Pages.CustomElements;

namespace BattleshipClone.Pages;

public partial class MainPage : ContentPage
{
    public MainPage()
	{
        double screen_width = DeviceDisplay.MainDisplayInfo.Width;
        double screen_heigth = DeviceDisplay.MainDisplayInfo.Height;

        double menu_button_text_size = screen_heigth * .05;

        double main_menu_w = screen_width * .8;
        double main_menu_h = screen_heigth * .4;

        BackgroundImageSource = ImageSource.FromFile("dotnet_bot.png");
        
        Content = new VerticalStackLayout
		{
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,

            Children = {
				new Frame { 
					Padding = 20, 
					CornerRadius = 20,
					WidthRequest = main_menu_w,
					HeightRequest = main_menu_h,

                    BackgroundColor = Color.FromRgb(2, 2, 1),
					Opacity = .75,
					HasShadow = true,

					Content = new StackLayout {
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Fill,

                        Children = { 
							new MenuButton { 
								Text = "New Game",
                                FontSize = menu_button_text_size,
                                VerticalOptions = LayoutOptions.Fill,
								Command = new Command(execute: () => {
                                    Shell.Current.GoToAsync("//SetupPage");
                                }) 
							},
                            new MenuButton {
								Text = "Load Game",
                                FontSize = menu_button_text_size,

                                Command = new Command(execute: () => {
                                    Shell.Current.GoToAsync("//SavedGamesPage");
                                })
                            },
                            new MenuButton {
								Text = "Options",
                                FontSize = menu_button_text_size,

                                Command = new Command(execute: () => {
                                    Shell.Current.GoToAsync("//OptionsPage");
                                })
                            },
                            new MenuButton {
								Text = "Kill Self",
                                FontSize = menu_button_text_size,

                                Command = new Command(execute: () => {
                                    System.Diagnostics.Process.GetCurrentProcess()
                                                            .CloseMainWindow();
                                })
                            },
                        }
					}
				
				}
			}
		};


	}

    private void OnNewGameClicked(object sender, EventArgs e)
    {
        
        // Add logic to start a new game
    }

    private async void OnLoadGameClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Load Game", "pwessed", "clos");
        // Add logic to load a game
    }

    private async void OnOptionsClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Opts", "pwessed", "clos");
        // Add logic to open options
    }

    private void OnExitClicked(object sender, EventArgs e)
    {
        System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
    }
}