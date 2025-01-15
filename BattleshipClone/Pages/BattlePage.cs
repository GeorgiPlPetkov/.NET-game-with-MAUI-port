using BattleshipClone.DB;

namespace BattleshipClone.Pages;

public class BattlePage : ContentPage
{
    private readonly ISavedStateRepository repository;
    private ListView list_view = new();
    public BattlePage(ISavedStateRepository repo)
    {
        repository = repo;

        Task.Run(() => { list_view.ItemsSource = repository.GetAll().Result; });

        Content = new VerticalStackLayout
        {
            Children = {
                new Button {
                    Text = "demo",
                    Command = new Command(execute: () => {
                        SavedGameState game_state = new()
                        {
                            StateId = 0,
                            Name = "test",
                            TurnNumber = 2,
                            PlayerShots = new byte[1],
                            EnemyShots = new byte[1]
                        };
                        repository.Create(game_state);
                        list_view.ItemsSource = repository.GetAll().Result;
                    })
                },
                list_view
            }
        };
    }

    private void OnNewElement(object sender, EventArgs e)
    {
        

    }
}