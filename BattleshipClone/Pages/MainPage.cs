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
        double main_menu_h = screen_heigth * .35;

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
                                
								Command = new Command(execute: () => {
                                    Navigation.PushAsync(new SetupPage(), false);
                                }) 
							},
                            new MenuButton {
								Text = "Load Game",
                                FontSize = menu_button_text_size,

                                Command = new Command(execute: () => {
                                    Navigation.PushAsync(new SavedGamesPage(), false);
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
}